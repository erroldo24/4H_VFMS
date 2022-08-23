using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _4H_VFMS.Models;

namespace _4H_VFMS.Controllers
{
    public class LoginController : Controller
    {
        private VFMS_DBEntities db = new VFMS_DBEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorise(tblUserList user)
        {
            var userDetail = db.tblUserLists.Where(x => x.uLogin == user.uLogin &&
                                            x.uPassword == user.uPassword).FirstOrDefault();
            if (userDetail == null)
            {
                //user.LoginErrorMessage = "Invalid Username or Password";
                return View("Index", user);
            }
            else
            {
                Session["userID"] = userDetail.Id;
                Session["fName"] = userDetail.uFirstName;
                Session["lName"] = userDetail.uLastName;
                Session["position"] = userDetail.uPosition;

                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}