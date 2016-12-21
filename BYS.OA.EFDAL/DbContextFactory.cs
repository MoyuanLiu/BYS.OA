using BYS.OA.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BYS.OA.EFDAL
{
    public class DbContextFactory
    {
        public static DbContext GetCurrentDbContext() 
        {
            //一次请求公用一个实例，上下文也可以切换
            //return new DataModelContainer();
            DbContext db = CallContext.GetData("DbContext") as DbContext;
            if(db==null)
            {
                db = new DataModelContainer();
                CallContext.SetData("DbContext",db);
            }
            return db;
        }
    }
}
