using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Service
{
    /// <summary>
    /// Base service interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<T> where T : class
    {
        T GetById(int id);

        void Insert(T model);

        void Update(T model);

        void Delete(T model);

        void DeleteById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetMany(Expression<Func<T, bool>> filter);

        int Save();

    }
}
