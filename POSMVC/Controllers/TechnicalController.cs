using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POSMVC.Controllers
{

    public class TechnicalController : Controller
    {
        // GET: /<controller>/
        [Route("Technical/{statusCode}")]
        public IActionResult StatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, resource you've requested is not found.";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Sorry, resource you've requested is not found.";
                    break;
            }
            return View();
        }
    }
}
