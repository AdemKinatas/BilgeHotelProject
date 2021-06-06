using Business.Utilities.Results;
using Entities.Abctract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGenericService<T> where T:class,IEntity,new()
    {
        IDataResult<List<T>> GetListByFilter(Expression<Func<T, bool>> filter);
        IDataResult<List<T>> GetList();
        IDataResult<T> GetById(int id);
        IDataResult<T> GetByFilter(Expression<Func<T, bool>> filter);
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}
