using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

using reCaptcha.Models;

namespace reCaptcha.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Verify(string token, string secret, string verificationUrl)
        {
            var httpClient = new HttpClient();

            var res = await httpClient.PostAsync(
                $"{verificationUrl}?secret={secret}&response={token}",
                null                
            );

            return Ok(await res.Content.ReadAsStringAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}