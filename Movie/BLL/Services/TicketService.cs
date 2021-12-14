using DLL.Context;
using DLL.Models;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TicketService
    {
        BookingRepository bookingRepository;

        public TicketService(BookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public async Task<bool> AddBookingAsync(Booking booking)
        {
            var place = await bookingRepository.FindByConditionAsync(x => x.Place.RowNumber == booking.Place.RowNumber && x.Place.Row == booking.Place.Row);
            if (place.Count > 0) return false;

            await bookingRepository.CreateAsync(booking);
            return true;
        }

        public async Task<List<Booking>> SessionOnTheTicketAsync(Session session)
        {
            return (await bookingRepository.FindByConditionAsync(x => x.Session.Id == session.Id))?.ToList();
        }


        public async Task<IReadOnlyCollection<Booking>> GetAllAsync()
        {
            return await bookingRepository.GetAllAsync();
        }

        public async Task<bool> IsPaidAsync(Booking booking)
        {
            return await bookingRepository.IsPaidAsync(booking);
        }

    }
}
