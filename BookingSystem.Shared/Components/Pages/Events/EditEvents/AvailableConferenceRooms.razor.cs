using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Rooms;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events.EditEvents
{
    public partial class AvailableConferenceRooms:BaseComponent
    {
        [Parameter]
        public string EventId { get; set; }
        public Guid SelectedEventId = Guid.Empty;
        public ICollection<RoomViewModel> Rooms { get; set; } 
            = new List<RoomViewModel>();
        public AddBookingViewModel BookingViewModel { get; set; } = new AddBookingViewModel();   
        protected override async Task OnInitializedAsync()
        {
            if(Guid.TryParse(EventId, out SelectedEventId))
            {
                var @event = await EventDataService!.GetEventAsync(SelectedEventId);
                var rooms = await FetchRooms();
                Rooms = new List<RoomViewModel>(rooms);
            }
        }

        public async Task BookRoomForEvent(Guid roomId)
        {
            BookingViewModel.ConferenceRoomId = roomId;
            ApiResponse<Guid> response;

            var @event = await EventDataService!.GetEventAsync(SelectedEventId);
            BookingViewModel.EventId = @event.EventId;
            response = await BookingDataService!.CreateBookingAsync(BookingViewModel);
            HandleResponse(response);
        }

        private async void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.IsSuccess)
            {
                var rooms = await FetchRooms();
                Rooms = new ObservableCollection<RoomViewModel>(rooms);
                StateHasChanged();
            }
            else 
            {
                //Show error message
            }
        }

     

        [JSInvokable]
        private async Task<IEnumerable<RoomViewModel>> FetchRooms()
        {
            var @event = await EventDataService!.GetEventAsync(SelectedEventId);
            return (await ConferenceRoomDataService!.GetConferenceRoomsAsync(null, @event.Start, @event.End, 1, 15)).ConferenceRooms;
        }
  
    }
}
