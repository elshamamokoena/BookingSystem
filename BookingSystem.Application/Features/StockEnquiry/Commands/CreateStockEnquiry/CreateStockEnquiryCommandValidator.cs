using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.StockEnquiry.Commands.CreateStockEnquiry
{
    public class CreateStockEnquiryCommandValidator : AbstractValidator<CreateStockEnquiryCommand>
    {
        public CreateStockEnquiryCommandValidator()
        {
            RuleFor(p => p.BookingId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
