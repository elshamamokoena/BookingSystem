using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.CreateStockItemEnquiry
{
    public class CreateStockItemEnquiryCommandValidator:AbstractValidator<CreateStockItemEnquiryCommand>
    {
        public CreateStockItemEnquiryCommandValidator()
        {
            RuleFor(x => x.StockEnquiryId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(x => x.ConsumableId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} has to be greater than or equal to zero.");
        }
    }
}
