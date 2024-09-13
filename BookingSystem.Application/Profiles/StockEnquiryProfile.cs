using AutoMapper;
using BookingSystem.Application.Features.StockEnquiry.Commands.CreateStockEnquiry;
using BookingSystem.Application.Features.StockEnquiry.Commands.CreateStockItemEnquiry;
using BookingSystem.Application.Features.StockEnquiry.Commands.UpdateStockItemEnquiry;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiries;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiry;
using BookingSystem.Domain.Entities.Inventory;

namespace BookingSystem.Application.Profiles
{
    public class StockEnquiryProfile:Profile
    {
        public StockEnquiryProfile()
        {
            CreateMap<CreateStockEnquiryCommand, Domain.Entities.Inventory.StockEnquiry>();
            CreateMap<Domain.Entities.Inventory.StockEnquiry, CreateStockEnquiryCommandResponse>()
                .ForMember(dest => dest.StockEnquiry, opt => opt.MapFrom(src => src));
            CreateMap<Domain.Entities.Inventory.StockEnquiry, StockEnquiryDto>();
            CreateMap<Domain.Entities.Inventory.StockEnquiry, StockEnquiryVm>();
            CreateMap<Domain.Entities.Inventory.StockItemEnquiry, StockItemEnquiryDto>();
            CreateMap<Domain.Entities.Inventory.StockEnquiry, ForListStockEnquiryDto>();

            // stockitem enquiries
            CreateMap<CreateStockItemEnquiryCommand ,Domain.Entities.Inventory.StockItemEnquiry>();
            CreateMap<Domain.Entities.Inventory.StockItemEnquiry, CreateStockItemEnquiryCommandResponse>()
                .ForMember(dest => dest.StockItemEnquiry, opt => opt.MapFrom(src => src));
            //CreateMap<Domain.Entities.Inventory.StockItemEnquiry, StockItemEnquiryDto>();

            CreateMap<UpdateStockItemEnquiryCommand, StockItemEnquiry>();
        }
    }
}
