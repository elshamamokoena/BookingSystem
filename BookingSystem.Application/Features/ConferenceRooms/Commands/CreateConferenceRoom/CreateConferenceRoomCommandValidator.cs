using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Commands.CreateConferenceRoom
{
    public class CreateConferenceRoomCommandValidator:AbstractValidator<CreateConferenceRoomCommand>
    {
        public CreateConferenceRoomCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Capacity).GreaterThan(0).WithMessage("Capacity must be greater than 0");
        }
    }
}
