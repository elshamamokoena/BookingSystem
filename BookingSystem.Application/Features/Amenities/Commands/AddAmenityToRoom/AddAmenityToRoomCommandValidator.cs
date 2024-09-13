using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Commands.AddAmenityToRoom
{
    public class AddAmenityToRoomCommandValidator:AbstractValidator<AddAmenityToRoomCommand>
    {
        public AddAmenityToRoomCommandValidator()
        {
            RuleFor(p => p.AmenityId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            RuleFor(p => p.RoomId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}
