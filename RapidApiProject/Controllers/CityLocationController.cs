using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiProject.Models;

namespace RapidApiProject.Controllers
{
    public class CityLocationController : Controller
    {
        public async Task<IActionResult> Index(string cityname="London")
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={cityname}&locale=tr"),
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
                var value=JsonConvert.DeserializeObject<List<LocationCityNameViewModel>>(body);
                return View(value.Take(1).ToList());
            }
          
        }
    }
}
