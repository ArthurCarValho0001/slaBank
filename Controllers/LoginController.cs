using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class LoginController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}