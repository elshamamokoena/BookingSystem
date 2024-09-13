using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.UpdateStockEnquiry
{
    public class UpdateStockEnquiryCommandValidator:AbstractValidator<UpdateStockEnquiryCommand>
    {
        public UpdateStockEnquiryCommandValidator()
        {
            RuleFor(p => p.StockEnquiryId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.IsApproved)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
