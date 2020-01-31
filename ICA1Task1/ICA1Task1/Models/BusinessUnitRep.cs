using CFEDModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace ICA1Task1.Models
{

    
    public class BusinessUnitRep
    {
        private CodeFirstExDb db = new CodeFirstExDb();

        public  IEnumerable<CFEDModel.BusinessUnit> All()
        {
            return db.BusinessUnits.Where(b => b.Active == true);
        }

    }
}