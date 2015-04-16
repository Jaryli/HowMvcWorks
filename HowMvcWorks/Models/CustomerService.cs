using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HowMvcWorks.Models
{
    public class CustomerService : ICustomer
    {    
        public List<CRM.Model.Customer> GetAll()
        {
            return new List<CRM.Model.Customer>() {

                new CRM.Model.Customer(){ Birthday="78年", CustomerId=1, CustomerName="张珊", JoinDate=System.DateTime.Now, Remark="beizhu"},
                new CRM.Model.Customer(){Birthday="79年", CustomerId=1, CustomerName="张珊1", JoinDate=System.DateTime.Now, Remark="beizhu1"},
                new CRM.Model.Customer(){Birthday="90年", CustomerId=1, CustomerName="张珊2", JoinDate=System.DateTime.Now, Remark="beizhu2"}
            };
        }
    }
}