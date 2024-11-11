using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Contracts;
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
    public partial class EditConferenceRoomAmenity : CustomComponentBase
    {
        [Parameter]
        public string AmenityId { get; set; }
        public Guid SelectedAmenityId = Guid.Empty;

        [Parameter]
        public EventCallback OnAmenityAvailabilityChanged { get; set; }
        [Inject]
        public IAmenityDataService AmenityDataService { get; set; } = default!;
        public AmenityViewModel Amenity { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Guid.TryParse(AmenityId, out SelectedAmenityId))
            {
                Amenity = await AmenityDataService.GetAmenityAsync(SelectedAmenityId, false, false);
            }
            await base.OnParametersSetAsync();
        }
        protected async void OnAmenityAvailableChanged(ChangeEventArgs args)
        {

            var response = await AmenityDataService.UpdateAmenityAsync(Amenity);
            HandleAvailabilityChangedResponse(response);
        }

        private async void HandleAvailabilityChangedResponse(ApiResponse<Guid> response)
        {
            if (response.IsSuccess)
            {
                ShowSuccess(response.Message);
                await OnAmenityAvailabilityChanged.InvokeAsync();
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
                ShowError(Message);
            }
            StateHasChanged();
        }

    
    }
}
