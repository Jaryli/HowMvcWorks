using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace CRM.Model
{
    /// <summary>
    /// 构造导出列
    /// </summary>
    public class CollumnInfo
    {
        public string fieldName { get; set; }
        public string ColumnName { get; set; }

        public static List<CollumnInfo> getColumnList(Object t)
        {
            List<CollumnInfo> list = new List<CollumnInfo>();
            PropertyInfo[] propertys = t.GetType().GetProperties();
            object[] attributes = null;
            foreach (var item in propertys)
            {
                CollumnInfo cinfo = new CollumnInfo();
                attributes = item.GetCustomAttributes(typeof(CommentAttribute), false);
                if (attributes.Count() > 0)
                {
                    CommentAttribute ca = (CommentAttribute)attributes[0];
                    if (ca != null)
                    {
                        cinfo.ColumnName = ca.CollumnName;
                        cinfo.fieldName = item.Name;
                        list.Add(cinfo);
                    }
                }
            }
            return list;
        }
    }
}
