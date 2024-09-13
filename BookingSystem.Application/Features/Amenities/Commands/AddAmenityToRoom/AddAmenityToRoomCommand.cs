using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Commands.AddAmenityToRoom
{
    public class AddAmenityToRoomCommand:IRequest<AddAmenityToRoomCommandResponse>
    {
        public Guid AmenityId { get; set; }
        public Guid RoomId { get; set; }
    }
}
