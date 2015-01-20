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
        public int OrderId { get; set; }
        public int OrderNum { get; set; }
        public double OrderMoney { get; set; }
        public string OrderRemark { get; set; }
        public DateTime OrderTime { get; set; }
    }
}
