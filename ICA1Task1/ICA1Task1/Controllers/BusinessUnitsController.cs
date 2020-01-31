using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CFEDModel;
using ICA1Task1.Models;

namespace ICA1Task1.Controllers
{
    public class BusinessUnitsController : Controller 
    {
        
        private CFEDModel.CodeFirstExDb db = new CFEDModel.CodeFirstExDb();  // database db - this is where all of the information is kept.


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
            public ActionResult Index() //This is where all the BusinessUnits are shows. 
        {
                BusinessUnitRep myrep = new BusinessUnitRep(); //Accessing the data in repository which is all active Bisuness Units
                    var bu = myrep.All(); // Variable BU is set to get All data from myrep instance of the repository. (Which is then set to when active == true)
                        return View(bu); // return view with the parameter of bu. 
                }

      
        
        // GET: BusinessUnits/Details/5
        /// <summary>
        ///This Controller Action uses a GET Details Request with the id that the user requests. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        public ActionResult Details(int? id)
        {       //This is checking to see if the BU exists in db.
            if (id == null) //if the id is equal to null
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);// Initializes a new instance of the HttpStatusCodeResult class using httpStatusCode.BadRequest
                }
          BusinessUnit businessUnit = db.BusinessUnits.Find(id); //finding the Business units which are active and

            if (businessUnit == null || businessUnit.Active == false) //if the business unit is set to null
                {
                    return HttpNotFound(); // send the message
                }
                    return View(businessUnit);// otherwise return the BU.
        }



    // GET: BusinessUnits/Create
        /// <summary>
        /// This get request displays the form for the user to enter the details. 
        /// </summary>
        public ActionResult Create()
        {
            return View();
        }


        // POST: BusinessUnits/Create
        /// <summary>
        /// this submits the information to the db.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]

        //Create new BusinessUnit - complete all data to include ["BusinessUnitId(PK), ect ect ect ect ect etc etc"]
        public ActionResult Create(BusinessUnit businessUnit)
        {

            try
            {
                businessUnit.Active = true;  // I have set active so when its created it shows on the view.
                    db.BusinessUnits.Add(businessUnit);  //Creating a new BU within the Database.
                        db.SaveChanges();  // Save the change to the database. 


                return RedirectToAction("Index"); //After filling in the form the user is taken back to main paid (index) where all active BU's are now showing.
            }
            catch
            {
                return View(businessUnit); // reutrn the view
                

            }
           
        }

        // GET: BusinessUnits/Edit/5
        /// <summary>
        ///This Controller Action uses a Get request so the user can edit the details of a selected BU
        /// </summary>
        public ActionResult Edit(int? id)
        {
            // if ID is equal to null
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // return with error
            }
           
            BusinessUnit businessUnit = db.BusinessUnits.Find(id); // find the specified BU

            if (businessUnit == null) //if its not there
            {
                
                return HttpNotFound();//return errer
            }
            return View(businessUnit);//otherwise return to view. 
        }

        // POST: BusinessUnits/Edit/5
        /// <summary>
        /// This changes the details and saves the changes in the database.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Edit Existing BusinessUnit - complete all data to include ["BusinessUnitId(PK),etc etc etc etc etc ect etc etc etc"]
        public ActionResult Edit(CFEDModel.BusinessUnit businessUnit)
        {
           
            if (ModelState.IsValid) // tells me if any errors have been added to ModelState
            {
                businessUnit.Active = true;//setting this to true so when the BU has been edited they the active flag stays true
               
                db.Entry(businessUnit).State = EntityState.Modified; // becuase model state was valid its allowing the changes to be made to businessunit

                    db.SaveChanges(); // save changes when complete

                        return RedirectToAction("Index"); //returns to main page / Index where changes can be seen
            }

            
            return View(businessUnit); //otherwise return back to the view.
        }

        // GET: BusinessUnits/Delete/5
        /// <summary>
        /// HTTP Get Delete method doesn't delete the specified BU, it returns a view of the BU where you can submit (HttpPost) the Deletion.
        /// </summary>
        public ActionResult Delete(int id)
        {
            BusinessUnit businessUnit = db.BusinessUnits.Find(id); //finding the correct BU (id)
                if (businessUnit == null || businessUnit.Active == false) //If theres no business unit and if active is set to false. 
            {
              
                return HttpNotFound(); // return error
            }
          
            return View(businessUnit); //otherwise return to that view. 
        }

        // POST: BusinessUnits/Delete/5
        /// <summary>
        ///This now soft deletes data.
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // displays error message is not existant
            }
             
            
            BusinessUnit businessUnit = db.BusinessUnits.Find(id);// find the BU with the specified ID
                businessUnit.Active = false;
                    db.Entry(businessUnit).State = EntityState.Modified; //modify the relevant BusinessUnit
                        db.SaveChanges();//save the changes
                             return RedirectToAction("Index"); //return to the main page / Index where changes can be seen (or not seen in this case)
           }

     }

}
