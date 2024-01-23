﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Zhy.Components.Wpf._Common._Converter
{
    internal class ColumnButtonConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            object? item = null;
            IList? list = null;
            if (values != null)
            {
                if (values.Length > 0)
                {
                    item = values[0];
                }
                if (values.Length > 1)
                {
                    list = values[1] as IList;
                }
            }
            return Tuple.Create(item, list);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
