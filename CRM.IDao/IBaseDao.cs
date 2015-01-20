using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.IDao
{
    public interface IRepository
    {
        bool Add(CRM.Model.OrderItem item);
        bool Update(CRM.Model.OrderItem item);
        List<CRM.Model.OrderItem> GetList();
    }
}
