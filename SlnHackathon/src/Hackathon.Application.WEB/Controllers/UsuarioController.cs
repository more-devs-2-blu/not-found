using Hackathon.Domain.DTOs;
using Hackathon.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Application.WEB.Controllers
{
	public class UsuarioController : Controller
	{
		private readonly IUsuarioService _userService;
		public UsuarioController(IUsuarioService userService)
		{
            _userService = userService;
		}
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Create([Bind("nome, email, senha")] UsuarioDTO user)
        {
			if (ModelState.IsValid)
			{
                if (await _userService.Save(user) > 0)
                {
                    return Redirect("/Home/Index");
                }
            }

            return View();
        }
    }
}
