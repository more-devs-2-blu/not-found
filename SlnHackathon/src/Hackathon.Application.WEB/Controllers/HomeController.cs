using Hackathon.Application.WEB.Models;
using Hackathon.Domain.Interfaces.IServices;
using Hackathon.Domain.Util;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hackathon.Application.WEB.Controllers
{
	public class HomeController : Controller
	{
        private readonly IUsuarioService _userService;

		public HomeController(IUsuarioService userService)
		{
            _userService = userService;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Login()
		{
			return View();
		}

        [HttpPost]
        public JsonResult Login(string userName, string passWord)
        {
            var users = _userService.FindAll();
            
            var retSignIn = new ReturnJsonUser
            {
                status = "error",
                username = ""
            };

            foreach (var item in users)
            {
                if (userName == item.nome && passWord == item.senha)
                {
                    retSignIn = new ReturnJsonUser
                    {
                        status = "success",
                        username = item.nome
                    };
                    return Json(retSignIn);
                }
            }
            return Json(retSignIn);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}