using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Rooms;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.ConferenceRooms
{
    public partial class AddConferenceRoomModal
    {

        [Parameter]
        public EventCallback OnValidResponse { get; set; }

        [Inject]
        public IConferenceRoomService ConferenceRoomService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } 
        public RoomViewModel Room { get; set; }
        public string Message { get; set; }

        public bool HideButton = false;
        public bool ShowToast = false;
        protected override void OnInitialized()
        {
            Room = new RoomViewModel();
        }
        protected async Task HandleValidSubmit()
        {
            var response = await ConferenceRoomService.CreateConferenceRoomAsync(Room);
            HandleResponse(response);
        }

        private async void HandleResponse(ApiResponse<Guid> response)
        {
            if(response.IsSuccess)
            {
                Message = response.Message;
                HideButton = true;
                ShowToast = true;
                Room = new RoomViewModel();
                await OnValidResponse.InvokeAsync();
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
        private void CloseModal()
        {
            HideButton = false;
            ShowToast = false;
        }
    }
}
