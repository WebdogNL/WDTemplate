using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WDTemplate.Models;
using Webdog.Web.Models;
using Webdog.Web.Mvc;

namespace WDTemplate.Controllers
{
    [WD, WDAUTHENTICATION, WDAUTHORIZATION(role = 0)]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var bvm = new WDBaseViewModel(this.ControllerContext);

            if (ViewBag._Article != null)
            {
                ViewBag.MenuColor = "dark";
                switch (bvm.Page.Type)
                {
                    default:
                        return View("Single", bvm);
                }
            }
            switch (bvm.Page.Type)
            {
                case (int)PageTypes.homepage:
                    //throw new NotImplementedException();
                    return View(bvm);
               
                default: break;
            }
            return View(bvm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.MenuColor = "dark";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}