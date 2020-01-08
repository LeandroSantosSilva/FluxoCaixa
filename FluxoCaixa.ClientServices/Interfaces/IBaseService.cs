using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FluxoCaixa.ClientServices.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAsync();
        void GetAsync(object id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

    }
}
