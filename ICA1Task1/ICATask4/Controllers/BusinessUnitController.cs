using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using StaffSkillModel;

namespace ICATask4.Controllers
{
    public class BusinessUnitController : Controller
    {
        StaffSkillModel.StaffSkill db = new StaffSkillModel.StaffSkill(); //creating connecting to db.
        public ActionResult Index()
        {
            HttpClient buClient = new HttpClient();
            buClient.BaseAddress = new System.Uri("http://localhost:33103/"); // getting the url to local host task 2.
            buClient.DefaultRequestHeaders.Accept.ParseAdd("application/json"); //pasring the dada into json
            HttpResponseMessage response = buClient.GetAsync("api/BusinessUnit").Result; //getting the businessunit data as a response
            if (response.IsSuccessStatusCode) //if the response is a success
            {
                var bu = response.Content.ReadAsAsync<IEnumerable<ICATask4.Controllers.buDto>>().Result; // variable bu getting the response as async from the data in buDto
                return View(bu); //return the bu
            }
            return View();
        }

        

    }
}
