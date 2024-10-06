using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.ConferenceRooms.Commands.DeleteConferenceRoom
{
    public class DeleteConferenceRoomCommandHandler : IRequestHandler<DeleteConferenceRoomCommand, bool>
    {
        private readonly IConferenceRoomRepository _conferenceRoomRepository;
        private readonly IMapper _mapper;
        public DeleteConferenceRoomCommandHandler(IMapper mapper,
            IConferenceRoomRepository conferenceRoomRepository)
        {
            _mapper = mapper;
            _conferenceRoomRepository = conferenceRoomRepository;
        }
        public async Task<bool> Handle(DeleteConferenceRoomCommand request, CancellationToken cancellationToken)
        {
            var conferenceRoomToDelete = await _conferenceRoomRepository.GetEntityAsync(request.ConferenceRoomId);
             _conferenceRoomRepository.DeleteEntity(conferenceRoomToDelete);
            return await _conferenceRoomRepository.SaveChangesAsync();
        }
    }
}
