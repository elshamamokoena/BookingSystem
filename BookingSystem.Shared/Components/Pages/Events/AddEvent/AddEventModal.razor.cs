using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Components.Pages.Categories;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Events;
using BookingSystem.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events.AddEvent
{
    public partial class AddEventModal : BaseComponent
    {
        public EventViewModel Event { get; set; } = new EventViewModel()
            { Start = DateTime.Now.AddHours(2), End = DateTime.Now.AddHours(3)};

        public ObservableCollection<CategoryViewModel> Categories { get; set; }
            = new ObservableCollection<CategoryViewModel>();

        public string SelectedCategoryId { get; set; }
        [Parameter]
        public EventCallback OnBookingCreated { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var categories = await CategoryDataService!.GetAllCategories();
            Categories = new ObservableCollection<CategoryViewModel>(categories);
            SelectedCategoryId = Categories.FirstOrDefault().CategoryId.ToString();
        }

        public async Task CreateBooking()
        {
            Event.CategoryId = Guid.Parse(SelectedCategoryId);
            var response = await EventDataService!.CreateEventAsync(Event);
            //if (response.IsSuccess)
            //{
            //    await OnBookingCreated.InvokeAsync();
            //}
        }


    }
}
