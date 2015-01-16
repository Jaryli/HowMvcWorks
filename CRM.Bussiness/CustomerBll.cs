using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Dao;
using CRM.Model;
namespace CRM.Bussiness
{
    public class CustomerBll
    {
        private CustomerDal dal = new CustomerDal();
        public List<Customer> getAll()
        {
            return dal.GetAll();
        }
        public bool Add(Customer customer)
        {
            return dal.Add(customer);
        }
    }
}
