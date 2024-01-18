using System.Linq.Expressions;

namespace EmployeeMVC.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

        public T FindById(Guid id);

        T Get(Expression<Func<T, bool>> filter);
    }
}
