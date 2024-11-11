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
    public class CreateConsumableCommandHandler : IRequestHandler<CreateConsumableCommand, Guid>
    {
        //private readonly IConsumableRepository _consumableRepository;
        private readonly IAsyncRepository<Consumable> _consumableRepository;
        private readonly IAsyncRepository<ConsumableCategory> _consumableCategoryRepository;
        private readonly IMapper _mapper;
        public CreateConsumableCommandHandler(IAsyncRepository<Consumable> consumableRepository, IAsyncRepository<ConsumableCategory> consumableCategoryRepository,
            IMapper mapper) 

        {
            _consumableRepository = consumableRepository;
            _consumableCategoryRepository = consumableCategoryRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateConsumableCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateConsumableCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            if(!await _consumableCategoryRepository.EntityExistsAsync(request.ConsumableCategoryId))
                throw new NotFoundException(nameof(ConsumableCategory),request.ConsumableCategoryId);

            var consumable = await _consumableRepository.AddAsync(_mapper.Map<Consumable>(request));
            await _consumableRepository.SaveChangesAsync();

            return consumable.ConsumableId;
        }
    }
    
    
}
