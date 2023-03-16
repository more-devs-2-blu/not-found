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
                    var users = _userService.FindAll();

                    foreach (var item in users)
                    {
                        if (user.email == item.email && user.senha == item.senha)
                        {
                            CookieOptions ckOptions = new CookieOptions();
                            ckOptions.Expires = DateTime.Now.AddMinutes(20);

                            Response.Cookies.Append("user", $"{item.nome}&{item.id}", ckOptions);
                        }
                    }
                    return Redirect("/Relato/Create");
                }
            }
            return View();
        }
    }
}
