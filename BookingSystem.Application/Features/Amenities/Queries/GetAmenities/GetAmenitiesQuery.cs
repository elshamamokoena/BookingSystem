using BookingSystem.Domain.Entities.Amenities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Queries.GetAmenities
{
    public class GetAmenitiesQuery:IRequest<IEnumerable<AmenityListVm>>
    {
        public Guid ? ConferenceRoomId { get; set; }
        public bool ? IncludeCategory { get; set; }
        public bool ? IncludeRoom { get; set; }
    }
}
