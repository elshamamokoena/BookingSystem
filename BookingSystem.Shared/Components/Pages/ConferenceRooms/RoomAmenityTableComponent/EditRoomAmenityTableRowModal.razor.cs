using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.ConferenceRooms.RoomAmenityTableComponent
{
    public partial class EditRoomAmenityTableRowModal:CustomComponentBase
    {
        [Parameter]
        public string AmenityId { get; set; }
        public Guid SelectedAmenityId = Guid.Empty;

        public AmenityViewModel Amenity { get; set; }
        [Inject]
        public IAmenityDataService AmenityDataService { get; set; } = default!;

        public ObservableCollection<AmenityCategoryViewModel> Categories { get; set; }
            = new ObservableCollection<AmenityCategoryViewModel>();

        public string SelectedCategoryId { get; set; } = string.Empty;


        public async void HandleValidSubmit()
        {
            Amenity.AmenityCategoryId = Guid.Parse(SelectedCategoryId);
            ApiResponse<Guid> response;

            if(SelectedAmenityId == Guid.Empty)
            {
                response = await AmenityDataService.CreateAmenityAsync(Amenity);

            }
            else
            {
                response = await AmenityDataService.UpdateAmenityAsync(Amenity);

            }
            HandleResponse(response);
            StateHasChanged();
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if(response.IsSuccess)
            {
                ShowSuccess(response.Message);
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                {
                    Message += response.ValidationErrors;
                }
                ShowError(Message);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(AmenityId, out SelectedAmenityId))
            {
                Amenity = await AmenityDataService.GetAmenityAsync(SelectedAmenityId, true, false);
                SelectedCategoryId = Amenity.AmenityCategoryId.ToString();
            }

            Categories = new ObservableCollection<AmenityCategoryViewModel>
             (await AmenityDataService.GetAmenityCategoriesAsync());
            SelectedCategoryId = Categories.FirstOrDefault().AmenityCategoryId.ToString();
        }

        private void CloseModal()
        {
            IsSuccess = false;
            StateHasChanged();
        }

    }
}
