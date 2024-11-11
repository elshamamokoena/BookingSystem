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
    public class CartDataService : DataServiceBase, ICartDataService
    {
        public CartDataService(IClient client, ILocalStorageService localStorageService,
            NavigationManager navigationManager) : base(client, localStorageService, navigationManager)
        {
        }

        public async Task<ApiResponse<Guid>> CreateCart(string userId)
        {
            try
            {

                return new ApiResponse<Guid>
                {
                    IsSuccess = true,
                    Data = await _client.CreateCartAsync(new CreateCartCommand()
                    {
                        UserId = userId
                    })
                };
            }
            catch (ApiException<Guid> ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
