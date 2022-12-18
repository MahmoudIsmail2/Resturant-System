using Microsoft.AspNetCore.Mvc;

namespace ResoApp.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
