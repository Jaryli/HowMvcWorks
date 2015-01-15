using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.IDao
{
    public interface ICustomer<TEntity>
    where TEntity : class,new()
    {

        void Add(TEntity entity);

        TEntity GetByKey(int id);

        IEnumerable<TEntity> FindBySpecification(Func<TEntity, bool> spec);

        void Remove(TEntity entity);

        void Update(TEntity entity);

    }
}
