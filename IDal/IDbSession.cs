using BYS.OA.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal
{
    public interface IDbSession
    {
        IUserInfoDal UserInfoDal { get; }
        IOrderInfoDal OrderInfoDal { get; }
        int SaveChanges();
    }
}
