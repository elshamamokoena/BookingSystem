using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Services.Base
{
    public class DataServiceBase
    {
        protected readonly ILocalStorageService _localStorageService;
        protected readonly IClient _client;
        protected readonly NavigationManager _navigationManager;
        public DataServiceBase(IClient client, ILocalStorageService localStorageService, NavigationManager navigationManager)
        {
            _client = client;
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
        }

        protected virtual ApiResponse<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        { 
            if(ex.StatusCode== 400)
                return new ApiResponse<Guid> { IsSuccess = false, 
                    Message = "validation errors occured", 
                    ValidationErrors = ex.Response };
       
            else if(ex.StatusCode == 404)
                return new ApiResponse<Guid> { IsSuccess = false, 
                    Message = "The requested resource was not found" };
            else if(ex.StatusCode == 401)
            {
                _navigationManager.NavigateTo("/AccessDenied");
                return new ApiResponse<Guid>
                {
                    IsSuccess = false,
                    Message = "You are not authorized to perform this action",
                };
            }
     
            else
                return new ApiResponse<Guid> { IsSuccess = false, 
                    Message = "Something went wrong. Please try again later or contact support." };
        }

    }
}
