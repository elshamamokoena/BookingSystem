using AutoMapper;
using Blazored.LocalStorage;
using BookingSystem.ClassLibrary;
using BookingSystem.Shared.Components.Pages.Consumables;
using BookingSystem.Shared.Components.Pages.Events.EditEvents;
using BookingSystem.Shared.Contracts;
using BookingSystem.Shared.Models.Consumables;
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

        public async Task<ApiResponse<Guid>> CreateConsumableAsync(ConsumableViewModel consumable)
        {
            try
            {
                CreateConsumableCommand command =  _mapper.Map<CreateConsumableCommand>(consumable);
                var newId = await _client.CreateConsumableAsync(command);
                return new ApiResponse<Guid>() { Data = newId, IsSuccess = true, Message = "Consumable created successfully" };
            }catch(ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> DeleteConsumable(Guid consumableId)
        {
            try
            {
                DeleteConsumableCommand command = new DeleteConsumableCommand { ConsumableId = consumableId };
                await _client.DeleteConsumableAsync(command);
                return new ApiResponse<Guid>() { IsSuccess = true };
            }catch(ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ConsumableViewModel> GetConsumableAsync(Guid consumableId, bool? includeCategory)
        {
            var consumable = await _client.GetConsumableAsync(consumableId, includeCategory);
            return _mapper.Map<ConsumableViewModel>(consumable);
        }

        public async Task<List<ConsumableCategoryViewModel>> GetConsumableCategoriesAsync()
        {
            var consumableCategories = await _client.GetAllConsumableCategoriesAsync();

            return _mapper.Map<List<ConsumableCategoryViewModel>>(consumableCategories);
        }

        public async Task<PagedList<ConsumableViewModel>> GetConsumablesAsync(Guid? consumableCategoryId,bool? includeCategory, int? pageNumber, int? pageSize)
        {
            var consumables = await _client.GetConsumablesAsync(consumableCategoryId,includeCategory, pageNumber,pageSize);
                 return new PagedList<ConsumableViewModel>
                (_mapper.Map<List<ConsumableViewModel>>(consumables.Consumables),
                consumables.Count, 
                consumables.PageNumber,
                consumables.PageSize);

        }

        public async Task<ApiResponse<Guid>> UpdateConsumableAsync(ConsumableViewModel consumable)
        {
            try
            {
                UpdateConsumableCommand command = _mapper.Map<UpdateConsumableCommand>(consumable);
                await _client.UpdateConsumableAsync(command);
                return new ApiResponse<Guid>() { IsSuccess = true, Message = "Consumable update successfully." };
            }
            catch(ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
