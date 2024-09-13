using BookingSystem.Application.Contracts.Services;
using System.Security.Claims;

namespace BookingSystem.Api.Services
{

    // This class is used to get the authenticated user's claims from the HttpContext
    //Claims such as Id, Name, Email, and Role are stored in the HttpContext
    public class AuthenticatedUserDataService : IAuthenticatedUserService
    {
        // httpContextAccessor is used to get the HttpContext of the current request
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticatedUserDataService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // The UserId is retrieved from the HttpContext
        // The HttpContext is used to get the current user's claims
        // The FindFirstValue method is used to get the value of the NameIdentifier claim
        // The NameIdentifier claim type is used to specify the unique identifier of the user
        public string UserId
        { 
            get 
            {
                return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            } 
        }
    }
}
