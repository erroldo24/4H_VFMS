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
    public class tblUserListsController : Controller
    {
        private VFMS_DBEntities db = new VFMS_DBEntities();

        // GET: tblUserLists
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

            var users = from u in db.tblUserLists.Where(x => x.deleteFlag != "Yes")
                        select u;

            //Searching 
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.uLastName.Contains(searchString)
                                       || u.uFirstName.Contains(searchString)
                                       || u.uTrn.Contains(searchString));
            }
            //Sorting
            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(u => u.uLastName);
                    break;
                case "Date":
                    users = users.OrderBy(u => u.position);
                    break;
                case "date_desc":
                    users = users.OrderByDescending(u => u.dateCreated);
                    break;
                default:
                    users = users.OrderBy(u => u.uLastName);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            //Counts the # of users
            ViewBag.userCount = db.tblUserLists.ToList().Where(u => u.deleteFlag != "Yes").Count() + 0;

            return View(users.ToPagedList(pageNumber, pageSize));
        }

        // GET: tblUserLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUserList tblUserList = db.tblUserLists.Find(id);
            if (tblUserList == null)
            {
                return HttpNotFound();
            }
            return PartialView("_DetailsUser", tblUserList);
        }

        // GET: tblUserLists/Create
        public ActionResult Create()
        {
            ViewBag.uGender = new SelectList(db.genders, "Id", "gender1");
            ViewBag.uPosition = new SelectList(db.positions.Where(u => u.position1 != "Driver"), "Id", "position1");
            ViewBag.uTitle = new SelectList(db.titles, "Id", "title1");
            return PartialView("_CreateUser");
        }

        // POST: tblUserLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,uFirstName,uLastName,uGender,uPosition,uLogin,uPassword,uTitle,createdBy,dateCreated,updatedBy,dateUpdated,deletedBy,deleteFlag,dateDeleted,uTrn")] tblUserList tblUserList)
        {
            if (ModelState.IsValid)
            {
                tblUserList.createdBy = FullName();
                tblUserList.dateCreated = DateTime.Now;                

                db.tblUserLists.Add(tblUserList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.uGender = new SelectList(db.genders, "Id", "gender1", tblUserList.uGender);
            ViewBag.uPosition = new SelectList(db.positions, "Id", "position1", tblUserList.uPosition);
            ViewBag.uTitle = new SelectList(db.titles, "Id", "title1", tblUserList.uTitle);
            return RedirectToAction("Index", "tblUserLists");
        }

        // GET: tblUserLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUserList tblUserList = db.tblUserLists.Find(id);
            if (tblUserList == null)
            {
                return HttpNotFound();
            }
            ViewBag.uGender = new SelectList(db.genders, "Id", "gender1", tblUserList.uGender);
            ViewBag.uPosition = new SelectList(db.positions, "Id", "position1", tblUserList.uPosition);
            ViewBag.uTitle = new SelectList(db.titles, "Id", "title1", tblUserList.uTitle);
            return PartialView("_EditUser", tblUserList);
        }

        // POST: tblUserLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,uFirstName,uLastName,uGender,uPosition,uLogin,uPassword,uTitle,createdBy,dateCreated,updatedBy,dateUpdated,deletedBy,deleteFlag,dateDeleted,uTrn")] tblUserList tblUserList)
        {
            if (ModelState.IsValid)
            {

                tblUserList.updatedBy = FullName();
                tblUserList.dateUpdated = DateTime.Now;

                db.Entry(tblUserList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.uGender = new SelectList(db.genders, "Id", "gender1", tblUserList.uGender);
            ViewBag.uPosition = new SelectList(db.positions, "Id", "position1", tblUserList.uPosition);
            ViewBag.uTitle = new SelectList(db.titles, "Id", "title1", tblUserList.uTitle);
            return RedirectToAction("Index", "tblUserLists");
        }

        // GET: tblUserLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUserList tblUserList = db.tblUserLists.Find(id);
            if (tblUserList == null)
            {
                return HttpNotFound();
            }
            return View("_DeleteUser", tblUserList);
        }

        // POST: tblUserLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblUserList tblUserList = db.tblUserLists.Find(id);

            tblUserList.deletedBy = FullName();
            tblUserList.dateDeleted = DateTime.Now;
            tblUserList.deleteFlag = "Yes";

            //db.tblUserLists.Remove(tblUserList);
            db.Entry(tblUserList).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "tblUserLists");
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
