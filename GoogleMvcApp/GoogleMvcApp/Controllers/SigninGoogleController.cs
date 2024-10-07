using Microsoft.AspNetCore.Mvc;

namespace GoogleMvcApp.Controllers
{
    [Route("[controller]", Name = "signin-google")]
    public class SigninGoogleController : Controller
    {
        public IActionResult Index()
        {


            return View();
        }
    }
}
