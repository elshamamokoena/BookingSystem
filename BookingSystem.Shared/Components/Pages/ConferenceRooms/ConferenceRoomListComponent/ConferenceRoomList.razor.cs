using BookingSystem.ClassLibrary;
using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Components.Pages.Events.EditEvents;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Bookings;
using BookingSystem.Shared.Models.Rooms;
using BookingSystem.Shared.Services;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.ConferenceRooms.ConferenceRoomListComponent
{
    public partial class ConferenceRoomList : CustomComponentBase
    {

        [Parameter]
        public string EventId { get; set; }
        public Guid SelectedEventId = Guid.Empty;

        private DateTime ? _startDate;
        private DateTime? _endDate;
        private bool IsInBookingMode = false;

        [Inject]
        public IConferenceRoomService ConferenceRoomDataService { get; set; } = default!;
        [Inject]
        public IEventDataService EventDataService { get; set; } = default!;
        [Inject]
        public IBookingDataService BookingDataService { get; set; } = default!;
        public PagedList<RoomViewModel> Rooms { get; set; }
            = new PagedList<RoomViewModel>();

        private ObservableCollection<RoomViewModel> RoomList;
        public bool ShowToast = false;

        protected override async Task OnInitializedAsync()
        {
            await FetchRoomsAsync();
            await base.OnInitializedAsync();
        }

        protected override async Task OnParametersSetAsync()
        {
            if(Guid.TryParse(EventId, out SelectedEventId) && SelectedEventId != Guid.Empty)
            {
                var @event = await EventDataService.GetEventAsync(SelectedEventId);
                _startDate = @event.Start;
                _endDate = @event.End;
            }
            IsInBookingMode = _startDate != null && _endDate != null;
            await base.OnParametersSetAsync();
        }
        public async Task BookRoomForEvent(Guid roomId)
        {
            ApiResponse<Guid> response;
            var @event = await EventDataService!.GetEventAsync(SelectedEventId);
            response = await BookingDataService!.CreateBookingAsync(new AddBookingViewModel
            { ConferenceRoomId= roomId, EventId = @event.EventId});

            HandleResponse(response);
        }
        private async void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.IsSuccess)
            {
                await FetchRoomsAsync();
                StateHasChanged();
            }
            else
            {
                //Show error message
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
                ShowToast = true;
            }
        }
        public async Task FetchRoomsAsync()
        {
            var rooms = await ConferenceRoomDataService.GetConferenceRoomsAsync(_searchQuery, _startDate, _endDate, _pageNumber, _pageSize);
            Rooms = new PagedList<RoomViewModel>(rooms.ConferenceRooms.ToList(),rooms.Count,rooms.PageNumber,_pageSize);
            RoomList = new ObservableCollection<RoomViewModel>(Rooms);
        }
        public async Task PageIndexChanged(int newPageNumber)
        {
            if (newPageNumber < 1 || newPageNumber > Rooms.TotalPages)
            {
                return;
            }
            _pageNumber = newPageNumber;
            await FetchRoomsAsync();
            StateHasChanged();
        }
    }
}
