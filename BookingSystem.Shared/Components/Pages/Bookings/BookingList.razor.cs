using BookingSystem.ClassLibrary;
using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Bookings;
using BookingSystem.Shared.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Bookings
{
    public partial class BookingList:BaseComponent
    {

        [Parameter]
        public string EventId { get; set; }
        public Guid SelectedEventId = Guid.Empty;

        public ObservableCollection<BookingViewModel>? Bookings { get; set; } 
            = new ObservableCollection<BookingViewModel>();

        private IEnumerable<BookingViewModel> bookings =
            new List<BookingViewModel>();

        public BookingStatus SelectedBookingStatus = default!;
        protected override async Task OnInitializedAsync()
        {
            if(Guid.TryParse(EventId, out SelectedEventId) && SelectedEventId != Guid.Empty)
                bookings = await BookingDataService!.GetBookingsAsync(SelectedEventId, 1, 100);
            else
                bookings = await BookingDataService!.GetBookingsAsync(null,1, 100);

            Bookings = new ObservableCollection<BookingViewModel>(bookings);
            await base.OnInitializedAsync();
        }



        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (Bookings != null)
        //        await JsRuntime!.InitiAdvanceAjaxTable(firstRender, Bookings, this);

        //    await base.OnAfterRenderAsync(firstRender);
        //}
    }
}
