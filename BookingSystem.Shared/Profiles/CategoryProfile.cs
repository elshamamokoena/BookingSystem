using AutoMapper;
using BookingSystem.Shared.Components.Pages.Categories;
using BookingSystem.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryListVm, CategoryViewModel>();
        }
    }
}
