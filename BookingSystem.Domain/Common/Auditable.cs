using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Common
{
    //This class is used to track the creation and modification of records in the database. 
    //It is inherited by all entities in the domain.
    public class Auditable
    {

        public DateTime Created { get; set; }
        public string ? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }

        public string ? LastModifiedBy { get; set; } 
    }
}
