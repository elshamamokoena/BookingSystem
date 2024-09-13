using BookingSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entities.Amenities
{
    public class AmenityCategory: Auditable
    {
        public Guid AmenityCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Amenity> Amenities { get; set; }
            = new List<Amenity>();
    }
}
