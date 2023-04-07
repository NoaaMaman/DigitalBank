using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
