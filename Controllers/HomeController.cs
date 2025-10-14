using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using MySql.Data.MySqlClient;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataBase _db;

        public HomeController(ILogger<HomeController> logger, DataBase db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            string message;

            try
            {
                using (MySqlConnection conn = _db.GetConnection())
                {
                    conn.Open();
                    message = "✅ Conexão com o banco de dados realizada com sucesso!";
                }
            }
            catch (Exception ex)
            {
                message = "❌ Falha ao conectar: " + ex.Message;
                _logger.LogError(ex, "Erro ao conectar ao banco de dados");
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
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
