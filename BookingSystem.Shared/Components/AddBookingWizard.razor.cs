using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components
{
    public partial class AddBookingWizard
    {
        [Inject]
        public IJSRuntime ? jSRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                await jSRuntime!.InvokeVoidAsync("wizardManager.dropzoneInit");
                await jSRuntime!.InvokeVoidAsync("wizardManager.lottieInit");
                await jSRuntime!.InvokeVoidAsync("wizardManager.wizardInit");

            }

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
