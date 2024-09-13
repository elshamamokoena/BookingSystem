using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Domain.Entities.Consumables;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Consumables.Commands.CreateConsumableCategory
{
    public class CreateConsumableCategoryCommandHandler : IRequestHandler<CreateConsumableCategoryCommand, CreateConsumableCategoryCommandResponse>
    {
        private readonly IConsumableRepository _consumableCategoryRepository;
        private readonly IMapper _mapper;
        public CreateConsumableCategoryCommandHandler(IConsumableRepository consumableCategoryRepository,
            IMapper mapper)
        {
            _consumableCategoryRepository = consumableCategoryRepository;
            _mapper = mapper;
        }   
        public async Task<CreateConsumableCategoryCommandResponse> Handle(CreateConsumableCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateConsumableCategoryCommandResponse();
            var validator = new CreateConsumableCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count()>0)
                throw new ValidationException(validationResult);

            var consumableCategory = _mapper.Map<ConsumableCategory>(request);
            consumableCategory = await _consumableCategoryRepository.AddConsumableCategoryAsync(consumableCategory);
            await _consumableCategoryRepository.SaveChangesAsync();
            response.ConsumableCategory = _mapper.Map<ConsumableCategoryDto>(consumableCategory);
            response.Message = "Consumable Category Created Successfully";
            return response;



        }
    }

}
