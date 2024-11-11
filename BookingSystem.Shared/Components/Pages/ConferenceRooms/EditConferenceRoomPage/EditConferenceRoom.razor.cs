using BookingSystem.ClassLibrary;
using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Rooms;
using BookingSystem.Shared.Services;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.ConferenceRooms.EditConferenceRoomPage
{
    public partial class EditConferenceRoom:CustomComponentBase
    {
        [Parameter]
        [SupplyParameterFromQuery(Name = "conferenceRoomId")]
        public string ConferenceRoomId { get; set; }
        public Guid SelectedRoomId = Guid.Empty;

        [Inject]
        public required IConferenceRoomService ConferenceRoomService { get; set; }
        [Inject]
        public required IAmenityDataService AmenityDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public RoomViewModel Room { get; set; }
        protected override async Task OnInitializedAsync()
        {
                await FetchRoom();
        }
        protected async void HandleValidSubmit()
        {
            var response = await ConferenceRoomService.UpdateConferenceRoomAsync(Room);
            HandleResponse(response);
        }

        protected void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.IsSuccess)
            {
                ShowSuccess(response.Message);
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
            
        }

        private async Task FetchRoom()
        {
            if (Guid.TryParse(ConferenceRoomId, out SelectedRoomId))
            {
                Room = await ConferenceRoomService.GetConferenceRoomAsync(SelectedRoomId, false, true);
                StateHasChanged();
            }

        }
        private async Task HandleAmenitiesChanged()
        {
            if (Guid.TryParse(ConferenceRoomId, out SelectedRoomId))
            {
            }

        }

        private void ForceReload()
        {
            NavigationManager.Refresh(forceReload:true);
        }
    }
}
