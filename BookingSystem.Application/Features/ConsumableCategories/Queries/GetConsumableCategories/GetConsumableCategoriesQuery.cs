using BookingSystem.Domain.Entities.Consumables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConsumableCategories.Queries.GetConsumableCategories
{
    public class GetConsumableCategoriesQuery:IRequest<IEnumerable<ConsumableCategoryListVm>>
    {
    }
}
