using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Dao
{
    public class StubOrderItemDalRepository : CRM.IDao.IRepository
    {
        public bool Add(Model.OrderItem entity)
        {
            if (entity == null)
                return false;
            try
            {
                using (var dbContext = new CRMDbContext())
                {
                    dbContext.Set<Model.OrderItem>().Add(entity);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                //todo:记录log
                return false;
            }
        }

        public List<Model.OrderItem> GetList()
        {
            List<Model.OrderItem> list = new List<Model.OrderItem>();
            try
            {
                using (var dbContext = new CRMDbContext())
                {
                    list = dbContext.Set<Model.OrderItem>().ToList<Model.OrderItem>();
                    return list;
                }
            }
            catch (Exception ex)
            {
                //todo:记录log
                return null;
            }
        }


        public bool Update(Model.OrderItem item)
        {
            throw new NotImplementedException();
        }
    }
}
