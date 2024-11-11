using BookingSystem.ClassLibrary;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Bookings;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Dashboard
{
    public partial class DashboardPage
    {
        [Inject]
        public IBookingDataService BookingDataService { get; set; } = default!;
        [Inject]
        public IConferenceRoomService ConferenceRoomDataService { get; set; } = default!;
        [Inject]
        public IAnalyticsDataService AnalyticsDataService { get; set; } = default!;
        public ICollection<BookingViewModel> Bookings { get; set; } 
            = new List<BookingViewModel>();
        public PagedList<ConferenceRoomChangeEventViewModel> ConferenceRoomChangeEvents { get; set; }
            = new PagedList<ConferenceRoomChangeEventViewModel>();

        private ICollection<ConferenceRoomChangeEventViewModel> ConferenceRoomChangeEventsList 
            = new List<ConferenceRoomChangeEventViewModel>();

        private int _cancelledBookings;
        private int _approvedBookings;
        private int _pendingBookings;

        private  int _pageNumber = 1;
        private int _pageSize = 4;
        protected override async Task OnInitializedAsync()
        {
            await FetchBookings();
            CalculateBookings();
            await FetchConferenceRoomChangeEvents();
        }
        protected void CalculateBookings()
        {
            _approvedBookings = Bookings.Count(b => b.Status == nameof(BookingStatus.Approved));
            _cancelledBookings = Bookings.Count(b => b.Status == nameof(BookingStatus.Cancelled));
            _pendingBookings = Bookings.Count(b => b.Status == nameof(BookingStatus.Pending));
        }

        protected async Task FetchConferenceRoomChangeEvents()
        {
            var conferenceRoomChangeEvents = await AnalyticsDataService
                .GetConferenceRoomChangeEventListViewModel(null, null,true,_pageNumber,_pageSize);

            ConferenceRoomChangeEvents = new PagedList<ConferenceRoomChangeEventViewModel>
               (conferenceRoomChangeEvents.ConferenceRoomChangeEvents.ToList(),
               conferenceRoomChangeEvents.Count, _pageNumber,_pageSize);

            ConferenceRoomChangeEventsList = new List<ConferenceRoomChangeEventViewModel>(ConferenceRoomChangeEvents);
        }
        protected async Task FetchBookings()
        {
            var bookings = await BookingDataService.GetBookingsAsync(null, null, 100);
            Bookings = new List<BookingViewModel>(bookings);
        }
    }
}
