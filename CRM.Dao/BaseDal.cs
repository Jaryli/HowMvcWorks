using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.IDao;
using CRM.Model;
namespace CRM.Dao
{
    public abstract class BaseDal<TEntity> where TEntity : class,new()
    {
        public virtual bool Add(TEntity entity)
        {
            if (entity == null)
                return false;
            try
            {
                using (var dbContext = new CRMDbContext())
                {
                    dbContext.Set<TEntity>().Add(entity);
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
        public virtual List<TEntity> GetAll()
        {
            List<TEntity> list = new List<TEntity>();
            try
            {
                using (var dbContext = new CRMDbContext())
                {
                    list = dbContext.Set<TEntity>().ToList<TEntity>();
                    return list;
                }
            }
            catch (Exception ex)
            {
                //todo:记录log
                return null;
            }

        }
    }
}
