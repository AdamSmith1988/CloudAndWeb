using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICATask4.Controllers
{
    public class WCFController : Controller //Created a controller specific for this piece of cose as it did not work at the bottom of the StaffController where it originally was.
    {
        
        private SkillService.SkillServiceClient SkillClient = new SkillService.SkillServiceClient();//getting tghe skill service client
        // GET: WCF
        public ActionResult ShowSkills() //an Action result to get all skills. 
        {
            var skills = SkillClient.GetAllSkills(); //Create variable skills to get all skills. 
            return View(skills); //retrun all skills. 
        }
    }
}
