using GestaoInstituto.WebApp.Helper;
using Microsoft.AspNetCore.Mvc;

namespace GestaoInstituto.WebApp.Controllers
{
    [BasicAuthorize()]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
