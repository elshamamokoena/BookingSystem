using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Contracts.Services;
using BookingSystem.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Cart.Commands.CreateCart
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, Guid>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CreateCartCommandHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCartCommandValidator();
            var validationResult = await validator.ValidateAsync(request,cancellationToken);
            if(validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var carts = await _cartRepository.ListAllAsync();
            if (carts.Any(x => x.UserId == request.UserId))
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                return carts.FirstOrDefault(c=>c.UserId == request.UserId).CartId;
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            var cart = _mapper.Map<Domain.Entities.InternalCart.Cart>(request);
            cart = await _cartRepository.AddAsync(cart);
            await _cartRepository.SaveChangesAsync();
            return cart.CartId;

        }
    }
}
