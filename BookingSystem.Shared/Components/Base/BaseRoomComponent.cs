using BookingSystem.Shared.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Base
{
    public class BaseRoomComponent: BaseComponent
    {
        public IEnumerable<RoomViewModel> Rooms { get; set; } = new List<RoomViewModel>();
        protected override async Task OnInitializedAsync()
        {
            Rooms = await ConferenceRoomDataService!.GetConferenceRooms(null, null, null, 1, 20);
            await base.OnInitializedAsync();
        }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    await JsRuntime!.InitDataTables(firstRender);
        //    await JsRuntime!.InitBulkSelect(firstRender);
        //    await base.OnAfterRenderAsync(firstRender);
        //}
    }
}
