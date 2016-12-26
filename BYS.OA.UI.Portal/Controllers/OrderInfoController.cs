using BYS.OA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BYS.OA.UI.Portal.Controllers
{
    public class OrderInfoController : Controller
    {
        //
        // GET: /OrderInfo/
        public IOrderInfoService OrderInfoService { get; set; }
        //
        public ActionResult Index()
        {
            throw new Exception("dddddddd");
            ViewData.Model = OrderInfoService.GetEntities(u=>true).ToList();
            return View();
        }

    }
}
