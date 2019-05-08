using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FlightServices.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FlightServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private Dictionary<string, FlightsBookingUrl> _bookingUrl;

        public FlightsController()
        {
            _bookingUrl = new Dictionary<string, FlightsBookingUrl>();
            //get a list of booking url from database service
        }

        // GET: api/Flights
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Flights/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // Put: api/Flights
        [HttpPut("book")]
        public async Task<ActionResult<FlightModel>> BookFlight(UserInfo userIfo, FlightModel flight)
        {
            try
            {
                //Get the airline booking url
                if (!_bookingUrl.ContainsKey(flight.Airline))
                {
                    return BadRequest("The airline is not supported.");
                }

                //book ticket
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders
                      .TryAddWithoutValidation("Accept", "application/json");

                    var jsonString = "{\"user\":james}";
                    var inputContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    string url = _bookingUrl[flight.Airline].Url;
                    var response = await client.PutAsync(url, inputContent);

                    if (!response.IsSuccessStatusCode)
                    {
                        return BadRequest("Booking is not successful.");
                    }

                    //try to parse the returned values from result to flight model
                    using (var content = response.Content)
                    {
                        var message = await content.ReadAsStringAsync();
                        //FlightModel flightInfo = JsonConvert.DeserializeObject<FlightModel>(message);
                    }
                }
                return flight;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Fail to book flight.");
            }
        }

        // PUT: api/Flights/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
