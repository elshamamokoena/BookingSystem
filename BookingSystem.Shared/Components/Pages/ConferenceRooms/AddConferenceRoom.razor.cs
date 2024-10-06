using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Rooms;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.ConferenceRooms
{
    public partial class AddConferenceRoom
    {
        [Inject]
        public required IConferenceRoomService ConferenceRoomService { get; set; }
        public RoomViewModel Room { get; set; } = new RoomViewModel();

        public async Task AddNewRoom()
        {
            //var response  = await ConferenceRoomService
        }
    }
}
