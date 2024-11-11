using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Commands.UpdateConferenceRoom.UpdateConferenceRoom
{
    public class UpdateConferenceRoomCommandValidator:AbstractValidator<UpdateConferenceRoomCommand>
    {
        public UpdateConferenceRoomCommandValidator()
        {
            RuleFor(p => p.ConferenceRoomId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Capacity)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than 0.");

            RuleFor(p => p.Description)
                .MaximumLength(200)
                .WithMessage("{PropertyName} must not exceed 200 characters.");

            RuleFor(p => p.IsAvailable)
                .NotNull();

          
        }
    }
}
