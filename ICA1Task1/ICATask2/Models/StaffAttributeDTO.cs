using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICATask2.Models
{
    public class StaffAttributeDTO
    {
        public string staffCode { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public DateTime dob { get; set; }
        public DateTime startDate { get; set; }
        public string profile { get; set; }
        public string emailAddress { get; set; }
    }
}