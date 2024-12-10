using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ShoppingListWEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string webRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            string filePath = Path.Combine(webRootPath, "index.html");

            return PhysicalFile(filePath, "text/html");
        }
    }
}