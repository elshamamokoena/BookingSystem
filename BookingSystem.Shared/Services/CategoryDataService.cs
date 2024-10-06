using AutoMapper;
using Blazored.LocalStorage;
using BookingSystem.Shared.Components.Pages.Categories;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Services.Base;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Services
{
    public class CategoryDataService : DataServiceBase, ICategoryDataService
    {
        private readonly IMapper _mapper;
        public CategoryDataService(IMapper mapper, 
            IClient client, ILocalStorageService localStorage, NavigationManager navigationManager) 
            : base(client,localStorage, navigationManager)
        {
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            var categories = await _client.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
        }

    }
}
