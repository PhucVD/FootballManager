using System;
using System.Linq;
using System.Linq.Expressions;

namespace FootballManager.Data.Repository
{
    public interface IRepository<T> where T: class
    {
        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        void DeleteById(int id);

        T GetById(int id);

        IQueryable<T> GetAll();

        IQueryable<T> GetMany(Expression<Func<T, bool>> filter);

        int ExecuteCommand(string sql);
    }
}
