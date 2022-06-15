using System.Collections.Generic;

namespace Hospital.Repository
{
    public interface IRepositoryBase<T, in TId>
    {
        List<T> Read();
        T ReadById(TId id);
        void Create(T entity);
        void Edit(T entity);
        void Delete(TId id);
        void Write(List<T> list);
    }
}