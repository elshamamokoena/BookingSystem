using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Events;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events.EditEvents
{
    public partial class EditEventPane : BaseComponent
    {
        [Parameter]
        public string EventId { get; set; }
        public Guid SelectedEventId = Guid.Empty;

        public EventViewModel Event { get; set; } = new EventViewModel();

        public ObservableCollection<ConsumableCategoryViewModel> Categories { get; set; }
            = new ObservableCollection<ConsumableCategoryViewModel>();
        public string SelectedConsumableCategoryId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(EventId, out SelectedEventId))
            {
                Event = await EventDataService!.GetEventAsync(SelectedEventId);
            }
            var categories = await ConsumableDataService!.GetConsumableCategoriesAsync();
            Categories = new ObservableCollection<ConsumableCategoryViewModel>(categories);
            SelectedConsumableCategoryId = Categories.FirstOrDefault().ConsumableCategoryId.ToString();
            await base.OnInitializedAsync();
        }

        public void UpdateEvent()
        {
        }
    }
}
