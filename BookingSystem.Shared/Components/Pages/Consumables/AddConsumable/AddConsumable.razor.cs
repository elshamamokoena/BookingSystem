using BookingSystem.Shared.Components.Pages.Events.EditEvents;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Services;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Consumables.AddConsumable
{
    public partial class AddConsumable
    {
        [Inject]
        public IConsumableDataService ConsumableDataService { get; set; } = default!;
        public ConsumableViewModel Consumable { get; set; }
        public ObservableCollection<ConsumableCategoryViewModel> Categories { get; set; }
                                = new ObservableCollection<ConsumableCategoryViewModel>();

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;
        public string SelectedCategoryId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Consumable = new ConsumableViewModel();
            var categories = await ConsumableDataService.GetConsumableCategoriesAsync();
            Categories = new ObservableCollection<ConsumableCategoryViewModel>(categories);
            SelectedCategoryId = Categories.FirstOrDefault().ConsumableCategoryId.ToString();
           await base.OnInitializedAsync();
        }
        protected async void HandleValidSubmit()
        {
            Consumable.ConsumableCategoryId = Guid.Parse(SelectedCategoryId);
            var response = await ConsumableDataService.CreateConsumableAsync(Consumable);
            HandleResponse(response);

        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if(response.IsSuccess)
            {
                NavigationManager.NavigateTo("/consumable-list");
            }else
            {

            }
        }
    }
}
