using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using QuotingDojo.Connectors;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
        private DbConnector cnx;
        public HomeController(){
            cnx = new DbConnector();
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("/addquote")]
        public IActionResult AddQuote(string name, string quote){ 
            // string query = $"INSERT INTO quotes(name, quote, created_at, updated_at) VALUES ('{name}', '{quote}', NOW(), NOW());";
            DbConnector.Execute($"INSERT INTO quotes(name, quote, created_at, updated_at) VALUES ('{name}', '{quote}', NOW(), NOW());");
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("/quotes")]
        public IActionResult Quotes(){
            var quotes = DbConnector.Query("SELECT * FROM quotes ORDER BY created_at DESC");
            ViewBag.Query = quotes;
            return View("Quotes");
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
