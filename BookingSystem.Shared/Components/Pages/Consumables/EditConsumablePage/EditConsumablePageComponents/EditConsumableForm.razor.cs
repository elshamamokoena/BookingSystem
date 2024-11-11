using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Components.Pages.Events.EditEvents;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Consumables.EditConsumablePage.EditConsumablePageComponents
{
    public partial class EditConsumableForm:CustomComponentBase
    {
        [CascadingParameter]
        public string ConsumableId { get; set; }
        public Guid SelectedConsumableId = Guid.Empty;

        public ConsumableViewModel Consumable { get; set; }

        public ObservableCollection<ConsumableCategoryViewModel> Categories { get; set; }
            = new ObservableCollection<ConsumableCategoryViewModel>();
        public string SelectedCategoryId { get; set; }

        [Inject]
        public IConsumableDataService ConsumableDataService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            Consumable = new ConsumableViewModel();
            var categories = await ConsumableDataService.GetConsumableCategoriesAsync();
            Categories = new ObservableCollection<ConsumableCategoryViewModel>(categories);
            SelectedCategoryId = Categories.FirstOrDefault().ConsumableCategoryId.ToString();
        }

        protected async void HandleValidSubmit()
        {
            ApiResponse<Guid> response;
            response = await ConsumableDataService.CreateConsumableAsync(Consumable);

            //if(SelectedConsumableId == Guid.Empty)
            //{
            //    response = await ConsumableDataService.CreateConsumableAsync(Consumable);
            //}
            //else
            //{
            //    response = await ConsumableDataService.UpdateConsumableAsync(Consumable);
            //}
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if(response.IsSuccess)
            {
                
            }
          
        }
    }
}
