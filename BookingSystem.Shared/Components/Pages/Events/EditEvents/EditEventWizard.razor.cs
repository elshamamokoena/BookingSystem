using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Bookings;
using BookingSystem.Shared.Models.Events;
using BookingSystem.Shared.Models.Rooms;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events.EditEvents
{
    public partial class EditEventWizard : BaseComponent
    {
        [Parameter]
        public string EventId { get; set; }
        public Guid SelectedEventId = Guid.Empty;

        public EventViewModel Event { get; set; } = new EventViewModel()
        { Start = DateTime.Now.AddHours(2), End = DateTime.Now.AddHours(3) };

        public string Message { get; set; } = string.Empty;
        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(EventId, out SelectedEventId))
            {
                Event = await EventDataService!.GetEventAsync(SelectedEventId);
            }
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //await JsRuntime!.InvokeVoidAsync("wizardManager.dropzoneInit");
            //await jSRuntime!.InvokeVoidAsync("wizardManager.lottieInit");
            await JsRuntime!.InitWizard(firstRender);
            await base.OnAfterRenderAsync(firstRender);
        }

        public async Task UpdateEvent()
        {
            await EventDataService!.UpdateEventAsync(Event);
        }

        public async Task BookRoomForEvent(Guid roomId)
        {
            var response =
                await BookingDataService!.CreateBookingAsync(new AddBookingViewModel { EventId = Event!.EventId, ConferenceRoomId = roomId });
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.IsSuccess)
            {
                Message = "Booking created successfully";
            }else
            {
                Message = response.Message;
                if(!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
