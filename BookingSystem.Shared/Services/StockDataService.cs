using AutoMapper;
using Blazored.LocalStorage;
using BookingSystem.Shared.Components.Pages.Consumables.EditConsumablePage.EditConsumablePageComponents;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Services
{
    public class StockDataService : DataServiceBase, IStockDataService
    {
        private readonly IMapper _mapper;
        public StockDataService(IClient client, IMapper mapper ,ILocalStorageService localStorageService,
            NavigationManager navigationManager) : base(client, localStorageService, navigationManager)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateStockItemAsync(StockItemViewModel stockItem)
        {
            try
            {
                CreateStockItemCommand command = new CreateStockItemCommand
                {
                    ConsumableId = stockItem.ConsumableId,
                    Quantity = stockItem.Quantity,
                    Sku = stockItem.Sku
                };

                return new ApiResponse<Guid>
                {
                    Data = await _client.CreateStockItemAsync(command),
                    IsSuccess = true,
                    Message = "Stock item created successfully",
                };

            }catch(ApiException<Guid> ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public Task<ApiResponse<Guid>> DeleteStockItemAsync(Guid stockItemId)
        {
            throw new NotImplementedException();
        }

        public async Task<StockItemViewModel> GetStockItemAsync(Guid ? stockItemId, Guid? consumableId, bool? includeConsumable)
        {

            return _mapper.Map<StockItemViewModel>
                (await _client.GetStockItemAsync(stockItemId, includeConsumable));
        }

        public async Task<StockItemViewModel> GetStockItemForConsumableAsync(Guid consumableId)
        {
            try
            {
                var stockItem = await _client.GetStockItemByConsumableAsync(consumableId);
                return _mapper.Map<StockItemViewModel>(stockItem);
            }
            catch(ApiException ex)
            {
                return new StockItemViewModel();
            }
        }

        public async Task<ApiResponse<Guid>> UpdateStockItemAsync(StockItemViewModel stockItem)
        {
            try 
            {
                UpdateStockItemCommand command = new UpdateStockItemCommand { StockItemId = stockItem.StockItemId, 
                    Sku=stockItem.Sku, Quantity = stockItem.Quantity};

                await _client.UpdateStockItemAsync(command);
                return new ApiResponse<Guid>() {  IsSuccess = true, Message = "Stock Item Updated successfully!" };
            }
            catch(ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
