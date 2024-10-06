using BookingSystem.Shared.Components.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Layout
{
    public partial class TopNav:BaseComponent
    {
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JsRuntime!.LoadModule("handleNavbarVerticalCollapsed");

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
