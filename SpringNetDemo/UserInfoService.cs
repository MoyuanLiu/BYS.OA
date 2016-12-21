using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDemo
{
    public class UserInfoService
    {
        public IUserInfoDal UserInfoDal { get; set; }
        public void Show()
        {
            Console.WriteLine("UserInfoService  ");
            UserInfoDal.Show();
        }
    }
}
