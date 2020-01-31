using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CFEDModel;

namespace ICATask2.Models
{
    public class BuREP
    {
    
        private CodeFirstExDb db = new CodeFirstExDb();

        public  IEnumerable<CFEDModel.BusinessUnit> All()
        {
            return db.BusinessUnits.Where(b => b.Active == true);
        }

    }
}