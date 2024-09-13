using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Events;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared
{
    public class JsInterop:IJsInterop
    {
        private readonly IJSRuntime ?_jsRuntime;
        public JsInterop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
       
        }

        public async Task InitBulkSelect(bool firstRender)
        {
            if(!firstRender)
                await _jsRuntime!.InvokeVoidAsync("oneModuleToRuleThemAll.bulkSelectInit");
        }

        public async Task InitDataTables(bool firstRender)
        {
            if (!firstRender)
                await _jsRuntime!.InvokeVoidAsync("oneModuleToRuleThemAll.dataTablesInit");

        }

        public Task InitDropzone()
        {
            throw new NotImplementedException();
        }

        public async Task InitAppCalendar(bool firstRender, IEnumerable<EventViewModel> events)
        {
           

            //await _jsRuntime!.InvokeVoidAsync("import", "./_content/BookingSystem.Shared/assets/js/flatpickr.js");

            await _jsRuntime!.InvokeVoidAsync("oneModuleToRuleThemAll.setEvents", events);
            await _jsRuntime!.InvokeVoidAsync("oneModuleToRuleThemAll.setManagementEvents", events);

        }

        public Task InitLottie()
        {
            throw new NotImplementedException();
        }

        public Task InitWizard(bool firstRender)
        {
            throw new NotImplementedException();
        }

        public async Task LoadModule(string module)
        {
            await _jsRuntime!.InvokeVoidAsync("import", module);
        }

        public async Task InitNavigationManager(BaseComponent component)
        {
            await _jsRuntime!.InvokeVoidAsync("navigationManager.navigationManagerInit",DotNetObjectReference.Create(component));
        }

        public async Task InitCalendar(bool firstRender)
        {

            if(!firstRender)
            {
                var module = await _jsRuntime!.InvokeAsync<IJSObjectReference>("import", "./_content/BookingSystem.Shared/assets/js/flatpickr.js");
                await _jsRuntime!.InvokeVoidAsync("oneModuleToRuleThemAll.appCalendarInit");
                await _jsRuntime!.InvokeVoidAsync("oneModuleToRuleThemAll.managementCalendarInit");

            }

        }

        public async Task InitiAdvanceAjaxTable()
        {
            await _jsRuntime!.InvokeVoidAsync("bookingTableManager.advanceAjaxTableInit");
        }
    }
}
