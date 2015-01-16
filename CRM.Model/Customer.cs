using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CRM.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Birthday { get; set; }
        public DateTime JoinDate { get; set; }
        [MaxLength(50)]
        public string Remark { get; set; }
    }
}
