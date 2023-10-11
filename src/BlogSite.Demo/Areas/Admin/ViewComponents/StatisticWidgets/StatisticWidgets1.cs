using BlogSite.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace BlogSite.Demo.Areas.Admin.ViewComponents.StatisticWidgets
{
    public class StatisticWidgets1:ViewComponent
    {
        IBlogService _blogService;
        IContactService _contactService;
        ICommentService _commentService;

        public StatisticWidgets1(IBlogService blogService, IContactService contactService, ICommentService commentService)
        {
            _blogService = blogService;
            _contactService = contactService;
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string json = (new WebClient()).DownloadString("https://api.openweathermap.org/data/2.5/weather?q=Ismayilli&appid=0202b908ccb9aa3cc8cd1ef6721e162f&lang=az&units=metric");
                var data = JsonConvert.DeserializeObject<Root>(json);
                ViewBag.degree = data?.main.temp;
                ViewBag.description = data?.weather[0].description;
            }
            catch (Exception ex)
            {

            }
            ViewBag.BlogsCount = _blogService.values.Count();
            ViewBag.Messages = _contactService.values.Count();
            ViewBag.Comments= _commentService.values.Count();

            return View();  
        }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
    }

    public class Root
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public double visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public double dt { get; set; }
        public Sys sys { get; set; }
        public double timezone { get; set; }
        public double id { get; set; }
        public string name { get; set; }
        public double cod { get; set; }
    }

    public class Sys
    {
        public double type { get; set; }
        public double id { get; set; }
        public string country { get; set; }
        public double sunrise { get; set; }
        public double sunset { get; set; }
    }

    public class Weather
    {
        public double id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
        public double gust { get; set; }
    }
}
