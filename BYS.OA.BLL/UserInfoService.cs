using BYS.OA.DALFactory;
using BYS.OA.EFDAL;
using BYS.OA.IBLL;
using BYS.OA.IDal;
using BYS.OA.Model;
using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYS.OA.BLL
{
    public class UserInfoService:BaseService<UserInfo>,IUserInfoService
    {
        #region older
        //模块内搞内聚，模块间低耦合
        //变化点：1.跨数据库 2.数据库访问驱动层驱动变化
        //private IUserInfoDal UserInfoDal = StaticDalFactory.GetUserInfoDal();
        //IDbSession dbSession = new DbSession();
        //private IDbSession dbSession = DbSessionFactory.GetCurrentDbSession(); 
        #endregion

        #region old
        //public UserInfo Add(UserInfo userInfo) //UnitWork单元工作模式
        //{
        //    dbSession.UserInfoDal.Add(userInfo);

        //    dbSession.SaveChanges();//数据提交的权利从数据库访问层提到了业务逻辑层。
        //    //return UserInfoDal.Add(userInfo);
        //} 
        #endregion

        //public UserInfoService(IDbSession dbSession):base(dbSession)
        //{
        //    //this.dbSession = dbSession;
        //}
        //public override void SetCurrentDal()
        //{
        //    CurrentDal = dbSession.UserInfoDal;
        //}
    }
}
