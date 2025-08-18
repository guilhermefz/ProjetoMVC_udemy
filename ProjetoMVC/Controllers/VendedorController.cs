using Microsoft.AspNetCore.Mvc;

namespace ProjetoMVC.Controllers
{
    public class VendedorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
