using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Events;
using BookingSystem.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components
{
    public partial class AddBookingModal:BaseComponent
    {

        public EventViewModel Event { get; set; } = new EventViewModel();

        private string ? _startDate { get; set; } 
        private string? _endDate { get; set; }


        [Parameter]
        public EventCallback OnBookingCreated { get; set; }
        public async Task CreateBooking()
        {
       
        
            var response = await EventDataService!.CreateEventAsync(Event);
            if (response.IsSuccess)
            {
                await OnBookingCreated.InvokeAsync();
            }
        }

   
    }
}
