using AutoMapper;
using Blazored.LocalStorage;
using BookingSystem.Shared.Components.Pages.Consumables;
using BookingSystem.Shared.Components.Pages.Events.EditEvents;
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
    public class ConsumableDataService : DataServiceBase, IConsumableDataService
    {
        private readonly IMapper _mapper;
        public ConsumableDataService(IClient client, ILocalStorageService localStorageService, IMapper mapper, NavigationManager navigationManager) 
            : base(client, localStorageService, navigationManager)
        {
            _mapper = mapper;
        }
        public async Task<List<ConsumableCategoryViewModel>> GetConsumableCategories()
        {
            var consumableCategories = await _client.GetAllConsumableCategoriesAsync();
            return _mapper.Map<List<ConsumableCategoryViewModel>>(consumableCategories);
        }

        public async Task<List<ConsumableViewModel>> GetConsumables(bool? includeCategory, int? pageNumber, int? pageSize)
        {
            var consumables = await _client.GetConsumablesAsync(includeCategory, pageNumber, pageSize);
            return _mapper.Map<List<ConsumableViewModel>>(consumables);
        }
    }
}
