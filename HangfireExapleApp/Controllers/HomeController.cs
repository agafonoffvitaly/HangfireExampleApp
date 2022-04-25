using Microsoft.AspNetCore.Mvc;

namespace HangfireExapleApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("SomeMethod")]
        public string SomeMethod()
        {
            return "Ok";
        }
    }
}
