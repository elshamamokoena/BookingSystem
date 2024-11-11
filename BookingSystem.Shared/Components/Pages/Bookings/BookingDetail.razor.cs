using BookingSystem.ClassLibrary;
using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Bookings;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Bookings
{
    public partial class BookingDetail: BaseComponent
    {
        [Parameter]
        public string BookingId { get; set; }
        public Guid SelectedBookingId = Guid.Empty;
        public BookingViewModel Booking { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await FetchBooking();
            await base.OnParametersSetAsync();
        }
        protected async Task UpdateBookingAsync(ChangeEventArgs args)
        {
            UpdateBookingViewModel booking = new UpdateBookingViewModel();

            if (Enum.TryParse(args.Value.ToString(), out BookingStatus status))
            {
                booking.Status = status.ToString();
            }
            booking.BookingId = SelectedBookingId;

            var response = await BookingDataService!.UpdateBookingAsync(booking);
            HandleUpdateBookingResponse(response);
        }

        private async void HandleUpdateBookingResponse(ApiResponse<Guid> response)
        {
            if(response.IsSuccess)
            {
                await FetchBooking();
                StateHasChanged();
            }
            else
            {
               //
            }
        }

        private async Task FetchBooking()
        {
            if (Guid.TryParse(BookingId, out SelectedBookingId))
            {
                Booking = await BookingDataService!.GetBookingAsync(SelectedBookingId, true, true);
            }
        }
    }
}
