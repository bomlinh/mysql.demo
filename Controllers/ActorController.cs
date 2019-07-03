using System;
using Microsoft.AspNetCore.Mvc;
using mysql.demo.Models;
namespace mysql.demo.Controllers
{
    // [Route("[controller]/[action]")]
    public class ActorController : Controller
    {
        public IActionResult Index()
        {
            DbContext context = HttpContext.RequestServices.GetService(typeof(mysql.demo.Models.DbContext)) as DbContext;
            return View(context.GetAllActors());
        }
    }
}