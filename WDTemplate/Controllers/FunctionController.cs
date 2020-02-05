using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdog.Web.Mvc;

namespace WDTemplate.Controllers
{
    public class FunctionController : Controller
    {
        // GET: Function
        // test commit
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken, WDAUTHENTICATION, WDAUTHORIZATION(role = 100)]
        public ActionResult Update(FormCollection collection)
        {
            Webdog.Web.Mvc.WDFunctions.UpdateAll();
            //Webdog.Web.Mvc.WDActions.WDASplash.GetUnSplash(false, "cornwall");
            var url = collection["source"];
            if (!string.IsNullOrEmpty(url)) { Response.Redirect(url); }
            return RedirectToAction("Index", "Home");
        }
    }
}