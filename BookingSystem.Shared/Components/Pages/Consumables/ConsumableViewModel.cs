using BookingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Components.Pages.Consumables
{
    public class ConsumableViewModel
    {
        public Guid ConsumableId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Name must not exceed more than 20 characters.")]

        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(50, ErrorMessage = "Description must not exceed more than 50 characters.")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [StringLength(200,ErrorMessage ="Url of the image is too long.")]
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsVisible { get; set; }
        public Guid ConsumableCategoryId { get; set; }
        public ConsumableListCategoryDto ? Category { get; set; }
        public bool IsInStock { get; set; }
    }
}
