using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SEESAFizzBuzz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        [HttpGet]
        // FizzBuzz EndPoint Example //
        // api/fizzbuzz?range=100 //
        public List<string> FizzBuzz([FromQuery] int range = 100)
        {
            List<string> output = new List<string>();

            try
            {
                for (int i = 1; i < range; i++)
                {
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        output.Add("FizzBuzz");
                    }
                    else if (i % 3 == 0)
                    {
                        output.Add("Fizz");
                    }
                    else if (i % 5 == 0)
                    {
                        output.Add("Buzz");
                    }
                    else
                    {
                        output.Add(i.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            // Endpoint returns a list of fizzbuzz characters in required range.
            // The range variable is fetched from the query string.
            return output;
        }
    }
}
