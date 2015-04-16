using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CRM.Model
{
    public class OrderItem
    {
        [Key]
        [Comment(CollumnName = "编号",Alias="code")]
        public int OrderId { get; set; }
        [Comment(CollumnName = "数量",Alias="num")]
        public int OrderNum { get; set; }
        [Comment(CollumnName = "金额",Alias="money")]
        public double OrderMoney { get; set; }
        [Comment(CollumnName = "备注",Alias="remark")]
        public string OrderRemark { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
