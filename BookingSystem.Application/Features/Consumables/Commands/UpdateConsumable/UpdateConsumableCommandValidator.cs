using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Consumables.Commands.UpdateConsumable
{
    public class UpdateConsumableCommandValidator:AbstractValidator<UpdateConsumableCommand>
    {
        public UpdateConsumableCommandValidator()
        {
            RuleFor(p => p.ConsumableId)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull();
            RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.ConsumableCategoryId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }

    }
}
