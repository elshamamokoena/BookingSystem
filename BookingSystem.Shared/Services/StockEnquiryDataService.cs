using Blazored.LocalStorage;
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
    public class StockEnquiryDataService : DataServiceBase, IStockEnquiryDataService
    {
        public StockEnquiryDataService(IClient client, ILocalStorageService localStorageService, NavigationManager navigationManager)
            : base(client, localStorageService, navigationManager)
        {
        }

        public async Task<ApiResponse<Guid>> CreateStockEnquiry(Guid bookingId)
        {
            try
            {
                CreateStockEnquiryCommand command = new CreateStockEnquiryCommand { BookingId = bookingId };
                var newId = await _client.CreateStockEnquiryAsync(command);
                await _localStorageService.SetItemAsStringAsync("StockEnquiryId", newId.ToString());
                return new ApiResponse<Guid>() { Data = newId, IsSuccess = true, Message = "Stock Enquiry Created successfully!" };

            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> CreateStockItemEnquiry(Guid consumableId, int Quantity)
        {
            try
            {
                var stockEnquiryId = await _localStorageService.GetItemAsStringAsync("StockEnquiryId");
                CreateStockItemEnquiryCommand command = new CreateStockItemEnquiryCommand 
                { StockEnquiryId = Guid.Parse(stockEnquiryId), ConsumableId = consumableId, Quantity = Quantity>0 ? Quantity:1 };

                var newId = await _client.CreateStockItemEnquiryAsync(command);
                return new ApiResponse<Guid>() { Data = newId, IsSuccess = true, Message = "Stock Item Enquiry Created successfully!" };
            }
            catch(ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
