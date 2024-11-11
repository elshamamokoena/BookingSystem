using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Consumables.Commands.UpdateConsumable
{
    public class UpdateConsumableCommand:IRequest<Unit>
    {
        public Guid ConsumableId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsVisible { get; set; }
        public Guid ConsumableCategoryId { get; set; }
    }
}
