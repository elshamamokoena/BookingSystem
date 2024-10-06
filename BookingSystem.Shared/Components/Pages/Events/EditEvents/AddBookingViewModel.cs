using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events.EditEvents
{
    public class AddBookingViewModel
    {
        public Guid EventId { get; set; }
        public Guid ConferenceRoomId { get; set; }
    }
}
