using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Rooms;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.ConferenceRooms.RoomAmenityTableComponent
{
    public partial class RoomAmenityTable: CustomComponentBase
    {
        [CascadingParameter]
        public string ConferenceRoomId { get; set; }
        public Guid SelectedRoomId = Guid.Empty;

        public Guid SelectedAmenityId = Guid.Empty;

        [Inject]
        public IAmenityDataService AmenityDataService { get; set; } = default!;

        public ObservableCollection<AmenityViewModel> Amenities
            = new ObservableCollection<AmenityViewModel>();

        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(ConferenceRoomId, out SelectedRoomId))
            {
                await FetchAmenities();
            }
            await base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Guid.TryParse(ConferenceRoomId, out SelectedRoomId))
            {
                await FetchAmenities();
            }
            await base.OnParametersSetAsync();
        }


        protected async Task FetchAmenities()
        {
            var amenities = await AmenityDataService.GetAmenitiesAsync(SelectedRoomId, true, false);
            Amenities = new ObservableCollection<AmenityViewModel>(amenities);
        }

        public async Task AmenitySelected(string amenityId)
        {

            if(Guid.TryParse(amenityId, out SelectedAmenityId) && SelectedAmenityId != Guid.Empty)
            {
                var amenity = await AmenityDataService.GetAmenityAsync(SelectedAmenityId, false, false);
                if (amenity != null)
                    SelectedAmenityId = amenity.AmenityId;
            }
        }

    }
}
