using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace ICATask4.Controllers
{
    public class staffDto
    {
        public string staffCode { get; set; } // to get the unique code for staff member
        public string firstName { get; set; } //get the fist name of staff member
        public string lastName { get; set; } //getting the surname of a staff member

    }
}