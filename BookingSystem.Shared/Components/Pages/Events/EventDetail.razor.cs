using BookingSystem.Shared.Components.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events
{
    public partial class EventDetail:BaseComponent
    {
        [Parameter]
        [SupplyParameterFromQuery(Name = "eventId")]
        public Guid EventId { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            StateHasChanged();
            
            await base.OnParametersSetAsync();
        }


    }
}
