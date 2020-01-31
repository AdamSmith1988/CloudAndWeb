using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ICATask4.Models;
using ICATask4.SkillService;
using StaffSkillModel;

namespace ICATask4.Controllers
{
    public class StaffController : Controller
    {
        private StaffSkillModel.StaffSkillModel1 skill = new StaffSkillModel.StaffSkillModel1(); //connecting to the Database.(n3276931skillStaff)
        private SkillService.SkillServiceClient SkillClient = new SkillService.SkillServiceClient(); // creating a new WCF client at url (h ttp://skillservice.azurewebsites.net/SkillService.svc)

        public ActionResult Index(string buCode)
        {
            HttpClient sClient = new HttpClient(); // getting a new HTTPClient
                sClient.BaseAddress = new System.Uri("http://localhost:33103/");// getting the url to local host task 2.
                    sClient.DefaultRequestHeaders.Accept.ParseAdd("application/json");
                        HttpResponseMessage response = sClient.GetAsync("api/Staff/BusinessUnit/" + buCode).Result;//HTTPresponse getting the data from url.
           if (response.IsSuccessStatusCode) //if the response is a sucess
            {
                var staff = response.Content.ReadAsAsync<IEnumerable<staffDto>>().Result;// create variable staff to get data from staffDto
                    return View(staff);//return staff.

            }
            return View();
        }


        public ActionResult Skills(string StaffCode)
        {
            var thisStaffSkills = skill.StaffSkills.Where(s => s.StaffCode == StaffCode).ToList(); //created variable thisStaffSkills which gets a skill assigned with a certain StaffCode(Staff member)
                var vm = thisStaffSkills.Select(c => new StaffSkillModel.StaffSkill // created variable vm which assigns staff skills to certain staff codes (staff members)
            {
                SkillCode = c.SkillCode,
                StaffCode = c.StaffCode
            }).ToList();

            return View(vm); // return vm


        }

        public ActionResult AddSkill(string StaffCode)
        {
            var skills = SkillClient.GetAllSkills(); //created variable skills to connect to the WCF client and get all skills.
                var allSkillsCode = (from s in skills select s.skillCode).ToList(); //variable allSkillsCode containing all skills in the WCF client. 
                    var thisStaffSkillsCode = (from s in skill.StaffSkills where s.StaffCode == StaffCode select s.SkillCode).ToList(); // variable thisStaffSkillsCode lists a staff members skill codes.
                        var yetToHave = allSkillsCode.Except(thisStaffSkillsCode); // variable yetToHave lists skills left to go on the members skill list.
                            List<skillVM> list = buildSkillList(skills, yetToHave); //
                                ViewBag.skillCode = new SelectList(list, "skillCode", "skillDescription");// this created a clickable dropdown list containing all skillCodes / skillDescriptions
                                    var model = new StaffSkillModel.StaffSkill(); //variable model creating a new instance of the StaffSkillModel
            return View("AddSkill", model); //return the newly created model in the view. 
        }

        private List<skillVM> buildSkillList(SkillsDTO[] skills, IEnumerable<string> yetToHave) //Visual Studio self made method by right clicking on  buildSkillList and create method.
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult AddSkill(StaffSkillModel.StaffSkill model)
        {
            skill.StaffSkills.Add(model); // adding all new skills to the model 
                skill.SaveChanges();    // save the changes. 

            return RedirectToAction("Skills", new {StaffCode = model.StaffCode}); //return to the view 
        }
    }
}
