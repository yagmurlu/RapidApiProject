using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using RapidApiProject.Models;

namespace RapidApiProject.Controllers
{
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index(string adult="1",string child="1",string checkindate="2023-09-27"
            ,string checkoutdate="2023-09-28",string roomnumber="1",string cityID="-553173")
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v2/hotels/search?order_by=popularity&adults_number={adult}&checkin_date={checkindate}&filter_by_currency=USD&dest_id={cityID}&locale=en-gb&checkout_date={checkoutdate}&units=metric&room_number={roomnumber}&dest_type=city&include_adjacency=true&children_number={child}&page_number=0&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1"),
                Headers =
    {
        { "X-RapidAPI-Key", "fd47ccc582msh008dbca721239a6p17f90bjsn71335b4037fc" },
        { "X-RapidAPI-Host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var value= JsonConvert.DeserializeObject<HotelListViewModel>(body);
                return View(value.results.ToList());      
            }
        }
      
    }
}
