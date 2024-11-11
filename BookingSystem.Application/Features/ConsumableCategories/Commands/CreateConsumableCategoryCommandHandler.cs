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

namespace BookingSystem.Application.Features.ConsumableCategories.Commands
{
    public class CreateConsumableCategoryCommandHandler : IRequestHandler<CreateConsumableCategoryCommand, Guid>
    {
        private readonly IAsyncRepository<ConsumableCategory> _consumableCategoryRepository;
        private readonly IMapper _mapper;

        public CreateConsumableCategoryCommandHandler(IAsyncRepository<ConsumableCategory> consumableCategoryRepository, IMapper mapper)
        {
            _consumableCategoryRepository = consumableCategoryRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateConsumableCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateConsumableCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var category = await _consumableCategoryRepository
                .AddAsync(_mapper.Map<ConsumableCategory>(request));
            await _consumableCategoryRepository.SaveChangesAsync();
            return category.ConsumableCategoryId;
        }
    }
}
