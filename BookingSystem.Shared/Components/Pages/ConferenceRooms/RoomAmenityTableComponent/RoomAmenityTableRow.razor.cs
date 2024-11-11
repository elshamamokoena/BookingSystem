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

namespace BookingSystem.Shared.Components.Pages.ConferenceRooms.RoomAmenityTableComponent
{
    public partial class RoomAmenityTableRow:CustomComponentBase
    {
        [Parameter]
        public AmenityViewModel Amenity { get; set; }

        public Guid SelectedAmenityId = Guid.Empty;
        [Parameter]
        public EventCallback OnDeleteAmenitySuccessful { get; set; }
        [Parameter]
        public EventCallback<string> OnEditAmenityClicked { get; set; }
        [Inject]
        public IAmenityDataService AmenityDataService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            if(Amenity is not null)
                SelectedAmenityId = Amenity.AmenityId;

            await base.OnInitializedAsync();
        }

        protected async Task HandleDeleteAmenity()
        {
            var response = await AmenityDataService.DeleteAmenityAsync(Amenity.AmenityId);
            HandleDeleteAmenityResponse(response);
        }

        private async void HandleDeleteAmenityResponse(ApiResponse<Guid> response)
        {
            if(response.IsSuccess)
            {
                await OnDeleteAmenitySuccessful.InvokeAsync();
            }

        }
    }
}
