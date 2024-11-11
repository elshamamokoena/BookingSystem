using BookingSystem.Application.ResourceParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Consumables.Queries.GetConsumables
{
    public partial class GetConsumablesQuery:ResourceParameterBase, IRequest<ConsumableListVm>
    {
        public Guid ? ConsumableCategoryId { get; set; }  
        public bool ? IncludeCategory { get; set; }
    }
}
