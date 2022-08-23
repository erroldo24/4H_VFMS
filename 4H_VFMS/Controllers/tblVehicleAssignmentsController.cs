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
    public class tblVehicleAssignmentsController : Controller
    {
        private VFMS_DBEntities db = new VFMS_DBEntities();

        // GET: tblVehicleAssignments
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

            var vAssign = from v in db.tblVehicleAssignments.Include(t => t.tblDriverList).Include(t => t.tblVehicleList).Where(a => a.vMileageTravelled == 0)
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

            return View(vAssign.ToPagedList(pageNumber, pageSize));
        }

        // GET: tblVehicleAssignments/Details/5
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

        // GET: tblVehicleAssignments/Create
        public ActionResult Create()
        {

            ViewBag.dId = new SelectList((from d in db.tblDriverLists.ToList().Where(d => d.dStatus == "Yes")
                                          select new
                                          {
                                              dId = d.Id,
                                              FullName = d.dFirstName + " " + d.dLastName + " - " + d.dLicense
                                          }),
                                           "dId",
                                           "FullName",
                                           null);
            ViewBag.vId = new SelectList((from v in db.tblVehicleLists.ToList().Where(v => v.vStatu.vStatus == "Yes")
                                          select new
                                          {
                                              vId = v.Id,
                                              FullName = v.vType1.vType1 + " - " + v.vLicPlate
                                          }),
                                           "vId",
                                           "FullName",
                                           null);
            //ViewBag.dId = new SelectList(db.tblDriverLists, "Id", "dLicense");
            //ViewBag.vId = new SelectList(db.tblVehicleLists, "Id", "vLicPlate");
            return PartialView("_CreateAssignment");
        }

        // POST: tblVehicleAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,dId,vId,vAssignOutDate,vAssignDuration,vAssignInDate,vAssignUsed,vMileageOut,vMileageIn,vMileageTravelled,createdBy,dateCreated,updatedBy,dateUpdated")] tblVehicleAssignment tblVehicleAssignment)
        {
            if (ModelState.IsValid)
            {
                //Current date 
                var currentDate = DateTime.Now;
                //Get list of vehicles
                var vehicleToAssign = db.tblVehicleLists.ToList();

                tblVehicleAssignment.vAssignOutDate = currentDate;
                tblVehicleAssignment.vMileageTravelled = 0;
                tblVehicleAssignment.dateCreated = currentDate;
                tblVehicleAssignment.createdBy = FullName();

                //Getting assign vehicle Id
                var assignVid = tblVehicleAssignment.vId;
                //Getting vehicle based on Id
                var getVehicle = vehicleToAssign.SingleOrDefault(c => c.Id == assignVid);

                //Setting values for vehicle
                getVehicle.dateUpdated = currentDate;
                getVehicle.vStatus = 2;
                //-------------------------------------------------------------//
                //Get list of drivers
                var driverToAssign = db.tblDriverLists.ToList();
                //Getting assign driver Id
                var assignDriverId = tblVehicleAssignment.dId;
                //Gettting driver based on Id
                var getDriver = driverToAssign.SingleOrDefault(d => d.Id == assignDriverId);
                //Setting values for driver
                getDriver.dateUpdated = currentDate;
                getDriver.dStatus = "No";       


                db.tblVehicleLists.Add(getVehicle);
                db.tblDriverLists.Add(getDriver);
                db.Entry(getVehicle).State = EntityState.Modified;
                db.Entry(getDriver).State = EntityState.Modified;
                db.tblVehicleAssignments.Add(tblVehicleAssignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dId = new SelectList((from d in db.tblDriverLists.ToList()
                                          select new
                                          {
                                              dId = d.Id,
                                              FullName = d.dFirstName + " " + d.dLastName
                                          }),
                                            "dId",
                                            "FullName",
                                            null);
            ViewBag.vId = new SelectList((from v in db.tblVehicleLists.ToList()
                                          select new
                                          {
                                              vId = v.Id,
                                              FullName = v.vType1.vType1 + " - " + v.vLicPlate
                                          }),
                                           "vId",
                                           "FullName",
                                           null);
            //ViewBag.dId = new SelectList(db.tblDriverLists, "Id", "dLicense", tblVehicleAssignment.dId);
            //ViewBag.vId = new SelectList(db.tblVehicleLists, "Id", "vLicPlate", tblVehicleAssignment.vId);
            return RedirectToAction("Index", "tblVehicleAssignments");
        }

        // GET: tblVehicleAssignments/Edit/5
        public ActionResult Edit(int? id)
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
            
            ViewBag.dId = new SelectList(db.tblDriverLists, "Id", "dLicense", tblVehicleAssignment.dId);
            ViewBag.vId = new SelectList(db.tblVehicleLists, "Id", "vLicPlate", tblVehicleAssignment.vId);
            return PartialView("_EditAssignment", tblVehicleAssignment);
        }

        // POST: tblVehicleAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,dId,vId,vAssignOutDate,vAssignDuration,vAssignInDate,vAssignUsed,vMileageOut,vMileageIn,vMileageTravelled,createdBy,dateCreated,updatedBy,dateUpdated")] tblVehicleAssignment tblVehicleAssignment)
        {
            if (ModelState.IsValid)
            {
                //Current date 
                var currentDate = DateTime.Now;

                //Creating vehicle
                var vehicleToAssign = db.tblVehicleLists.ToList();

                //Setting Vehicle Id
                var assignVid = tblVehicleAssignment.vId;
                //Getting vehicle based on Id
                var getVehicle = vehicleToAssign.Single(c => c.Id == assignVid);

                //Setting values for vehicle                
                getVehicle.vStatus = 1;

                //Setting vehicle signin date
                tblVehicleAssignment.vAssignInDate = currentDate;
                tblVehicleAssignment.dateUpdated = currentDate;
                tblVehicleAssignment.updatedBy = FullName();

                //MileageTravlelled Calculation
                var mOut = tblVehicleAssignment.vMileageOut;
                var mIn = tblVehicleAssignment.vMileageIn;
                var tMileage = mIn - mOut;
                tblVehicleAssignment.vMileageTravelled = tMileage;

                //-------------------------------------------------------------//
                //Get list of drivers
                var driverToAssign = db.tblDriverLists.ToList();
                //Getting assign driver Id
                var assignDriverId = tblVehicleAssignment.dId;
                //Gettting driver based on Id
                var getDriver = driverToAssign.Single(d => d.Id == assignDriverId);
                //Setting values for driver
                getDriver.dateUpdated = currentDate;
                getDriver.dStatus = "Yes";


                db.tblVehicleLists.Add(getVehicle);
                db.tblDriverLists.Add(getDriver);
                db.Entry(getVehicle).State = EntityState.Modified;
                db.Entry(getDriver).State = EntityState.Modified;
                db.Entry(tblVehicleAssignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.dId = new SelectList((from d in db.tblDriverLists.ToList()
            //                              select new
            //                              {
            //                                  dId = d.Id,
            //                                  FullName = d.dFirstName + " " + d.dLastName + " - " + d.dLicense
            //                              }),
            //                                "dId",
            //                                "FullName",
            //                                null);
            //ViewBag.vId = new SelectList((from v in db.tblVehicleLists.ToList()
            //                              select new
            //                              {
            //                                  vId = v.Id,
            //                                  FullName = v.vType1.vType1 + " - " + v.vLicPlate
            //                              }),
            //                               "vId",
            //                               "FullName",
            //                               null);
            ViewBag.dId = new SelectList(db.tblDriverLists, "Id", "dLicense", tblVehicleAssignment.dId);
            ViewBag.vId = new SelectList(db.tblVehicleLists, "Id", "vLicPlate", tblVehicleAssignment.vId);
            return RedirectToAction("Index", "tblVehicleAssignments");
        }

        // GET: tblVehicleAssignments/Delete/5
        public ActionResult Delete(int? id)
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
            return PartialView("_DeleteAssignment", tblVehicleAssignment);
        }

        // POST: tblVehicleAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVehicleAssignment tblVehicleAssignment = db.tblVehicleAssignments.Find(id);

            db.tblVehicleAssignments.Remove(tblVehicleAssignment);
            db.SaveChanges();
            return RedirectToAction("Index", "tblVehicleAssignments");
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
