﻿/****************************************
 * FileName:	ZFormTextButtonItemAttribute
 * Creater: 	shaozhy
 * Create Date:	2023/8/29 9:56:48
 * Version: 	v0.0.1
 * ======================================
 * Modify: —— Version: —— Date: —— Modifier: —— Content:
 ****************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhy.Components._Enum;

namespace Zhy.Components._Attribute._ZFormItem
{
    /// <summary>
    /// 按钮选择框表单项
    /// </summary>
    public class ZFormTextButtonItemAttribute : ZFormTextItemAttribute
    {
        /// <summary>
        /// 按钮选择框表单项
        /// </summary>
        /// <param name="title">标题</param>
        public ZFormTextButtonItemAttribute(string title) : base(title) { }
        /// <summary>
        /// 中继命令属性名
        /// </summary>
        public string RelayCommandName { get; set; }
        /// <summary>
        /// 按钮内容
        /// </summary>
        public string ButtonContent { get; set; }
        /// <summary>
        /// 按钮样式
        /// </summary>
        public ZFormButtonStyle ButtonStyle { get; set; }
    }
}
