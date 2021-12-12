﻿using DLL.Context;
using DLL.Models;
using DLL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class BookingRepository : BaseRepository<Booking>
    {
        public BookingRepository(CinemaContext cinemaContext) : base(cinemaContext)
        {

        }

        public override async Task<IReadOnlyCollection<Booking>> GetAllAsync()
        {
            return await this.Entities.Include(x => x.Employee).Include(x => x.Place).Include(x => x.Session).ToListAsync().ConfigureAwait(false);
        }

        public override async Task<IReadOnlyCollection<Booking>> FindByConditionAsync(Expression<Func<Booking, bool>> predicat)
        {
            return await this.Entities.Where(predicat).Include(x => x.Employee).Include(x => x.Place).Include(x => x.Session).ToListAsync().ConfigureAwait(false);
        }

    }
}
