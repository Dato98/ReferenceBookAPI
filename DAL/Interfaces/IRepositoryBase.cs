using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Interfaces
{
    public interface IRepositoryBase<T>
    {
        T Get(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
