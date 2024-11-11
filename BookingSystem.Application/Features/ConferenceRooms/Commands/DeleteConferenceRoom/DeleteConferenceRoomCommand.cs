using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Commands.DeleteConferenceRoom
{
    public class DeleteConferenceRoomCommand : IRequest<Unit>
    {
        public Guid ConferenceRoomId { get;  set; }
    }
}
