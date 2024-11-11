using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Consumables.Queries.GetConsumable
{
    public class GetConsumableQuery:IRequest<ConsumableVm>
    {
        public Guid ConsumableId { get; set; }
        public bool? IncludeCategory { get; set; }
    }
}
