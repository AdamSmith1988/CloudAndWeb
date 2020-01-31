using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CFEDModel;
using ICATask2.Models;

namespace ICATask2.Controllers
{
    /// <summary>
    /// This uses attribute based routing
    /// http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
    /// </summary>

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Staff")] //route of the url to get all staff.
    public class StaffController : ApiController
    {
        private CFEDModel.CodeFirstExDb allStaffdb = new CFEDModel.CodeFirstExDb(); //setting variable to get relevant staff from CFEDmodel
             private CFEDModel.CodeFirstExDb allBusinessUnitdb = new CFEDModel.CodeFirstExDb(); //setting variable to get relevant staff from CFEDmodel

             [Route("BusinessUnit/{businessUnitCode}")] //route of the URL to get a specific BU - BusinessUnit/AnSrBu for instance. 
        public IEnumerable<Models.StaffAttributeDTO> GetstaffByBu(string businessUnitCode)
        {   //gets the correct DB from the Database which is the same as the URL entered.
            CFEDModel.BusinessUnit BUnit = allBusinessUnitdb.BusinessUnits.First(b => b.businessUnitCode.Equals(businessUnitCode, StringComparison.CurrentCultureIgnoreCase));
                var StaffBu = allStaffdb.Staffs.Where(s => s.businessUnitId == BUnit.businessUnitId); //getting all staff from a specified DB.
                        var staffDetail = StaffBu.Select(staff => new StaffAttributeDTO //creating variable to get relevant information from StaffAttributsDTO class. 
            {
                staffCode = staff.staffCode,
                    firstName = staff.firstName,
                        lastName = staff.lastName
            }).AsEnumerable();

            return staffDetail; // return variable StaffDetail.
        }

        /// <summary>
        /// This is all to get the staffCofe. 
        /// </summary>
        /// <param name="staffCode"></param>
        /// <returns></returns>
        [Route("{staffCode}")] //route of the URL
        public Models.StaffAttributeDTO GetStaff(String staffCode) // get staff from the StaffAttributeDTO in models with the relevatn staffCode. 
        {
            var sName = allStaffdb.Staffs.First(s => s.staffCode.Equals(staffCode, StringComparison.CurrentCultureIgnoreCase)); //gets the correct staff member from the Database
                var staffDetail = new Models.StaffAttributeDTO //creating variable to get relevant information from StaffAttributsDTO class. 
            {
                firstName = sName.firstName,
                    lastName = sName.lastName,
                        staffCode = sName.staffCode
            };
            return staffDetail; //return variable staffDetail.
        }
    }

}





        


       
    

