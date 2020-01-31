using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.UI.WebControls;
using CFEDModel;
using ICATask2.Models;

namespace ICATask2.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BusinessUnitController : ApiController
    {
       private CFEDModel.CodeFirstExDb db = new CFEDModel.CodeFirstExDb(); //connecting to the database db.
        /// <summary>
        /// 'Get'ting all information from BUDto
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.BUDto> Get()
        {
            var businessUnits = db.BusinessUnits.Select(businessUnit => new Models.BUDto //select bu from db
            {
                    businessUnitCode = businessUnit.businessUnitCode, // getting the string from the Dto
                        title = businessUnit.title// getting the string from the Dto
            });
           
            return businessUnits; //return the BusinessUnits
        }

        /// <summary>
        /// 'Get'ting all information from BUDto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Models.BUDto Get(int id)
        {
            var businessUnits = db.BusinessUnits; //variable businessUnits is db.BU
                CFEDModel.BusinessUnit bUnits = businessUnits.SingleOrDefault(b => b.businessUnitId == id);
           
                var buDetails = new BUDto // created variable budetails to get relevant information from BUDTO class. 
                {
                    businessUnitCode = bUnits.businessUnitCode, //Specify relevant BUCode.
                    title = bUnits.title //Specify relevant BU title.
                };
            return buDetails; //return variable buDetails.

        }
    }
} 
       
    

