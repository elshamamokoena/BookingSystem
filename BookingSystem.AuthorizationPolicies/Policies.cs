using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BookingSystem.AuthorizationPolicies
{
    public static class Policies
    {
        public const string IsManager = "IsManager";
        public const string IsClerk = "IsClerk";
        public const string IsEmployee = "IsEmployee";

        public static AuthorizationPolicy ManagerPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("roles","Manager")
                .Build();
        }

        public static AuthorizationPolicy ClerkPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("roles", "Clerk")
                .Build();
        }
        public static AuthorizationPolicy EmployeePolicy() {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("roles", "Employee")
                .Build();
        }

     
    }
}
