using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Bookings;
using BookingSystem.Shared.Models.Rooms;
using BookingSystem.Shared.Services;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.ConferenceRooms.ConferenceRoomListComponent
{
    public partial class ConferenceRoomRow
    {
        [Inject]
        public IConferenceRoomService ConferenceRoomService { get; set; } = default!;
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;
        [Parameter]
        public RoomViewModel? Room { get; set; }
        public Guid SelectedRoomId = Guid.Empty;

        [Parameter]
        public EventCallback<bool> OnRoomDeleted { get; set; }
        [Parameter]
        public bool IsBookingMode { get; set; }

        [Parameter]
        public EventCallback<Guid> OnBookRoomSelected { get; set; }
        protected override void OnParametersSet()
        {
            if (Room is not null)
                SelectedRoomId = Room.ConferenceRoomId;

            base.OnParametersSet();
        }
      
        protected async Task HandleDelete()
        {
            var response = await ConferenceRoomService.DeleteConferenceRoomAsync(SelectedRoomId);
            HandleDeleteResponse(response);
        }

        private async void HandleDeleteResponse(ApiResponse<Guid> response)
        {
            if (response.IsSuccess)
            {
                await OnRoomDeleted.InvokeAsync(response.IsSuccess);
            }
            else
            {
                //
            }
        }
    }
}
