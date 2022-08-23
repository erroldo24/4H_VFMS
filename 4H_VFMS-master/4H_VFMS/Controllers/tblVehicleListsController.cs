using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _4H_VFMS.Models;
using PagedList.Mvc;
using PagedList;

namespace _4H_VFMS.Controllers
{
    public class tblVehicleListsController : Controller
    {
        private VFMS_DBEntities db = new VFMS_DBEntities();

        // GET: tblVehicleLists
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

            var vehicles = from u in db.tblVehicleLists.Where(x => x.deleteFlag != "Yes")
                        select u;

            //Searching 
            if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(d => d.vType1.vType1.Contains(searchString)
                                       || d.vStatu.vStatus.Contains(searchString)
                                       || d.vTransType1.vTransType1.Contains(searchString)
                                       || d.vLicPlate.Contains(searchString));
            }
            //Sorting
            switch (sortOrder)
            {
                case "name_desc":
                    vehicles = vehicles.OrderByDescending(d => d.vColour);
                    break;
                case "Date":
                    vehicles = vehicles.OrderBy(d => d.vStatus);
                    break;
                case "date_desc":
                    vehicles = vehicles.OrderByDescending(d => d.dateCreated);
                    break;
                default:
                    vehicles = vehicles.OrderBy(d => d.vType);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            //Counts the # of drivers
            ViewBag.driverCount = db.tblVehicleLists.ToList().Count() + 0;

            return View(vehicles.ToPagedList(pageNumber, pageSize));
        }

        // GET: tblVehicleLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVehicleList tblVehicleList = db.tblVehicleLists.Find(id);
            if (tblVehicleList == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DetailsVehicle", tblVehicleList);
        }

        // GET: tblVehicleLists/Create
        public ActionResult Create()
        {
            ViewBag.vColour = new SelectList(db.vColours, "Id", "vColour1");
            ViewBag.vStatus = new SelectList(db.vStatus, "Id", "vStatus");
            ViewBag.vTransType = new SelectList(db.vTransTypes, "Id", "vTransType1");
            ViewBag.vType = new SelectList(db.vTypes, "Id", "vType1");
            ViewBag.vYear = new SelectList(db.vYears, "Id", "vYear1");
            return PartialView("_CreateVehicle");
        }

        // POST: tblVehicleLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,vColour,vType,vLicPlate,vYear,vTransType,vStatus,createdBy,dateCreated,updatedBy,dateUpdated,deletedBy,deleteFlag,dateDeleted")] tblVehicleList tblVehicleList)
        {
            if (ModelState.IsValid)
            {
                tblVehicleList.createdBy = FullName();
                tblVehicleList.dateCreated = DateTime.Now;

                db.tblVehicleLists.Add(tblVehicleList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.vColour = new SelectList(db.vColours, "Id", "vColour1", tblVehicleList.vColour);
            ViewBag.vStatus = new SelectList(db.vStatus, "Id", "vStatus", tblVehicleList.vStatus);
            ViewBag.vTransType = new SelectList(db.vTransTypes, "Id", "vTransType1", tblVehicleList.vTransType);
            ViewBag.vType = new SelectList(db.vTypes, "Id", "vType1", tblVehicleList.vType);
            ViewBag.vYear = new SelectList(db.vYears, "Id", "vYear1", tblVehicleList.vYear);
            return RedirectToAction("Index", "tblVehicleLists");
        }

        // GET: tblVehicleLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVehicleList tblVehicleList = db.tblVehicleLists.Find(id);
            if (tblVehicleList == null)
            {
                return HttpNotFound();
            }
            ViewBag.vColour = new SelectList(db.vColours, "Id", "vColour1", tblVehicleList.vColour);
            ViewBag.vStatus = new SelectList(db.vStatus, "Id", "vStatus", tblVehicleList.vStatus);
            ViewBag.vTransType = new SelectList(db.vTransTypes, "Id", "vTransType1", tblVehicleList.vTransType);
            ViewBag.vType = new SelectList(db.vTypes, "Id", "vType1", tblVehicleList.vType);
            ViewBag.vYear = new SelectList(db.vYears, "Id", "vYear1", tblVehicleList.vYear);
            return PartialView("_EditVehicle", tblVehicleList);
        }

        // POST: tblVehicleLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,vColour,vType,vLicPlate,vYear,vTransType,vStatus,createdBy,dateCreated,updatedBy,dateUpdated,deletedBy,deleteFlag,dateDeleted")] tblVehicleList tblVehicleList)
        {
            if (ModelState.IsValid)
            {
                tblVehicleList.updatedBy = FullName();
                tblVehicleList.dateUpdated = DateTime.Now;

                db.Entry(tblVehicleList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.vColour = new SelectList(db.vColours, "Id", "vColour1", tblVehicleList.vColour);
            ViewBag.vStatus = new SelectList(db.vStatus, "Id", "vStatus", tblVehicleList.vStatus);
            ViewBag.vTransType = new SelectList(db.vTransTypes, "Id", "vTransType1", tblVehicleList.vTransType);
            ViewBag.vType = new SelectList(db.vTypes, "Id", "vType1", tblVehicleList.vType);
            ViewBag.vYear = new SelectList(db.vYears, "Id", "vYear1", tblVehicleList.vYear);
            return RedirectToAction("Index", "tblVehicleLists");
        }

        // GET: tblVehicleLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVehicleList tblVehicleList = db.tblVehicleLists.Find(id);
            if (tblVehicleList == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeleteVehicle", tblVehicleList);
        }

        // POST: tblVehicleLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVehicleList tblVehicleList = db.tblVehicleLists.Find(id);

            tblVehicleList.deletedBy = FullName();
            tblVehicleList.dateDeleted = DateTime.Now;
            tblVehicleList.deleteFlag = "Yes";

            //db.tblVehicleLists.Remove(tblVehicleList);
            db.Entry(tblVehicleList).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "tblVehicleLists");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public string FullName()
        {
            var fName = Session["fName"];
            var lName = Session["lName"];
            var fullName = fName + " " + lName;

            return fullName;
        }
    }
}
