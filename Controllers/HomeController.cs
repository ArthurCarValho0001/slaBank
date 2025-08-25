using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using MySql.Data.MySqlClient;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string message;
            var bancoDados = new DataBase();

            try
            {
                using (MySqlConnection conn = bancoDados.GetConnection())
                {
                    conn.Open();
                    message = "Finalmente esse trem deu certo";
                }
            }
            catch (Exception ex)
            {
                message = "Não deu certo: " + ex.Message;
            }

            ViewBag.DatabaseMessage = message;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
