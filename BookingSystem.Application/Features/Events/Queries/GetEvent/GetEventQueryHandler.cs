using AutoMapper;
using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Exceptions;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiries;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiry;
using BookingSystem.Domain.Entities.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Features.Events.Queries.GetEvent
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQuery, EventVm>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IStockEnquiryRepository _stockEnquryRepository;
        private readonly IMapper _mapper;

        public GetEventQueryHandler(IAsyncRepository<Event> eventRepository,
            IMapper mapper,
            IStockEnquiryRepository stockRepository)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
            _stockEnquryRepository = stockRepository;
        }
        public async Task<EventVm> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            if (request.EventId == Guid.Empty)
                throw new BadRequestException($"Event Id ({request.EventId}) is invalid:");

            var @event = await _eventRepository
                    .GetEntityAsync(request.EventId);

            if (@event == null)
                throw new NotFoundException("Event", request.EventId);

            var eventToReturn = _mapper.Map<EventVm>(@event);


            return eventToReturn;
        }
    }
}
