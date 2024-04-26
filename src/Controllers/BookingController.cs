using Microsoft.AspNetCore.Mvc;
using add_db.Data;
using System;
using System.Collections.Generic;

namespace add_db.controller
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private IAnonymousCampingDataContext _data;

        public BookingController(IAnonymousCampingDataContext data)
        {
            _data = data;
        }

        [HttpPost]
        public ActionResult Post(Booking booking)
        {
            _data.AddBooking(booking);
            return Ok("Booking created");
        }

        [HttpGet]
        public ActionResult<IEnumerable<Booking>> GetBookings()
        {
            return Ok(_data.GetBookings());
        }

        [HttpGet("ByUserId/{userId}")]
        public ActionResult<IEnumerable<Booking>> GetBookingsByUserId(int userId)
        {
            return Ok(_data.GetBookingsByUserId(userId));
        }

        [HttpGet("BySpotId/{spotId}")]
        public ActionResult<IEnumerable<Booking>> GetBookingsBySpotId(int spotId)
        {
            return Ok(_data.GetBookingsBySpotId(spotId));
        }

        [HttpGet("{id}")]
        public ActionResult<Booking> GetBookingById(int id)
        {
            var booking = _data.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBooking(int id, Booking updatedBooking)
        {
            _data.UpdateBooking(id, updatedBooking);
            return Ok("Booking updated");
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBooking(int id)
        {
            _data.DeleteBooking(id);
            return Ok("Booking deleted");
        }

        [HttpGet("{id}/BookingDate")]
        public ActionResult<DateTime> GetBookingDate(int id)
        {
            var booking = _data.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking.BookingDate);
        }

        [HttpGet("{id}/CheckInOutDates")]
        public ActionResult<Tuple<DateTime, DateTime>> GetCheckInOutDates(int id)
        {
            var booking = _data.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(Tuple.Create(booking.CheckInDate, booking.CheckOutDate));
        }

        [HttpGet("{id}/TotalPrice")]
        public ActionResult<decimal> GetTotalPrice(int id)
        {
            var booking = _data.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking.TotalPrice);
        }
    }
}
