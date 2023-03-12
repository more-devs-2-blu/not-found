using Hackathon.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Application.WEB.Controllers
{
	public class UsuarioController : Controller
	{
		private readonly IUsuarioService _service;
		public UsuarioController(IUsuarioService service)
		{
			_service = service;
		}
		public IActionResult Create()
		{
			return View();
		}
	}
}
