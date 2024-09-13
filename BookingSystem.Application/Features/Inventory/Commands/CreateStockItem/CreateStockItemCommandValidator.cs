using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Inventory.Commands.CreateStockItem
{
    public class CreateStockItemCommandValidator:AbstractValidator<CreateStockItemCommand>
    {
        public CreateStockItemCommandValidator()
        {
            RuleFor(p => p.StockId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.ConsumableId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.Quantity)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.");
        }
    }
}
