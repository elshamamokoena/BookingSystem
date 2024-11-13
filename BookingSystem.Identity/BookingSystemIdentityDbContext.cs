using BookingSystem.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Identity
{
    public class BookingSystemIdentityDbContext:IdentityDbContext<ApplicationUser>
    {
        public BookingSystemIdentityDbContext(DbContextOptions<BookingSystemIdentityDbContext> options)
            : base(options)
        {
        }
    }
}
