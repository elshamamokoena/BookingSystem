using AutoMapper;
using BookingSystem.Application.Features.Categories.GetCategories;
using BookingSystem.Domain.Entities.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryListVm>();
        }
    }
}
