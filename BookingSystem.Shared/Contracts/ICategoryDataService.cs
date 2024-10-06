using BookingSystem.Shared.Components.Pages.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Contracts
{
    public interface ICategoryDataService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();
    }
}
