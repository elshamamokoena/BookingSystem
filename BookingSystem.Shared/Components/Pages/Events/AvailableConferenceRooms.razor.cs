using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events
{
    public partial class AvailableConferenceRooms : BaseRoomComponent
    {

        protected override async Task OnInitializedAsync()
        {
            Rooms = await ConferenceRoomDataService!.GetConferenceRooms(null, null, null, 1, 20);
            await base.OnInitializedAsync();
        }

    }
}
