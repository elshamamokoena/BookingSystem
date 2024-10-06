using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Bookings;
using BookingSystem.Shared.Models.Events;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared
{
    public interface IJsInterop
    {
        Task DestroyTable();
        Task InitAppCalendar( bool firstRender, IEnumerable<EventViewModel> events);
        Task InitCalendar(bool firstRender);
        Task InitBulkSelect(bool firstRender);
        Task InitDataTables(bool firstRender);
        Task InitDropzone();
        Task InitLottie();
        Task InitWizard(bool firstRender);
        Task LoadModule(string module);
        Task InitNavigationManager(BaseComponent component);
        Task InitiAdvanceAjaxTable(bool firstRender, IEnumerable<BookingViewModel>  bookings,
            BaseComponent component);
    }
}
