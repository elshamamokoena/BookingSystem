using BookingSystem.ClassLibrary;
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
    public partial class RoomStatus
    {
        [CascadingParameter]
        public string ConferenceRoomId { get; set; }
        public Guid SelectedRoomId = Guid.Empty;

        [Inject]
        public IConferenceRoomService ConferenceRoomService { get; set; } = default!;
        public RoomViewModel Room { get; set; }
        public  ConferenceRoomStatus SelectedRoomStatus = default!;

        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(ConferenceRoomId, out SelectedRoomId))
            {
                Room = await ConferenceRoomService.GetConferenceRoomAsync(SelectedRoomId, false, false);
                if (Enum.TryParse(Room.Status, out ConferenceRoomStatus status))
                    SelectedRoomStatus = status;
            }
            await base.OnInitializedAsync();
        }

        private async void HandleUpdateRoomStatus(ChangeEventArgs args)
        {

            if(Enum.TryParse(args.Value.ToString(), out SelectedRoomStatus))
            {
                var isChecked = SelectedRoomStatus == ConferenceRoomStatus.BookedAndNotOccupied;
                Room.Status = SelectedRoomStatus.ToString();
                var response = await ConferenceRoomService.UpdateConferenceRoomAsync(Room);
                StateHasChanged();
            }

            //if (response.IsSuccess)
            //{
            ////    SelectedRoomStatus = Room.Status;
            //}
        }
   

    }
}
