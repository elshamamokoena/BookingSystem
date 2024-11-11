using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Cart.Commands.CreateCartItem
{
    public class CreateCartItemCommandValidator:AbstractValidator<CreateCartItemCommand>
    {
        public CreateCartItemCommandValidator()
        {
            RuleFor(c => c.CartId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(c => c.ConsumableId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(c => c.Quantity)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}
