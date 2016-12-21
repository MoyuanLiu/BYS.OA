using BYS.OA.BLL;
using BYS.OA.IBLL;
using BYS.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BYS.OA.UI.Portal.Controllers
{
    public class UserInfoController : Controller
    {
        //
        // GET: /UserInfo/
        //UserInfoService userInfoService = new UserInfoService();
        public IUserInfoService userInfoService { get; set; }
        public ActionResult Index()
        {
            ViewData.Model = userInfoService.GetEntities(u => true);
            return View();
        }
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserInfo userinfo) 
        {
            if(ModelState.IsValid)
            {
                userInfoService.Add(userinfo);
            }
            return RedirectToAction("Index");
        }
    }
}
