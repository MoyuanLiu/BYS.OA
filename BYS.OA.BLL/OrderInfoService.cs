using BYS.OA.DALFactory;
using BYS.OA.IBLL;
using BYS.OA.Model;
using IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BYS.OA.BLL
{
    public class OrderInfoService:BaseService<OrderInfo>,IOrderInfoService
    {
        //IDbSession dbSession = DbSessionFactory.GetCurrentDbSession();
        //public OrderInfo Add(OrderInfo orderInfo) //UnitWork单元工作模式
        //{
        //    dbSession.OrderInfoDal.Add(orderInfo);

        //    dbSession.SaveChanges();//数据提交的权利从数据库访问层提到了业务逻辑层。
        //    //return UserInfoDal.Add(userInfo);
        //}
        //public OrderInfoService(IDbSession dbSession):base(dbSession)
        //{
        //    //this.dbSession = dbSession;
        //}
        //public override void SetCurrentDal()
        //{
        //    CurrentDal = dbSession.OrderInfoDal;
        //}
    }
}
