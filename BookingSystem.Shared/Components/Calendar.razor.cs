using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Events;
using BookingSystem.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BookingSystem.Shared.Components
{
    public partial class Calendar:BaseComponent
    {
  
        private IEnumerable<EventViewModel> Events { get; set; }
            = new List<EventViewModel>();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await GetEvents();
            await JsRuntime!.InitNavigationManager(this);
            await JsRuntime!.InitAppCalendar(firstRender, Events);
            await JsRuntime!.InitCalendar(firstRender);
            await base.OnAfterRenderAsync(firstRender);
        }
        public async Task GetEvents()
        {
            Events = await EventDataService!.GetEventsAsync(DateTime.Parse("2024/08/01 12:00"), DateTime.Parse("2024/10/30 12:00"),1,50);
        }
        public void Dispose()
        {
        }
    }
}
