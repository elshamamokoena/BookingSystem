using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Events.EditEvents
{
    public partial class ConsumableCategoryViewModel
    {
        public Guid ConsumableCategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
    public partial class ConsumableCategoryViewModel
    {
        public bool IsSelected { get; set; } 
    }

}
