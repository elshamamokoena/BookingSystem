using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events.EditEvents
{
    public partial class EditConsumables:BaseComponent
    {
        [Parameter]
        public string BookingId { get; set; }
        public Guid SelectedBookingId = Guid.Empty;

        public ObservableCollection<ConsumableCategoryViewModel> ConsumableCategories
            = new ObservableCollection<ConsumableCategoryViewModel>();

        private bool OptionsVisible =true;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JsRuntime!.LoadModule("choicesInit");
            await base.OnAfterRenderAsync(firstRender);
        }
        [JSInvokable]
        public async Task AddStockItemEnquiry()
        {

        }
        public async Task ToggleSelectedConsumableCategories(ConsumableCategoryViewModel consumableCategory)
        {

        }
        protected override async Task OnInitializedAsync()
        {

            if(Guid.TryParse(BookingId, out SelectedBookingId))
            {
                //get booking
            }
            var categories = await ConsumableDataService!.GetConsumableCategories();
            ConsumableCategories = new ObservableCollection<ConsumableCategoryViewModel>(categories);

            await base.OnInitializedAsync();
        }

    }
}
