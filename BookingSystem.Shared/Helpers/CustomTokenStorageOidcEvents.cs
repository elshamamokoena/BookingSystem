﻿using Duende.AccessTokenManagement.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Helpers
{
    public class CustomTokenStorageOidcEvents(IUserTokenStore userTokenStore): OpenIdConnectEvents
    {
        private readonly IUserTokenStore _userTokenStore = userTokenStore;

        public async override Task TokenValidated(TokenValidatedContext context)
        {
            var exp = DateTimeOffset.UtcNow.AddSeconds(
                Double.Parse(context.TokenEndpointResponse!.ExpiresIn));

            await _userTokenStore.StoreTokenAsync(context.Principal!, new UserToken
            {
                AccessToken = context.TokenEndpointResponse.AccessToken,
                AccessTokenType = context.TokenEndpointResponse.TokenType,
                RefreshToken = context.TokenEndpointResponse.RefreshToken,
                Expiration = exp,
                Scope = context.TokenEndpointResponse.Scope,
            });

            await base.TokenValidated(context);
        }
    }
}
