using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IntroToDotNetAPI.Models;
using IntroToDotNetAPI.Data;

namespace IntroToDotNetAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly APIContext _context;

        public HotelBookingController(APIContext context)
        {
            _context = context;

        }

        //Create/Editing

        [HttpPost]
        public JsonResult CreateEdit(HotelBooking booking)
        {
            if(booking.Id == 0)
            {
                _context.Bookings.Add(booking);
            }
            else
            {
                var bookingInDb = _context.Bookings.Find(booking.Id);

                if (bookingInDb == null)
                    return new JsonResult(NotFound());

                bookingInDb = booking;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(booking));

        }

        //GET
        [HttpGet]
        public JsonResult Get(int id)
        {

            var result = _context.Bookings.Find(id);

            //var result = _context.Bookings.ToList();

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));

        }

        //DELETE
        [HttpDelete]

        public JsonResult Delete(int id)
        {
            var result = _context.Bookings.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Bookings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());


        }

        //GetAll

        [HttpGet()]

        public JsonResult GetAll()
        {
            

            var result = _context.Bookings.ToList();

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));

        }
    }
}
