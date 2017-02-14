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
            short delNormal = (short)BYS.OA.Model.Enum.DelFlagEnum.Normal;
            var userInfo = UserInfoService.GetEntities(u => u.UName == name && u.Pwd == pwd && u.DelFlag == delNormal).FirstOrDefault();
            if (userInfo==null)
            {
                return Content("用户名或密码错误！");
            }
            Session["loginUser"] = userInfo;
            return Content("Ok");
        }
        #endregion

    }
}
