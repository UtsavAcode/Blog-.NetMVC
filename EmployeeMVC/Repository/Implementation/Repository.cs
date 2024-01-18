using EmployeeMVC.Data;
using EmployeeMVC.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EmployeeMVC.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        internal DbSet<T> database;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            database = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _context.Add(entity);
        }

        public T FindById(Guid id)
        {
            return database.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database), "The database is null.");
            }

            IQueryable<T> query = database;

            if (query == null)
            {
                throw new InvalidOperationException("The query is null.");
            }

            return query.ToList();
        }

        public void Remove(T entity)
        {
            database.Remove(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = database;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            database.RemoveRange(entities);
        }
    }
}
