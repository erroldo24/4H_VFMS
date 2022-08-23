using _4H_VFMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4H_VFMS.Controllers
{
    public class HomeController : Controller
    {
        private VFMS_DBEntities db = new VFMS_DBEntities();
        public ActionResult Index()
        {
            ViewBag.userCount = db.tblUserLists.ToList().Where(u => u.deleteFlag != "Yes").Count() + 0;
            ViewBag.driverCount = db.tblDriverLists.ToList().Where(d => d.deleteFlag != "Yes").Count() + 0;
            ViewBag.vehicleCount = db.tblVehicleLists.ToList().Where(v => v.deleteFlag != "Yes").Count() + 0;
            ViewBag.vAssignCount = db.tblVehicleAssignments.ToList().Where(a => a.vMileageTravelled == 0).Count() + 0;

            return View();
        }

    }
}