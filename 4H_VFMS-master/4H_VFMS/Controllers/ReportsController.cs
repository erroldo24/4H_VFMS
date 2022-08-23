using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _4H_VFMS.Models;
using PagedList;

namespace _4H_VFMS.Controllers
{
    public class ReportsController : Controller
    {
        private VFMS_DBEntities db = new VFMS_DBEntities();

        // GET: Reports
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var vAssign = from v in db.tblVehicleAssignments.Include(t => t.tblDriverList).Include(t => t.tblVehicleList)
                          select v;

            //Searching 
            if (!String.IsNullOrEmpty(searchString))
            {
                vAssign = vAssign.Where(v => v.tblDriverList.dLicense.Contains(searchString)
                                       || v.tblVehicleList.vLicPlate.Contains(searchString));
            }
            //Sorting
            switch (sortOrder)
            {
                case "name_desc":
                    vAssign = vAssign.OrderByDescending(v => v.tblDriverList.dLastName);
                    break;
                case "Date":
                    vAssign = vAssign.OrderBy(v => v.vAssignOutDate);
                    break;
                case "date_desc":
                    vAssign = vAssign.OrderByDescending(v => v.dateCreated);
                    break;
                default:
                    vAssign = vAssign.OrderBy(v => v.tblDriverList.dLastName);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            //Counts the # of Assign Vehicle
            ViewBag.vAssignCount = vAssign.ToList().Count() + 0;
            //Search count
            ViewBag.vCountSearch = vAssign.Where(v => v.tblDriverList.dLicense.Contains(searchString)
                                       || v.tblVehicleList.vLicPlate.Contains(searchString)).ToList().Count();


            return View(vAssign.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVehicleAssignment tblVehicleAssignment = db.tblVehicleAssignments.Find(id);
            if (tblVehicleAssignment == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DetailsAssignment", tblVehicleAssignment);
        }

    }
}
