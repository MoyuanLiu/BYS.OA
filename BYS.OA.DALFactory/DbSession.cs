using BYS.OA.EFDAL;
using BYS.OA.IDal;
using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYS.OA.DALFactory
{
    public class DbSession:IDbSession
    {
        #region 简单工厂或抽象工厂部分
        public IUserInfoDal UserInfoDal
        {
            get { return StaticDalFactory.GetUserInfoDal(); }
        }
        public IOrderInfoDal OrderInfoDal
        {
            get { return StaticDalFactory.GetOrderInfoDal(); }
        } 
        #endregion
        /// <summary>
        /// 拿到当前的EF上下文，然后把修改的实体进行一个整体提交
        /// </summary>
        /// <returns></returns>
        public int SaveChanges() 
        {
            return DbContextFactory.GetCurrentDbContext().SaveChanges();
        }
    }
}
