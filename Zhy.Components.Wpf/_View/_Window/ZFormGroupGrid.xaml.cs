﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zhy.Components.Wpf._Attribute;
using Zhy.Components.Wpf._Model;

namespace Zhy.Components.Wpf._View._Window
{
    /// <summary>
    /// ZFormGroupGrid.xaml 的交互逻辑
    /// </summary>
    public partial class ZFormGroupGrid : Window
    {
        private ZFormGroupGridViewModel vm = null;
        /// <summary>
        /// ZFormGrid构造函数
        /// </summary>
        /// <param name="zFormItems">表单项</param>
        public ZFormGroupGrid(List<ZFormItemGroup> zFormItemGroups)
        {
            InitializeComponent();
            vm = new ZFormGroupGridViewModel(zFormItemGroups, dr => this.DialogResult = dr);
            this.DataContext = vm;
        }

        public bool IsReadOnly { get => vm.IsReadOnly; set => vm.IsReadOnly = value; }

        /// <summary>
        /// 表单项分组
        /// </summary>
        public List<ZFormItemGroup> ZFormItemGroups => vm.ZFormItemGroups;

        private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            double currentVerticalOffset = scrollViewer.VerticalOffset;
            double delta = e.Delta / 3.0;
            scrollViewer.ScrollToVerticalOffset(currentVerticalOffset - delta);
            e.Handled = true;
        }
    }

    internal class ZFormGroupGridViewModel : ObservableObject
    {
        private List<ZFormItemGroup> zFormItemGroups = new List<ZFormItemGroup>();
        public List<ZFormItemGroup> ZFormItemGroups
        {
            get { return zFormItemGroups; }
            set { SetProperty(ref zFormItemGroups, value); }
        }
        private bool _isReadOnly = false;
        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set { SetProperty(ref _isReadOnly, value); }
        }

        private Action<bool> _actionDr = null;

        internal ZFormGroupGridViewModel(List<ZFormItemGroup> zFormItemGroups, Action<bool> actionDr)
        {
            foreach (var itemGroup in zFormItemGroups)
            {
                for (int i = 0; i < itemGroup.ZFormItems.Count; i++)
                {
                    itemGroup.ZFormItems[i].Oid = i + 1;
                }
            }
            
            ZFormItemGroups = zFormItemGroups;
            _actionDr = actionDr;
        }

        public RelayCommand OKCommand => new RelayCommand(OK);
        public RelayCommand CancelCommand => new RelayCommand(Cancel);
        private void OK()
        {
            foreach (var itemGroup in zFormItemGroups)
            {
                foreach (var item in itemGroup.ZFormItems)
                {
                    if (item.VerifyFunc != null)
                    {
                        if (item.VerifyFunc(item))
                        {
                            continue;
                        }
                        //MessageBox.Show(item.Tip, $"{itemGroup.Name}中，第 {item.Oid} 项值异常！", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
            }
            _actionDr(true);
        }
        private void Cancel()
        {
            _actionDr(false);
        }
    }
}