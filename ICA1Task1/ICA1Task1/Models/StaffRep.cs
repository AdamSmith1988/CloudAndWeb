
using System.Collections.Generic;
using System.Linq;
using CFEDModel;

namespace ICA1Task1.Models
{
    public class StaffRep
    {
         private CodeFirstExDb db = new CodeFirstExDb();

        public IEnumerable<CFEDModel.Staff> All()
        {
            return db.Staffs.Where(b => b.Active.Equals(true));
        }
    }
}