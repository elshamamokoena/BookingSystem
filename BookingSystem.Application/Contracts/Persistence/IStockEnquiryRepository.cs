using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiries;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiry;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockItemEnquiries;
using BookingSystem.Application.ResourceParameters;
using BookingSystem.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Contracts.Persistence
{
    public interface IStockEnquiryRepository
    {
        Task<StockEnquiry> AddStockEnquiry(StockEnquiry stockItemEnquiry);
        Task<bool> StockEnquiryExistsAsync(Guid stockEnquiryId);
        Task<StockEnquiry> GetStockEnquiryAsync(GetStockEnquiryQuery query);
        Task<StockEnquiry> GetStockEnquiryAsync(Guid stockEnquiryId);

        Task<IEnumerable<StockEnquiry>> GetStockEnquiriesAsync(GetStockEnquiriesQuery resourceParameters);
        void DeleteStockEnquiry(StockEnquiry stockEnquiry);
        Task<bool> SaveChangesAsync();
        void UpdateStockEnquiry(StockEnquiry stockEnquiry);

        // stockitem enquiries

        Task<StockItemEnquiry> AddStockItemEnquiry(StockItemEnquiry stockItemEnquiry);
        Task<StockItemEnquiry> GetStockItemEnquiryAsync(Guid stockItemEnquiryId);
        Task<IEnumerable<StockItemEnquiry>> GetStockItemEnquiriesAsync(GetStockItemEnquiriesQuery resourceParameters);
        void UpdateStockItemEnquiry(StockItemEnquiry stockItemEnquiry);
        void DeleteStockItemEnquiry(StockItemEnquiry stockItemEnquiry);
        Task<bool> StockItemEnquiryExistsAsync(Guid stockItemEnquiryId);
    }
}
