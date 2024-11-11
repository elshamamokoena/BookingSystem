using BookingSystem.Shared.Contracts;
using IdentityModel;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.CartComponents
{
    public partial class CartSummary
    {
        [Inject]
        public ICartDataService CartDataService { get; set; } = default!;
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; } = default!;

        public CartViewModel Cart { get; set; } 
            = new CartViewModel();

        private int _cartItemCount;

        protected override async Task OnInitializedAsync()
        {
            _cartItemCount = 0;
            await LoadAuthenticationStateAsync();
        }

        private async Task LoadAuthenticationStateAsync()
        {
            var user = (await AuthenticationStateTask).User;
            if (user.Identity is not null && user.Identity.IsAuthenticated)
            {
                var userId = user.FindFirst(JwtClaimTypes.Subject)?.Value;
                var response = await CartDataService.CreateCart(userId);
            }
        }
    }
}
