using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.UpdateStockItemEnquiry
{
    public class UpdateStockItemEnquiryCommandValidator:AbstractValidator<UpdateStockItemEnquiryCommand>
    {
        public UpdateStockItemEnquiryCommandValidator()
        {
            RuleFor(x => x.StockEnquiryId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
            RuleFor(x => x.StockItemEnquiryId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} has to be greater than or equal to zero");
        }
    }
}
