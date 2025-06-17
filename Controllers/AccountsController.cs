using Microsoft.AspNetCore.Mvc;
using Poultry_management_System.Models;

namespace Poultry_management_System.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult LoginPage()
        {
            return View();
        }

        public IActionResult RegisterPage()
        {
            return View();
        }
    }
}
