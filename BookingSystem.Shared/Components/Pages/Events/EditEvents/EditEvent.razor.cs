using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Events;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events.EditEvents
{
    public partial class EditEvent : BaseComponent
    {
        [Parameter]
        [SupplyParameterFromQuery(Name = "eventId")]
        public string EventId { get; set; }
        private Guid SelectedEventId = Guid.Empty;

        public EventViewModel Event { get; set; } = new EventViewModel()
        { Start = DateTime.Now.AddHours(2), End = DateTime.Now.AddHours(3) };

        private string? _startDate;
        private string? _endDate;

        protected override async Task OnParametersSetAsync()
        {

            if(Guid.TryParse(EventId, out SelectedEventId))
            {
                Event = await EventDataService!.GetEventAsync(SelectedEventId);
            }

        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            await JsRuntime!.InitAppCalendar(firstRender, [Event]);
            await base.OnAfterRenderAsync(firstRender);
        }



    }
}
