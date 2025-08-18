using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class DepartamentoController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> list = new List<Departamento>();
            list.Add(new Departamento() { Id = 1, Nome = "Eletronicos" });
            list.Add(new Departamento() { Id = 2, Nome = "Fashion" });
            return View(list);
        }
    }
}
