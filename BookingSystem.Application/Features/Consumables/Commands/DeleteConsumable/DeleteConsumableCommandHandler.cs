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

namespace BookingSystem.Application.Features.Consumables.Commands.DeleteConsumable
{
    public class DeleteConsumableCommandHandler : IRequestHandler<DeleteConsumableCommand, Unit>
    {
        public IAsyncRepository<Consumable> _consumableRepository;
        private readonly IMapper _mapper;
        public DeleteConsumableCommandHandler(IAsyncRepository<Consumable> consumableRepository, IMapper mapper)
        {
            _consumableRepository = consumableRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteConsumableCommand request, CancellationToken cancellationToken)
        {
            var consumableToDelete = await _consumableRepository.GetEntityAsync(request.ConsumableId);

            if (consumableToDelete == null)
                throw new NotFoundException(nameof(Consumable), request.ConsumableId);

            _consumableRepository.DeleteEntity(consumableToDelete);

            await _consumableRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
