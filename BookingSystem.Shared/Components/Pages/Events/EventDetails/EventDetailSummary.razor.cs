using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events.EventDetails
{
    public partial class EventDetailSummary : BaseComponent
    {
        public EventViewModel Event { get; set; }
            = new EventViewModel();

    }
}
