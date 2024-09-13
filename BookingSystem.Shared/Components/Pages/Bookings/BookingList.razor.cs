using BookingSystem.Shared.Components.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Bookings
{
    public partial class BookingList:BaseComponent
    {

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
                await JsRuntime!.InitiAdvanceAjaxTable();

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}
