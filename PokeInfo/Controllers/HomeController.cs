using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using PokeInfo.Models;

namespace PokeInfo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("{pokeid}")]
        public JsonResult QueryPoke(int pokeid){
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
            {
                PokeInfo = ApiResponse;
            }
            ).Wait();
            ViewBag.Pokemon = PokeInfo;
            return Json(PokeInfo);
        }
        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public IActionResult Pokemon(int pokeid){
            var PokeInfo = new Dictionary<string, object>();
            WebRequest.GetPokemonDataAsync(pokeid, ApiResponse =>
            {
                PokeInfo = ApiResponse;
            }
            ).Wait();
            ViewBag.Pokemon = PokeInfo;
            return View("Index");
        }
    }
}
