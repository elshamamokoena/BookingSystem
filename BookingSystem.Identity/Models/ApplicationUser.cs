using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Identity.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string ? Department { get; set; }
    }
}
