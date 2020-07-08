using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MJKProjectsDAL.Repos.Interfaces
{
    public interface IRepo<T>  where T : class
    {
        void Add(T model);
        T GetBy(Expression<Func<T, bool>> expression);
        List<T> List();
        List<T> OrderBy(Expression<Func<T, bool>> expression);
        bool Update(T model);        
        bool Delete(T model);        
    }
}
