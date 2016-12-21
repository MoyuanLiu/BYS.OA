using BYS.OA.EFDAL;
using BYS.OA.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BYS.OA.DALFactory
{
    public class StaticDalFactory
    {
        /// <summary>
        /// 有简单工厂转变成了抽象工厂
        /// </summary>
        public static string assemblyName = System.Configuration.ConfigurationManager.AppSettings["DalAssemblyName"];
        public static IUserInfoDal GetUserInfoDal() 
        {
            //return new UserInfoDal();
            //把上面的new去掉：希望改一个配置那么创建实例就发生变化，不需要改代码
            //HttpRuntime.Cache.Get("")
            return Assembly.Load(assemblyName).CreateInstance(assemblyName+".UserInfoDal") as IUserInfoDal;
        }
        public static IOrderInfoDal GetOrderInfoDal()
        {
            return Assembly.Load(assemblyName).CreateInstance(assemblyName + ".OrderInfoDal") as IOrderInfoDal;
        }
    }
}
