using BookingSystem.Shared.Components.Pages.Consumables;
using BookingSystem.Shared.Models.Rooms;
using BookingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Models.Consumables
{
    public class ConsumableListViewModel
    {
        public int Count { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ICollection<ConsumableListDto>? Consumables { get; set; }
    }
}
