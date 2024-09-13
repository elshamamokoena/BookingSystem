using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Events;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events
{
    public partial class EditEvent : BaseComponent
    {
        [Parameter]
        [SupplyParameterFromQuery(Name = "eventId")]
        public Guid EventId { get; set; }
        public EventViewModel  Event { get; set; }  = new EventViewModel();

        private string ?  _startDate;
        private string? _endDate;

        protected override async Task OnInitializedAsync()
        {
#if DEBUG
            //      await Task.Delay(10000); dd/mm/yy
#endif
            Event = await EventDataService!.GetEventAsync(EventId);
            _startDate = Event.Start.ToString();
            _endDate = Event.End.ToString();
            await base.OnInitializedAsync();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JsRuntime!.InitCalendar(firstRender);
            await base.OnAfterRenderAsync(firstRender);
        }

        public async Task UpdateEvent()
        {
            await EventDataService!.UpdateEventAsync(Event);
        }


    }
}
