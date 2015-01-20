using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HowMvcWorks.Models
{
    public interface ICustomer
    {
        List<CRM.Model.Customer> GetAll();
    }
}
