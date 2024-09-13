using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Events;
using BookingSystem.Shared.Services;

namespace BookingSystem.Shared.Components
{
    public partial class Calendar:BaseComponent
    {
        private IEnumerable<EventViewModel> Events { get; set; }
            = new List<EventViewModel>();
        protected override async Task OnInitializedAsync()
        {
            await GetEvents();
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
                await JsRuntime!.InitNavigationManager(this);
                await JsRuntime!.InitCalendar(firstRender);
                await JsRuntime!.InitAppCalendar(firstRender, Events);
                await base.OnAfterRenderAsync(firstRender);
        }
        public async Task GetEvents()
        {
            Events = await EventDataService!.GetEventsAsync(DateTime.Parse("2024/08/01 12:00"), DateTime.Parse("2024/10/30 12:00"),1,50);
            StateHasChanged();
        }
        public void Dispose()
        {
        }
    }
}
