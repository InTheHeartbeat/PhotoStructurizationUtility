using System;
using System.Collections.Generic;

namespace PhotoStructurizationUtility.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        IList<T> GetAll();
        T GetById(Guid id);
        bool Add(T item);
        bool Remove(T item);
        bool Remove(Guid id);
        bool Update(T item);
    }
}