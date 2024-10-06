using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Bookings;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Consumables
{
    public partial class ConsumableList:BaseComponent
    {

        [Parameter]
        [SupplyParameterFromQuery(Name="bookingId")]
        public string BookingId { get; set; }
        public Guid SelectedBookingId = Guid.Empty;
        public BookingViewModel Booking { get; set; }
        public ICollection<ConsumableViewModel>  Consumables { get; set; } 
            = new List<ConsumableViewModel>();
        public Guid CreatedStockEnquiryId = Guid.Empty;

        public ICollection<StockItemEnquiryViewModel> StockItemEnquiries { get; set; }
            = new List<StockItemEnquiryViewModel>();
        protected override async Task OnInitializedAsync()
        {
            Consumables = await ConsumableDataService!.GetConsumables(true, 1, 10);
            await base.OnInitializedAsync();
        }
        protected override async Task OnParametersSetAsync()
        {
            if(Guid.TryParse(BookingId, out SelectedBookingId))
            {
                Booking =  await BookingDataService!.GetBookingAsync(SelectedBookingId, false, false);
                var response = await StockEnquiryDataService!.CreateStockEnquiry(Booking.BookingId);
                HandleResponse(response);

            }
            await base.OnParametersSetAsync();
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if(response.IsSuccess)
            {
                CreatedStockEnquiryId = response.Data;
            }
            else
            {
                //Show error message
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //await JsRuntime!.LoadModule("choicesInit");+
                await JsRuntime!.LoadModule("swiperInit");
            await base.OnAfterRenderAsync(firstRender);
        }
        public async Task AddToBooking(Guid consumableId)
        {
            var response = await StockEnquiryDataService!.CreateStockItemEnquiry(consumableId,1);

        }
    }
}
