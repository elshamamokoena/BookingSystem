using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Consumables.Commands.DeleteConsumable
{
    public class DeleteConsumableCommand:IRequest<Unit>
    {
        public Guid ConsumableId { get; set; }
    }
}
