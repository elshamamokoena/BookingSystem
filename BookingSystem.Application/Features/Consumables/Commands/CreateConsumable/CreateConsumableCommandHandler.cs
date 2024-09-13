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

namespace BookingSystem.Application.Features.Consumables.Commands.CreateConsumable
{
    public class CreateConsumableCommandHandler : IRequestHandler<CreateConsumableCommand, CreateConsumableCommandResponse>
    {
        private readonly IConsumableRepository _consumableRepository;
        private readonly IMapper _mapper;
        public CreateConsumableCommandHandler(IConsumableRepository consumableRepository,
            IMapper mapper)
        {
            _consumableRepository = consumableRepository;
            _mapper = mapper;
        }
        public async Task<CreateConsumableCommandResponse> Handle(CreateConsumableCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateConsumableCommandResponse();
            var validator = new CreateConsumableCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            if(!await _consumableRepository.ConsumableCategoryExists(request.ConsumableCategoryId))
                throw new NotFoundException(nameof(ConsumableCategory),request.ConsumableCategoryId);

            var consumable = await _consumableRepository.AddConsumableAsync(_mapper.Map<Consumable>(request));
            await _consumableRepository.SaveChangesAsync();
            response.Consumable = _mapper.Map<ConsumableDto>(consumable);
            return response;


      
        }
    }
    
    
}
