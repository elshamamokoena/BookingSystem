﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookingSystem.Application.Helpers
{
    public class PaginatedList<T> : List<T>
    {
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }
    public bool HasPrevious => (PageIndex > 1);
    public bool HasNext => (PageIndex < TotalPages);
    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        AddRange(items);
    }

    public static async Task<PaginatedList<T>> CreateAsync(
        IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var items = await source.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        return new PaginatedList<T>(items, count, pageNumber, pageSize);
    }
    }
}
