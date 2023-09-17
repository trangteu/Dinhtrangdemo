using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCuaHangHoaQua.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            if (Session["USER_SESSION"] == null && Session["SESSION_GROUP"] == null)
            {
                return Redirect("~/Admin/Login");
            }
            return View();
        }
    }
}