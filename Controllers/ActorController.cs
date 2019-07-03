using System;
using Microsoft.AspNetCore.Mvc;
using mysql.demo.Models;
namespace mysql.demo.Controllers
{
    public class ActorController : Controller
    {
        public IActionResult Index()
        {
            ActorContext context = HttpContext.RequestServices.GetService(typeof(mysql.demo.Models.ActorContext)) as ActorContext;
            return View(context.GetAllActors());
        }
    }
}