using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BYS.OA.EFDAL;
using BYS.OA.Model;
using System.Linq;

namespace BYS.OA.UnitTest.Dal
{
    [TestClass]
    public class UserInfoDalTest
    {
        [TestMethod]
        public void GetUsersTest()
        {
            //测试 获取数据的方法
            UserInfoDal dal = new UserInfoDal();
            //单元测试必须自己处理数据,不能依赖第三方数据。如果依赖数据，那么自己先创建数据，然后用完之后再清除数据
            //创建测试的数据
            for (var i = 0; i < 10;i++ )
            {
                dal.Add(new UserInfo()
                {
                    UName = i+"ssss"
                });
            }
            IQueryable<UserInfo> temp = dal.GetEntities(u=>u.UName.Contains("ss"));
            //断言
            Assert.AreEqual(true,temp.Count()>=10);
        }
    }
}
