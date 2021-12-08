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
        private CinemaContext context;

        public TicketService(CinemaContext context)
        {
            this.context = context;
        }

        public async Task<bool> AddBooking(Booking booking)
        {
            BookingRepository bookingRepository = new(context);
            var place = await bookingRepository.FindByConditionAsync(x => x.Place.RowNumber == booking.Place.RowNumber && x.Place.Row == booking.Place.Row);
            if (place.Count > 0) return false;

            await bookingRepository.CreateAsync(booking);
            return true;

        }

        public async Task<List<Booking>> SessionOnTheTicket(Session session)
        {
            BookingRepository bookingRepository = new(context);
            var bookSession = await bookingRepository.FindByConditionAsync(x => x.Session.Id == session.Id);
            var book = (List<Booking>)bookSession;
            return book;
        }


        public async Task<IReadOnlyCollection<Booking>> GetAll()
        {
            BookingRepository bookingRepository = new(context);
            return await bookingRepository.GetAllAsync();
        }



    }
}
