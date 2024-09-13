using BookingSystem.Application.Contracts.Persistence;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiries;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockEnquiry;
using BookingSystem.Application.Features.StockEnquiry.Queries.GetStockItemEnquiries;
using BookingSystem.Application.ResourceParameters;
using BookingSystem.Domain.Entities.Inventory;
using BookingSystem.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Persistence.Repositories
{
    public class StockEnquiryRepository : IStockEnquiryRepository
    {
        private readonly BookingSystemDbContext _context;
        public StockEnquiryRepository(BookingSystemDbContext context)
        {
            _context = context;
        }
        public async Task<StockEnquiry> AddStockEnquiry(StockEnquiry stockItemEnquiry)
        {
           ArgumentNullException.ThrowIfNull(stockItemEnquiry, nameof(stockItemEnquiry));

            
           return ( await _context.StockEnquiries
                .AddAsync(stockItemEnquiry))
                .Entity;
        }

        public async Task<StockItemEnquiry> AddStockItemEnquiry(StockItemEnquiry stockItemEnquiry)
        {
            await _context.StockItemEnquiries.AddAsync(stockItemEnquiry);
            return stockItemEnquiry;
        }

        public void DeleteStockEnquiry(StockEnquiry stockEnquiry)
        {
            _context.StockEnquiries.Remove(stockEnquiry);
        }

        public void DeleteStockItemEnquiry(StockItemEnquiry stockItemEnquiry)
        {
            _context.StockItemEnquiries.Remove(stockItemEnquiry);
        }

        public async Task<IEnumerable<StockEnquiry>> GetStockEnquiriesAsync(GetStockEnquiriesQuery resourceParameters)
        {
            ArgumentNullException.ThrowIfNull(resourceParameters, nameof(resourceParameters));
            var collection = _context.StockEnquiries as IQueryable<StockEnquiry>;

            if (resourceParameters.BookingId != Guid.Empty)
                collection = collection.Where(x => x.BookingId == resourceParameters.BookingId);

            collection = collection
                .Where(x => x.IsApproved == resourceParameters.IsApproved);


            return await collection.
                 Skip((resourceParameters.PageNumber - 1) * resourceParameters.PageSize)
                .Take(resourceParameters.PageSize)
                .ToListAsync();
        }

        public async Task<StockEnquiry> GetStockEnquiryAsync(GetStockEnquiryQuery query)
        {
            var enquiry = _context.StockEnquiries as IQueryable<StockEnquiry>;

            if (query.StockEnquiryId != Guid.Empty)
                enquiry = enquiry.Where(x => x.StockEnquiryId == query.StockEnquiryId);

            if(query.IncludeStockItemEnquiries.HasValue)
                if(query.IncludeStockItemEnquiries.Value)
                    enquiry = enquiry.Include(x => x.StockItemEnquiries);

            if(query.IncludeBooking.HasValue)
                if(query.IncludeBooking.Value)
                    enquiry = enquiry.Include(x => x.Booking);

#pragma warning disable CS8603 // Possible null reference return.
            return await enquiry
                .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.
        }
        public async Task<StockEnquiry> GetStockEnquiryAsync(Guid stockEnquiryId)
        {
            if(stockEnquiryId == Guid.Empty) throw new ArgumentNullException(nameof(stockEnquiryId));

#pragma warning disable CS8603 // Possible null reference return.
            return await _context.StockEnquiries
                .FirstOrDefaultAsync(x => x.StockEnquiryId == stockEnquiryId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<StockItemEnquiry>> GetStockItemEnquiriesAsync(GetStockItemEnquiriesQuery  query)
        {
            if(query.StockEnquiryId == Guid.Empty) throw new ArgumentNullException(nameof(query.StockEnquiryId));

            var collection = _context.StockItemEnquiries as IQueryable<StockItemEnquiry>;

            collection = collection.Where(x => x.StockEnquiryId == query.StockEnquiryId);

            if(query.IsApproved.HasValue)
                collection = collection.Where(x => x.IsApproved == query.IsApproved);


            return await collection
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();
          
        }

        public async Task<StockItemEnquiry> GetStockItemEnquiryAsync(Guid stockItemEnquiryId)
        {
            if(stockItemEnquiryId == Guid.Empty) throw new ArgumentNullException(nameof(stockItemEnquiryId));

#pragma warning disable CS8603 // Possible null reference return.
            return await _context.StockItemEnquiries
                .FirstOrDefaultAsync(x => x.StockItemEnquiryId == stockItemEnquiryId);
#pragma warning restore CS8603 // Possible null reference return.

        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> StockEnquiryExistsAsync(Guid stockEnquiryId)
        {
            if(stockEnquiryId == Guid.Empty) throw new ArgumentNullException(nameof(stockEnquiryId));
            return _context.StockEnquiries
                .AnyAsync(x => x.StockEnquiryId == stockEnquiryId);
        }

        public Task<bool> StockItemEnquiryExistsAsync(Guid stockItemEnquiryId)
        {
            if(stockItemEnquiryId == Guid.Empty) throw new ArgumentNullException(nameof(stockItemEnquiryId));
            return _context.StockItemEnquiries
                .AnyAsync(x => x.StockItemEnquiryId == stockItemEnquiryId);
        }

        public void UpdateStockEnquiry(StockEnquiry stockItemEnquiry)
        {
            //ct
        }

        public void UpdateStockItemEnquiry(StockItemEnquiry stockItemEnquiry)
        {
            //ct
        }
    }
}
