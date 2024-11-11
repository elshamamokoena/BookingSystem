
using BookingSystem.Application.Models;

namespace BookingSystem.Application.Features.Consumables.Queries.GetConsumables
{
    public class ConsumableListVm:PagedVm
    {
        public IEnumerable<ConsumableListDto>? Consumables { get; set; }

    }
}