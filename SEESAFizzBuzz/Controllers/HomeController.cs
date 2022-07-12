using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SEESAFizzBuzz.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace SEESAFizzBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Function that returns the FizzBuzz View
        public async Task<IActionResult> ShowFizzBuzz(int range)
        {
            // Getting baseUrl
            string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

            // Initialize list to store values from API
            List<string>? fizzbuzzList = new List<string>();

            // Using statement to create a Http client for retrieving values from API
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to fetch data 
                HttpResponseMessage result = await client.GetAsync($"api/fizzbuzz?range={range}");

                //Checking the response is successful or not which is sent using HttpClient  
                if (result.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from api   
                    var res = result.Content.ReadAsStringAsync().Result;

                    //Deserializing the response
                    fizzbuzzList = JsonConvert.DeserializeObject<List<string>>(res);

                }
            }
            return View(fizzbuzzList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}