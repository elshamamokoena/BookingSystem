using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Inventory.Commands.UpdateStockItem
{
    public class UpdateStockItemCommandValidator:AbstractValidator<UpdateStockItemCommand>
    {
        public UpdateStockItemCommandValidator()
        {
            RuleFor(p => p.StockItemId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(p => p.Quantity)
                .NotEmpty().WithMessage("Quantity cannot be zero.")
                .NotNull();
        }
    }
}
