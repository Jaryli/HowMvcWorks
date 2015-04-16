using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Model
{
    /// <summary>
    /// 自定义Attribute
    /// </summary>
    public class CommentAttribute:Attribute
    {
        public string  CollumnName { get; set; }
        public string Alias { get; set; }
    }
}
