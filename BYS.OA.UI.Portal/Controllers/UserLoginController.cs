using BYS.OA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BYS.OA.UI.Portal.Controllers
{
    public class UserLoginController : Controller
    {
        //
        // GET: /UserLogin/
        public IUserInfoService UserInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        #region 处理登录的表单
        public ActionResult ProcessLogin()
        {
            //验证用户名密码
            string name = Request["LoginName"];
            string pwd = Request["LoginPwd"];

        }
        #endregion

    }
}
