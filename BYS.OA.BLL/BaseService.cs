using BYS.OA.DALFactory;
using BYS.OA.IDal;
using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BYS.OA.BLL
{
    public abstract class BaseService<T> where T:class,new ()
    {
        /// <summary>
        /// 父类要逼迫子类在父类的方法调用之前先给父类的一个属性赋值
        /// </summary>
        public IBaseDal<T> CurrentDal { get; set; }
        public IDbSession dbSession 
        {
            get;set;
        } 
        //public BaseService(IDbSession dbSession) //基类的构造函数
        //{
        //    this.dbSession = dbSession;
        //    SetCurrentDal();//抽象方法
        //}
        //public abstract void SetCurrentDal();//抽象方法要求子类必须实现
        
        #region 查询

        public IQueryable<T> GetEntities(Expression<Func<T, bool>> whereLambda) 
        {
            return CurrentDal.GetEntities(whereLambda);
        }

        public IQueryable<T> GetPageEntities<S>(int pageSiae, int pageIndex, out int total, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, bool isAsc) 
        {
            return CurrentDal.GetPageEntities(pageSiae,pageIndex,out total,whereLambda,orderByLambda,isAsc);
        }
        #endregion

        #region Create
        public T Add(T entity) 
        {
            CurrentDal.Add(entity);
            dbSession.SaveChanges();
            return entity;
        }

        public bool Update(T entity) 
        {
            CurrentDal.Update(entity);
            return dbSession.SaveChanges()>0;
        }

        public bool Delete(T entity) 
        {
            CurrentDal.Delete(entity);
            return dbSession.SaveChanges() > 0;
        }


        #endregion

    }
}
