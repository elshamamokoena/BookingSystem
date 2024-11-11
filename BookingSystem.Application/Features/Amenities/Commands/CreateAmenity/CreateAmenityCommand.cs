using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Commands.CreateAmenity
{
    public class CreateAmenityCommand:IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid AmenityCategoryId { get; set; }
        public Guid ? ConferenceRoomId { get; set; }
    }
}
