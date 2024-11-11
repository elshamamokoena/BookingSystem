using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Domain.Entities.Amenities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Amenities.Commands.DeleteAmenity
{
    public class DeleteAmenityCommandHandler : IRequestHandler<DeleteAmenityCommand,Unit>
    {
        private readonly IAmenityRepository _amenityRepository;
        public DeleteAmenityCommandHandler(IAmenityRepository amenityRepository)
        {
            _amenityRepository = amenityRepository;
        }
        public async Task<Unit> Handle(DeleteAmenityCommand request, CancellationToken cancellationToken)
        {
            if(!await _amenityRepository.EntityExistsAsync(request.AmenityId))
                throw new NotFoundException(nameof(Amenity), request.AmenityId);

            var amenityToDelete = await _amenityRepository.GetEntityAsync(request.AmenityId);
             _amenityRepository.DeleteEntity(amenityToDelete);
            await _amenityRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
