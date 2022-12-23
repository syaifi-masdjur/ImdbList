using ImdbList.web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ImdbList.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private string _api = "";


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {

            //call api here.. 
            //for testing only.. now
            var url = "https://imdb-api.com/en/API/MostPopularMovies/k_48b29ynt";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var Moviesapi = await response.Content.ReadAsStringAsync();
                    var popModel = JsonSerializer.Deserialize<PopularMoviesResultModel>(Moviesapi);
                    if(popModel.items.Count != 0) {
                        popModel.items = popModel.items.GetRange(0, 10);
                    }
                    return View(popModel);
                }
                else
                {
                    return Error();
                }
            }
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}