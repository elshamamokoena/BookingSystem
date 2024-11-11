using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Consumables.EditConsumablePage.EditConsumablePageComponents
{
    public partial class EditConsumableStockItem
    {
        [Parameter]
        public string ConsumableId { get; set; }
        public Guid SelectedConsumableId = Guid.Empty;

        public StockItemViewModel StockItem { get; set; }  
            = new StockItemViewModel();
     
        [Inject]
        public IStockDataService StockDataService { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(ConsumableId, out SelectedConsumableId))
            {
                StockItem = await StockDataService.GetStockItemForConsumableAsync(SelectedConsumableId);
            }
        }

        protected async Task UpdateStockItemAsync()
        {
            ApiResponse<Guid> response;
            if(Guid.TryParse(ConsumableId, out SelectedConsumableId))
            {
                StockItem.ConsumableId = SelectedConsumableId;
                if (StockItem.StockItemId == Guid.Empty)
                    response = await StockDataService.CreateStockItemAsync(StockItem);
                else
                    response = await StockDataService.UpdateStockItemAsync(StockItem);
            }


        }

    }
}
