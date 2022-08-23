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
    public class tblDriverListsController : Controller
    {
        private VFMS_DBEntities db = new VFMS_DBEntities();

        // GET: tblDriverLists
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

            var users = from u in db.tblDriverLists.Where(x => x.deleteFlag != "Yes")
                        select u;

            //Searching 
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.dLastName.Contains(searchString)
                                       || u.dFirstName.Contains(searchString)
                                       || u.dLicense.Contains(searchString));
            }
            //Sorting
            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(u => u.dLastName);
                    break;
                case "Date":
                    users = users.OrderBy(u => u.position);
                    break;
                case "date_desc":
                    users = users.OrderByDescending(u => u.dateCreated);
                    break;
                default:
                    users = users.OrderBy(u => u.dLastName);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            //Counts the # of drivers
            ViewBag.driverCount = db.tblDriverLists.ToList().Count() + 0;

            return View(users.ToPagedList(pageNumber, pageSize));
        }

        // GET: tblDriverLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDriverList tblDriverList = db.tblDriverLists.Find(id);
            if (tblDriverList == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DetailsDriver", tblDriverList);
        }

        // GET: tblDriverLists/Create
        public ActionResult Create()
        {
            ViewBag.dGender = new SelectList(db.genders, "Id", "gender1");
            ViewBag.dPosition = new SelectList((from d in db.positions.Where(d => d.position1 == "Driver")
                                                select new
                                                {
                                                    dId = d.Id,
                                                    name = d.position1
                                                }),
                                                   "dId",
                                                   "name",
                                                   null);
            ViewBag.dTitle = new SelectList(db.titles, "Id", "title1");
            return PartialView("_CreateDriver");
        }

        // POST: tblDriverLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,dFirstName,dLastName,dGender,dPosition,dTitle,dLicense,dLicenseExpiry,createdBy,dateCreated,updatedBy,dateUpdated,deletedBy,deleteFlag,dateDeleted")] tblDriverList tblDriverList)
        {
            if (ModelState.IsValid)
            {
                tblDriverList.createdBy = FullName();
                tblDriverList.dateCreated = DateTime.Now;
                tblDriverList.dStatus = "Yes";

                db.tblDriverLists.Add(tblDriverList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dGender = new SelectList(db.genders, "Id", "gender1", tblDriverList.dGender);
            ViewBag.dPosition = new SelectList((from d in db.positions.Where(d => d.position1 == "Driver")
                                                select new
                                                {
                                                    dId = d.Id,
                                                    name = d.position1
                                                }),
                                                   "dId",
                                                   "name",
                                                   null);
            ViewBag.dTitle = new SelectList(db.titles, "Id", "title1", tblDriverList.dTitle);
            return RedirectToAction("Index", "tblDriverLists");
        }

        // GET: tblDriverLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDriverList tblDriverList = db.tblDriverLists.Find(id);
            if (tblDriverList == null)
            {
                return HttpNotFound();
            }
            ViewBag.dGender = new SelectList(db.genders, "Id", "gender1", tblDriverList.dGender);
            ViewBag.dPosition = new SelectList(db.positions, "Id", "position1", tblDriverList.dPosition);
            ViewBag.dTitle = new SelectList(db.titles, "Id", "title1", tblDriverList.dTitle);
            return PartialView("_EditDriver", tblDriverList);
        }

        // POST: tblDriverLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dFirstName,dLastName,dGender,dPosition,dTitle,dLicense,dLicenseExpiry,createdBy,dateCreated,updatedBy,dateUpdated,deletedBy,deleteFlag,dateDeleted")] tblDriverList tblDriverList)
        {
            if (ModelState.IsValid)
            {
                tblDriverList.updatedBy = FullName();
                tblDriverList.dateUpdated = DateTime.Now;

                db.Entry(tblDriverList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dGender = new SelectList(db.genders, "Id", "gender1", tblDriverList.dGender);
            ViewBag.dPosition = new SelectList(db.positions, "Id", "position1", tblDriverList.dPosition);
            ViewBag.dTitle = new SelectList(db.titles, "Id", "title1", tblDriverList.dTitle);
            return RedirectToAction("Index", "tblDriverLists");
        }

        // GET: tblDriverLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblDriverList tblDriverList = db.tblDriverLists.Find(id);
            if (tblDriverList == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DeleteDriver", tblDriverList);
        }

        // POST: tblDriverLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblDriverList tblDriverList = db.tblDriverLists.Find(id);
            tblDriverList.deletedBy = FullName();
            tblDriverList.dateDeleted = DateTime.Now;
            tblDriverList.deleteFlag = "Yes";

            //db.tblDriverLists.Remove(tblDriverList);
            db.Entry(tblDriverList).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "tblDriverLists");
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
