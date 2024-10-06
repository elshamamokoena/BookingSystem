using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Rooms;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.ConferenceRooms
{
    public partial class ConferenceRoomList:BaseComponent
    {
        public IEnumerable<RoomViewModel> Rooms { get; set; } = new List<RoomViewModel>();

        protected override async Task OnInitializedAsync()
        {
            Rooms = await ConferenceRoomDataService!.GetConferenceRooms(null, null, null, 1, 20);
            await base.OnInitializedAsync();
        }
    

    }
}
