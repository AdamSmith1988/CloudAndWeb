using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using CFEDModel;
using ICA1Task1.Models;

namespace ICA1Task1.Controllers
{
    public class MasterController : Controller
    {
        // all info from the database db
        private CFEDModel.CodeFirstExDb db = new CFEDModel.CodeFirstExDb();


        // GET: Master
        public ActionResult Index()
        {
            BusinessUnitRep myRep = new BusinessUnitRep(); //creates an instance (myRep) of the BUrep class in which its set to display all active BU's. 
                var activeBu = myRep.All(); //create variable activebu to get all items from myRep.
                    return View(activeBu); //this is to display items within activeBu.
        }

        // GET: Master/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var staff = db.Staffs.Where(b => b.businessUnitId == id); //Display all staff members under selected BU ID.
                    return View(staff);//return variable staff getting.

            }
            catch
            {
                return HttpNotFound();//otherwise send error. 
            }
        }

        //// GET: Master/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Master/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Master/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Master/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Master/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Master/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
