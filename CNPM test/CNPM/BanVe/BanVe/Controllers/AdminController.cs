using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BanVe.Models;

namespace BanVe.Controllers
{
    public class AdminController : Controller
    {
        ContextCS cs = new ContextCS();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Adminlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adminlogin(AdminLogic logic)
        {
            var x = cs.AdminLogics.Where(a => a.AdName == logic.AdName && a.Password == logic.Password).ToList();
            if(x != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.m = "Sai tài khoản hoặc mật khẩu";
            }
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}