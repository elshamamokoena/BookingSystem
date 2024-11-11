using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Consumables.Queries.GetConsumables
{
    public class ConsumableListDto
    {
        public Guid ConsumableId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid ConsumableCategoryId { get; set; }
        public ConsumableListCategoryDto? Category { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsInStock { get; set; } 
    }
}
