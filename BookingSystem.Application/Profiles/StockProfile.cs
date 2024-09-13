using AutoMapper;
using BookingSystem.Application.Features.Inventory.Commands.CreateStock;
using BookingSystem.Application.Features.Inventory.Commands.CreateStockItem;
using BookingSystem.Domain.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Profiles
{
    public class StockProfile:Profile
    {
        public StockProfile()
        {
            CreateMap<CreateStockCommand, Stock>();
            CreateMap<Stock, StockDto>();   

            CreateMap<StockItem, StockItemDto>();
            CreateMap<CreateStockItemCommand, StockItem>();
        }
    }
}
