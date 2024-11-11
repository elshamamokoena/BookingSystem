using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Commands.DeleteAmenity
{
    public class DeleteAmenityCommand:IRequest<Unit>
    {
        public Guid AmenityId { get; set; }
    }
}
