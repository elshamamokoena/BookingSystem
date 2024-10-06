using Blazored.LocalStorage;
using BookingSystem.Shared.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Base
{
    public class BaseComponent:ComponentBase
    {
        [Inject]
        public IJsInterop ? JsRuntime { get; set; }
        [Inject]
        public IEventDataService ? EventDataService { get; set; }
        [Inject]
        public IConferenceRoomService ? ConferenceRoomDataService { get; set; }
        [Inject]
        public IBookingDataService? BookingDataService { get; set; }
        [Inject]
        public ICategoryDataService ? CategoryDataService { get; set; }
        [Inject]
        public IStockEnquiryDataService ? StockEnquiryDataService { get; set; }
        [Inject]
        public NavigationManager ? NavigationManager { get; set; }
        [Inject]
        public IConsumableDataService? ConsumableDataService { get; set; }

        [JSInvokable]
        public void NavigateTo(string url)
        {
            NavigationManager!.NavigateTo(url);
        }


    }
}
