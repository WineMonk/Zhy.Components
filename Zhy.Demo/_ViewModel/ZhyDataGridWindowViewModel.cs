﻿/****************************************
 * FileName:	ZhyDataGridWindowViewModel
 * Creater: 	shaozhy
 * Create Date:	2023/8/28 15:09:27
 * Version: 	v0.0.1
 * ======================================
 * Modify: —— Version: —— Date: —— Modifier: —— Content:
 ****************************************/
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Zhy.Components.Wpf._Common._Utils;
using Zhy.Components.Wpf._Enum;
using Zhy.Demo._Common;
using Zhy.Demo._Model;

namespace Zhy.Demo._ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    public class ZhyDataGridWindowViewModel : ObservableObject
    {
        public ZhyDataGridWindowViewModel()
        {
            TestItems = new ObservableCollection<AccountInfo>();
            AccountInfo accountInfo = new AccountInfo();
            accountInfo.NO = 1;
            accountInfo.Phone = "12345678901";
            accountInfo.Username = "管理员账号";
            accountInfo.ArchivesPath = "D:\\admin\\admin.ad";
            accountInfo.Role = accountInfo.Roles.FirstOrDefault(r => r == "系统管理员");
            accountInfo.Permission.ForEach(permission => permission.IsChecked = true);
            TestItems.Add(accountInfo);
            for (int i = 0; i < 100; i++)
            {
                accountInfo = new AccountInfo();
                accountInfo.NO = i + 2;
                accountInfo.Phone = CommonUtils.GenerateRandomPhoneNumber();
                accountInfo.Username = CommonUtils.GenerateRandomName();
                accountInfo.ArchivesPath = "D:\\admin\\admin.ad";
                accountInfo.Role = accountInfo.Roles.FirstOrDefault(r => r == "角色1");
                accountInfo.Permission.ForEach(permission => permission.IsChecked = new Random().Next(0, 2) == 1);
                TestItems.Add(accountInfo);
            }
        }

        private AccountInfo _testItem;
        public AccountInfo TestItem
        {
            get { return _testItem; }
            set { SetProperty(ref _testItem, value); }
        }

        private IList _testItems;
        public IList TestItems
        {
            get { return _testItems; }
            set { SetProperty(ref _testItems, value); }
        }

        private bool _isReadOnly = false;
        public bool PropertyIsReadOnly
        {
            get { return _isReadOnly; }
            set { SetProperty(ref _isReadOnly, value); }
        }
        private ZFormButtonStyle _searchButtonStyle = ZFormButtonStyle.InfoButton;
        public ZFormButtonStyle ButtonStyle
        {
            get { return _searchButtonStyle; }
            set { SetProperty(ref _searchButtonStyle, value); }
        }

        public RelayCommand CommandChangeSearchButtonStyle => new RelayCommand(ChangeSearchButtonStyle);
        private void ChangeSearchButtonStyle()
        {
            Random random = new Random();
            switch (random.Next(0, 5))
            {
                case 0:
                    ButtonStyle = ZFormButtonStyle.DefaultButton;
                    break;
                case 1:
                    ButtonStyle = ZFormButtonStyle.InfoButton;
                    break;
                case 2:
                    ButtonStyle = ZFormButtonStyle.WarnButton;
                    break;
                case 3:
                    ButtonStyle = ZFormButtonStyle.ErrorButton;
                    break;
                case 4:
                    ButtonStyle = ZFormButtonStyle.SuccessButton;
                    break;
                default:
                    break;
            }
        }
        public RelayCommand CommandChangeReadOnly => new RelayCommand(ChangeReadOnly);
        private void ChangeReadOnly()
        {
            PropertyIsReadOnly = !PropertyIsReadOnly;
        }
        public RelayCommand CommandChangeItemsSource => new RelayCommand(ChangeItemsSource);
        private void ChangeItemsSource()
        {
            TestItems = new ObservableCollection<AccountInfoExt>();
            AccountInfoExt accountInfo = new AccountInfoExt();
            accountInfo.NO = 1;
            accountInfo.Phone = "12345678901";
            accountInfo.Username = "管理员账号";
            accountInfo.ArchivesPath = "D:\\admin\\admin.ad";
            accountInfo.Role = accountInfo.Roles.FirstOrDefault(r => r == "系统管理员");
            accountInfo.Permission.ForEach(permission => permission.IsChecked = true);
            TestItems.Add(accountInfo);
            for (int i = 0; i < 10000; i++)
            {
                accountInfo = new AccountInfoExt();
                accountInfo.NO = i + 2;
                accountInfo.Phone = CommonUtils.GenerateRandomPhoneNumber();
                accountInfo.Username = CommonUtils.GenerateRandomName();
                accountInfo.ArchivesPath = "D:\\admin\\admin.ad";
                accountInfo.Role = accountInfo.Roles.FirstOrDefault(r => r == "员工");
                accountInfo.Permission.ForEach(permission => permission.IsChecked = true);
                TestItems.Add(accountInfo);
            }
        }
        public RelayCommand CommandViewSelectedItem => new RelayCommand(ViewSelectedItem);
        private void ViewSelectedItem()
        {
            string msg = FormItemUtils.Print(TestItem);
            MessageBox.Show(msg, "属性信息", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
