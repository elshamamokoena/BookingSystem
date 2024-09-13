using BookingSystem.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Commands.CreateConferenceRoom
{
    public class CreateConferenceRoomCommandResponse:BaseResponse
    {
        public CreateConferenceRoomCommandResponse():base()
        {
        }
        public CreateConferenceRoomDto ConferenceRoom { get; set; }
    }
}
