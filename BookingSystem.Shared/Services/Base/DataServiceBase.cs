using Blazored.LocalStorage;
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
        public DataServiceBase(IClient client, ILocalStorageService localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
        }

        protected ApiResponse<Guid> ConvertApiExceptions(ApiException ex)
        { 
            if(ex.StatusCode== 400)
                return new ApiResponse<Guid> { IsSuccess = false, 
                    Message = "validation errors occured", 
                    ValidationErrors = ex.Response };
            else if(ex.StatusCode == 401)
                return new ApiResponse<Guid> { IsSuccess = false, 
                    Message = "You are not authorized to perform this action" };
            else if(ex.StatusCode == 403)
                return new ApiResponse<Guid> { IsSuccess = false, 
                    Message = "You are forbidden to perform this action" };
            else if(ex.StatusCode == 404)
                return new ApiResponse<Guid> { IsSuccess = false, 
                    Message = "The requested resource was not found" };
            else if(ex.StatusCode == 500)
                return new ApiResponse<Guid> { IsSuccess = false, 
                    Message = "An error occurred on the server. This is not your fault, our technical team will attend to it." };
            else
                return new ApiResponse<Guid> { IsSuccess = false, 
                    Message = "An error occurred. Please try again later or contact support." };


        }

    }
}
