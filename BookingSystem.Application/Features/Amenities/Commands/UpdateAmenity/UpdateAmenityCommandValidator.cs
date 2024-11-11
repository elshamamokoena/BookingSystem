using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Commands.UpdateAmenity
{
    public class UpdateAmenityCommandValidator : AbstractValidator<UpdateAmenityCommand>
    {
        public UpdateAmenityCommandValidator()
        {
            RuleFor(p => p.Amount)
                .NotNull().WithMessage("{PropertyName} is required");
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.IsAvailable)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.ConferenceRoomId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
        }
    }
}
