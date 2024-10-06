using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Shared.Components.Base;

namespace BookingSystem.Shared.Components.Layout
{
    public partial class NavBar:BaseComponent, IDisposable
    {
        private string? currentUrl;

        protected override void OnInitialized()
        {
            currentUrl = NavigationManager!.ToBaseRelativePath(NavigationManager.Uri);
            NavigationManager.LocationChanged += OnLocationChanged;
        }


        private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
        {
            currentUrl = NavigationManager!.ToBaseRelativePath(e.Location);
            StateHasChanged();
        }

        public void Dispose()
        {
            NavigationManager!.LocationChanged -= OnLocationChanged;
        }
    }
}
