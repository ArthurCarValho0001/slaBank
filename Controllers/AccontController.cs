using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string senha)
    {
        return RedirectToAction("Index", "Home");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(string nome, string email, string senha)
    {
        return RedirectToAction("Login");
    }
}