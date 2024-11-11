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

namespace BookingSystem.Application.Features.Consumables.Commands.UpdateConsumable
{
    public class UpdateConsumableCommandHandler : IRequestHandler<UpdateConsumableCommand, Unit>
    {
        private readonly IConsumableRepository _consumableRepository;
        private readonly IMapper _mapper;
        public UpdateConsumableCommandHandler(IConsumableRepository consumableRepository, 
            IMapper mapper)
        {
            _consumableRepository = consumableRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateConsumableCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateConsumableCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var consumableToUpdate = await _consumableRepository.GetEntityAsync(request.ConsumableId);

            _mapper.Map(request, consumableToUpdate,typeof(UpdateConsumableCommand), typeof(Consumable) );

            _consumableRepository.UpdateEntity(consumableToUpdate);
            await _consumableRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
