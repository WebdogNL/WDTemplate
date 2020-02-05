using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webdog.Web.Mvc;

namespace WDTemplate.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [AllowAnonymous, WK]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous, WK]
        public ActionResult Index(FormCollection collection)
        {
            if (!ViewBag.WellKnown)
            {
                if (!WDFunctions.RecaptchaCheck())
                {
                    ModelState.AddModelError("", "ReCAPTCHA error");
                    return View();
                }
            }

            var u = collection["username"];
            var p = collection["password"];

            var a = WDActions.WDAAccount.Login(u, p, true);
            if (a != null)
            {
                if (a.Maxrole > 0)
                {
                    Session["Account"] = a;
                    ViewBag._Account = a;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    System.Web.Security.FormsAuthentication.SignOut();
                }
            }
            ModelState.AddModelError("", "That didn't work, sorry..");
            return View();
        }

        [OverrideActionFilters, AllowAnonymous]
        public ActionResult Logoff()
        {
            foreach (string cookie in HttpContext.Request.Cookies.AllKeys)
            {
                HttpContext.Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1d);
            }

            System.Web.Security.FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }
    }
}