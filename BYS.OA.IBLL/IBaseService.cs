﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BYS.OA.IBLL
{
    public interface IBaseService<T> where T:class,new()
    {
        #region 查询

        IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> GetPageEntities<S>(int pageSiae, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc);
        #endregion

        #region Create
        T Add(T entity);

        bool Update(T entity);

        bool Delete(T entity);


        #endregion
    }
}
