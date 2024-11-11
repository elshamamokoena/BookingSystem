using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConsumableCategories.Commands
{
    public class CreateConsumableCategoryCommand:IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
