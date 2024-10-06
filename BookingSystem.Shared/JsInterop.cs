using BookingSystem.Shared.Components.Base;
using BookingSystem.Shared.Models.Bookings;
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
          await _jsRuntime!.InvokeVoidAsync("oneModuleToRuleThemAll.bulkSelectInit");
        }

        public async Task InitDataTables(bool firstRender)
        {
            await _jsRuntime!.InvokeVoidAsync("oneModuleToRuleThemAll.listInit");
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

        public async Task InitWizard(bool firstRender)
        {
            if(firstRender)
            {
                await _jsRuntime!.InvokeVoidAsync("oneModuleToRuleThemAll.wizardInit");
                await _jsRuntime!.InvokeVoidAsync("oneModuleToRuleThemAll.select2Init");
            }

        }
        public async Task LoadModule(string module)
        {
            await _jsRuntime!.InvokeVoidAsync($"oneModuleToRuleThemAll.{module}");
        }

        public async Task InitNavigationManager(BaseComponent component)
        {
            await _jsRuntime!.InvokeVoidAsync("navigationManager.navigationManagerInit",DotNetObjectReference.Create(component));
        }

        public async Task InitCalendar(bool firstRender)
        {
            if(firstRender)
            {
                await _jsRuntime!.InvokeVoidAsync("oneModuleToRuleThemAll.appCalendarInit");
                await _jsRuntime!.InvokeVoidAsync("oneModuleToRuleThemAll.managementCalendarInit");

            }


        }

        public async Task InitiAdvanceAjaxTable(bool firstRender, IEnumerable<BookingViewModel>  bookings, BaseComponent component)
        {
          //  if(!firstRender)
          //      await _jsRuntime!.InvokeVoidAsync("import", "./_content/BookingSystem.Shared/vendors/list.js/list.min.js");


            await _jsRuntime!.InvokeVoidAsync("oneModuleToRuleThemAll.advanceAjaxTableInit", bookings,
                   DotNetObjectReference.Create(component));
      


        }

        public async Task DestroyTable()
        {
            await _jsRuntime!.InvokeVoidAsync("oneModuleToRuleThemAll.dataTableDestroy");
        }
    }
}
