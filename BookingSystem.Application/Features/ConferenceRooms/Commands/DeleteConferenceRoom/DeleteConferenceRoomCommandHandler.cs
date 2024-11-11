using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Domain.Entities.ConferenceRooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Commands.DeleteConferenceRoom
{
    public class DeleteConferenceRoomCommandHandler : IRequestHandler<DeleteConferenceRoomCommand, Unit>
    {
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IMapper _mapper;
        public DeleteConferenceRoomCommandHandler(IMapper mapper,
            IConferenceRoomRepository conferenceRoomRepository)
        {
            _mapper = mapper;
            _conferenceRoomRepository = conferenceRoomRepository;
        }
        public async Task<Unit> Handle(DeleteConferenceRoomCommand request, CancellationToken cancellationToken)
        {
            var conferenceRoomToDelete = await _conferenceRoomRepository.GetEntityAsync(request.ConferenceRoomId);
            if (conferenceRoomToDelete == null)
                throw new NotFoundException(nameof(ConferenceRoom), request.ConferenceRoomId);
            _conferenceRoomRepository.DeleteEntity(conferenceRoomToDelete);
             await _conferenceRoomRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
