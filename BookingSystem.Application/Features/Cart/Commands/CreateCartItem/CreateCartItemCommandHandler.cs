using BookingSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Cart.Commands.CreateCartItem
{
    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommand, Guid>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IConsumableRepository _consumableRepository;
        public Task<Guid> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
