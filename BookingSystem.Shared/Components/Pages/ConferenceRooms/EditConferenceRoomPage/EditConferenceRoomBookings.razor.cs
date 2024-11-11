using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Contracts;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.ConferenceRooms.EditConferenceRoomPage
{
    public partial class EditConferenceRoomBookings:CustomComponentBase
    {
        [CascadingParameter]
        public string ConferenceRoomId { get; set; }
        public Guid SelectedConferenceRoomId { get; set; }

        [Inject]
        public IConferenceRoomService ConferenceRoomService { get; set; }
        [Inject]
        public IBookingDataService BookingService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if(Guid.TryParse(ConferenceRoomId, out Guid conferenceRoomId))
            {
                SelectedConferenceRoomId = conferenceRoomId;
            }
            else
            {
                ShowError("Invalid Conference Room Id");
            }
            await base.OnInitializedAsync();
        }
    }
}
