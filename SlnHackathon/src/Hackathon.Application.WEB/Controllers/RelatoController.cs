using Hackathon.Domain.DTOs;
using Hackathon.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hackathon.Application.WEB.Controllers
{
    public class RelatoController : Controller
    {
        private readonly IRelatoService _service;
        private readonly ICategoriaService _serviceCategoria;
        public RelatoController(IRelatoService service, ICategoriaService serviceCategoria)
        {
            _service = service;
            _serviceCategoria = serviceCategoria;
        }

        public async Task<IActionResult> Index()
        {
            return View(_service.FindAll()
                        .OrderByDescending(r => r.contadorLikes));
        }

        public async Task<IActionResult> Create()
        {
            ViewData["categoriaId"] = new SelectList(_serviceCategoria.FindAll(), "id", "descricao");
            return View();
        }

        [HttpPost]
        //public async Task<IActionResult> Create([Bind("id, usuarioId, categoriaId, relatorio, rua, bairro, cep, imagem, cidade, estado, data, contadorLikes, status, Address")] RelatoDTO relato)
        public async Task<IActionResult> Create(List<IFormFile> imagemRelato, [Bind("id, usuarioId, categoriaId, relatorio, contadorLikes, status, Address")] RelatoDTO relato)
        {
            if (ModelState.IsValid)
            {
                var username = Request.Cookies["user"];
                string[] infosCookie = username.Split('&');
                int userId = int.Parse(infosCookie[1]);
                var file = imagemRelato.FirstOrDefault();
                var fileName = $"{file.FileName}";
                relato.imagem = fileName;
                relato.usuarioId = userId;

                if (await _service.Save(relato) > 0) { 
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//img", fileName);
                    var stream = new FileStream(path, FileMode.Create);
                    file.CopyToAsync(stream);

                return RedirectToAction(nameof(Index));
                }
            }
            ViewData["categoriaId"] = new SelectList(_serviceCategoria.FindAll(), "id", "descricao");
            return View(relato);

        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
                return NotFound();
            ViewData["categoriaId"] = new SelectList(_serviceCategoria.FindAll(), "id", "descricao");
            //return View(await _service.FindById(id));
            return View(_service.FindAll()
                .FirstOrDefault(r => r.id == id));
        }
        [HttpPost]
        //public async Task<IActionResult> Details(int? id, [Bind("id, usuarioId, categoriaId, relatorio, rua, bairro, cep, imagem, cidade, estado, data, contadorLikes, status, Address")] RelatoDTO relato)
        public async Task<IActionResult> Details(int? id, [Bind("id, usuarioId, categoriaId, relatorio, data, contadorLikes, status, Address")] RelatoDTO relato)
        {
            if (!(id == relato.id))
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (await _service.Save(relato) > 0)
                    return RedirectToAction(nameof(Details));
            }
            ViewData["categoriaId"] = new SelectList(_serviceCategoria.FindAll(), "id", "descricao");
            return View(relato);

        }
    }
}
