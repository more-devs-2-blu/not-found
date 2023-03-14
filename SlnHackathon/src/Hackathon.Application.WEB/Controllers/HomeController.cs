using Hackathon.Application.WEB.Models;
using Hackathon.Domain.DTOs;
using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces.IServices;
using Hackathon.Domain.Util;
using Hackathon.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Hackathon.Application.WEB.Controllers
{
	public class HomeController : Controller
	{
        private readonly IUsuarioService _userService;
        private readonly SQLiteContext _context;

		public HomeController(SQLiteContext context, IUsuarioService userService)
		{
            _context = context;
            _userService = userService;
		}

		public IActionResult Index()
		{
            IQueryable<Relato> relatosQuery = _context.Relatos
                .Include(x => x.Categoria)
                .AsQueryable();

            var dto = new HomeDTO()
            {
                Relatos = relatosQuery.OrderByDescending(x => x.Id).Take(6).ToList(),
                ViasCount = relatosQuery.Count(x => x.Categoria != null && x.Categoria.Descricao == "Vias Públicas"),
                TransporteCount = relatosQuery.Count(x => x.Categoria != null && x.Categoria.Descricao == "Transporte Público"),
                SegurancaCount = relatosQuery.Count(x => x.Categoria != null && x.Categoria.Descricao == "Segurança Pública"),
                IluminacaoCount = relatosQuery.Count(x => x.Categoria != null && x.Categoria.Descricao == "Iluminação Pública")                
            };
			return View(dto);
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