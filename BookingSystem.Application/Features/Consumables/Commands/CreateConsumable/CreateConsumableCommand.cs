using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Consumables.Commands.CreateConsumable
{
    public class CreateConsumableCommand: IRequest<CreateConsumableCommandResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ConsumableCategoryId { get; set; }

    }
}
