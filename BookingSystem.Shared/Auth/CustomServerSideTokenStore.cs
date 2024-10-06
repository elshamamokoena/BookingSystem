using Duende.AccessTokenManagement.OpenIdConnect;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Auth
{
    public class CustomServerSideTokenStore: IUserTokenStore
    {
        private readonly ConcurrentDictionary<string, UserToken> _tokens = new();

        public Task<UserToken> GetTokenAsync(ClaimsPrincipal user, UserTokenRequestParameters? parameters = null)
        {
            var sub = user.FindFirst("sub")?.Value ?? throw new InvalidOperationException("no sub claim");

            if (_tokens.TryGetValue(sub, out var value))
            {
                return Task.FromResult(value);
            }

            return Task.FromResult(new UserToken { Error = "not found" });
        }

        public Task StoreTokenAsync(ClaimsPrincipal user, UserToken token, UserTokenRequestParameters? parameters = null)
        {
            var sub = user.FindFirst("sub")?.Value ?? throw new InvalidOperationException("no sub claim");
            _tokens[sub] = token;

            return Task.CompletedTask;
        }

        public Task ClearTokenAsync(ClaimsPrincipal user, UserTokenRequestParameters? parameters = null)
        {
            var sub = user.FindFirst("sub")?.Value ?? throw new InvalidOperationException("no sub claim");

            _tokens.TryRemove(sub, out _);
            return Task.CompletedTask;
        }
    }
}
