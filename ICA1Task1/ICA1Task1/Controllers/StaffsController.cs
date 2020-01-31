using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CFEDModel;
using ICA1Task1.Models;

namespace ICA1Task1.Controllers
{
    public class StaffsController : Controller
    {
        private CFEDModel.CodeFirstExDb db = new CFEDModel.CodeFirstExDb();   // my database, where all of the data is.

        // GET: Staffs
        /// <summary>
        /// Displaying staff which are active
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()//This is where all the staff are shows. 
        {
            StaffRep rep = new StaffRep(); //Accessing the data in repository which is all active Bisuness Units
                var staff = rep.All(); // Variable staff is set to get All data from rep instance of the repository. (Which is then set to active == true)
                    return View(staff); // return view with the parameter of staff. 
        }
        // GET: Staffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var staff = db.Staffs.Find(id); // Creating variable staff to find a staff member with a certain id (the one the user picks.)
                if (staff == null || staff.Active == false) //if theres no such staff member
            {
                    return HttpNotFound(); //send error message
            }
                        return View(staff); //otherwise return the edited staff.


        }

        // GET: Staffs/Create
        /// <summary>
        /// get staff create page for the users to create new staff member
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {   
            BusinessUnitRep myrep = new BusinessUnitRep(); // created an instance os BUrep class which shows all active BU,s. 
                ViewBag.businessUnitId = new SelectList(myrep.All(), "businessUnitId", "businessUnitCode");//displays in a dropdown list the business units which are still active
                    return View(); //return the view
        }

       
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "staffId,businessUnitId,staffCode,firstName,middleName,lastName,dob,startDate,profile,emailAddress")] Staff staff)
        {
           try
           {
               if (ModelState.IsValid) //if model state is active/.
                   staff.Active = true; //I have set active so what sstaff are created its shows in the view .
                        db.Staffs.Add(staff); //create the bu in the database
                            db.SaveChanges(); //save the changes. 
                                return RedirectToAction("Index"); //retur nto index

           }
           catch
           {
               return View(staff); //return the view. 
           }
            
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null) //if ID is equal to null.
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //reutnr with error
            }
            Staff staff = db.Staffs.Find(id); //find the specified Staff.
            if (staff == null) // if its not hthere
            {
                return HttpNotFound();//throw error
            }
            BusinessUnitRep myrep = new BusinessUnitRep(); 
                ViewBag.businessUnitId = new SelectList(myrep.All(), "businessUnitId", "businessUnitCode", staff.businessUnitId);
                    return View(staff);//oftherwise through the view.
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CFEDModel.Staff staff)
        {
            if (ModelState.IsValid)
            {
                staff.Active = true; //setting this to true so when the person has been edited they the active flag stays true
                    db.Entry(staff).State = EntityState.Modified; // becuase model state was valid its allowing the changes to be made to staff
                        db.SaveChanges();//save the changes 
                         return RedirectToAction("Index"); //returns to main page / Index where changes can be seen
            } //View bag that contains the list of Business Units to chose from - that are active. 
            ViewBag.businessUnitId = new SelectList(db.BusinessUnits.Where(b => b.Active == true), "businessUnitId", "businessUnitCode", staff.businessUnitId);
                return View(staff); // return to view
        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(int? id)
        {
            
            Staff staff = db.Staffs.Find(id); //find the specified staff member
                if (staff == null || staff.Active == false) //If they do not exist
            {
                    return HttpNotFound(); //return as error
            }
           
            return View(staff); // return the view. 
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff staff = db.Staffs.Find(id); //find the BU with the 
                staff.Active = false; //changing active to false for soft delete
                    db.Entry(staff).State = EntityState.Modified; //mofidy the relevant staff
                        db.SaveChanges(); //save the changes
                            return RedirectToAction("Index");//return to view. 
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
