using BYS.OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BYS.OA.EFDAL
{
    /// <summary>
    /// 职责：封装多有的Dal的公共的crud的方法
    /// </summary>
    public class BaseDal<T> where T:class ,new()
    {
        //依赖抽象编程。好处可以应对变化的时候，改变最小
        public DbContext Db
        {
            get{return DbContextFactory.GetCurrentDbContext();}
        }
        #region 查询
        
        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda)
        {

            return Db.Set<T>().Where(whereLambda).AsQueryable();
        }
        public IQueryable<T> GetPageEntities<S>(int pageSiae, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc)
        {
            total = Db.Set<T>().Where(whereLambda).Count();
            if (isAsc)
            {
                var temp = Db.Set<T>().Where(whereLambda)
                .OrderBy<T, S>(orderByLambda)
                .Skip(pageSiae * (pageIndex - 1))
                .Take(pageSiae).AsQueryable();
                return temp;
            }
            else
            {
                var temp = Db.Set<T>().Where(whereLambda)
                .OrderByDescending<T, S>(orderByLambda)
                .Skip(pageSiae * (pageIndex - 1))
                .Take(pageSiae).AsQueryable();
                return temp;
            }

        }
        #endregion

        #region Create
        public T Add(T entity)
        {
            Db.Set<T>().Add(entity);
            //Db.SaveChanges();
            return entity;
        }
        public bool Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;

            //return Db.SaveChanges() > 0;
            return true;
        }
        public bool Delete(T entity)
        {
            Db.Entry(entity).State = EntityState.Deleted;
            //return Db.SaveChanges() > 0;
            return true;
        }

        #endregion
    }
}
