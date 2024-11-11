using BookingSystem.Shared.Components.Pages.Categories;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Rooms;
using BookingSystem.Shared.Services;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.ConferenceRooms
{
    public partial class AddAmenityModal
    {
        public AmenityViewModel Amenity { get; set; }

        public ObservableCollection<AmenityCategoryViewModel> Categories = 
            new ObservableCollection<AmenityCategoryViewModel>();
        [Inject]
        public IAmenityDataService AmenityService { get; set; }
        public string Message { get; set; } 
        public string SelectedCategoryId { get; set; }

        [Parameter]
        public string ConferenceRoomId { get; set; }
        public Guid SelectRoomId = Guid.Empty;


        [Parameter]
        public EventCallback OnValidResponse { get; set; }

        public bool HideButton  = false;
        public bool ShowToast= false;

        protected override async Task OnInitializedAsync()
        {
            Amenity = new AmenityViewModel();
            await FetchCategories();
            SelectedCategoryId = Categories.FirstOrDefault().AmenityCategoryId.ToString();

        }

    
        protected async void HandleValidSubmit()
        {
            if(Guid.TryParse(ConferenceRoomId, out SelectRoomId))
            {
                Amenity.ConferenceRoomId = SelectRoomId;
                Amenity.AmenityCategoryId = Guid.Parse(SelectedCategoryId);
                var response = await AmenityService.CreateAmenityAsync(Amenity);
                HandleResponse(response);
            }
        }

        private async void HandleResponse(ApiResponse<Guid> response)
        {
            if(response.IsSuccess)
            {
                Message = response.Message;
                HideButton = true;
                ShowToast = true;
                Amenity = new AmenityViewModel();
                await FetchCategories();
                StateHasChanged();
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
        private async Task FetchCategories()
        {
            var categories = await AmenityService.GetAmenityCategoriesAsync();
            Categories = new ObservableCollection<AmenityCategoryViewModel>(categories);
        }
    }


}
