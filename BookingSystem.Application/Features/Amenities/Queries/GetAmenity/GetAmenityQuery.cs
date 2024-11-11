using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Queries.GetAmenity
{
    public class GetAmenityQuery : IRequest<AmenityVm>
    {
        public Guid AmenityId { get; set; }
        public bool? IncludeCategory { get; set; }
        public bool? IncludeConferenceRoom { get; set; }
    }
}
