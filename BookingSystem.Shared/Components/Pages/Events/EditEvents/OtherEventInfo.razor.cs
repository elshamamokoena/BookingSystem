using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Components.Pages.Categories;
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
    public partial class OtherEventInfo:BaseComponent
    {
        [Parameter]
        public string EventId { get; set; }
        private Guid SelectedEventId = Guid.Empty;
        public EventViewModel Event { get; set; } 
            = new EventViewModel();
        public ObservableCollection<CategoryViewModel> Categories { get; set; }
            = new ObservableCollection<CategoryViewModel>();

        public string Message { get; set; }
        public string SelectedCategoryId { get; set; } 

        protected override async Task OnInitializedAsync()
        {
            if(Guid.TryParse(EventId, out SelectedEventId))
            {
                Event = await EventDataService!.GetEventAsync(SelectedEventId);
                SelectedCategoryId = Event.CategoryId.ToString();
            }
            var categories = await CategoryDataService!.GetAllCategories();
            Categories = new ObservableCollection<CategoryViewModel>(categories);
            SelectedCategoryId = Categories.FirstOrDefault().CategoryId.ToString();
        }
    }
}
