using BookingSystem.Shared.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.Contracts
{
    public interface IStockEnquiryDataService
    {
        Task<ApiResponse<Guid>> CreateStockEnquiry(Guid bookingId);
        Task<ApiResponse<Guid>> CreateStockItemEnquiry(Guid consumableId, int Quantity);
    }
}
