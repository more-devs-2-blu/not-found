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
        private readonly IUsuarioService _serviceUsuario;
        public RelatoController(IRelatoService service, ICategoriaService serviceCategoria, IUsuarioService serviceUsuario)
        {
            _service = service;
            _serviceCategoria = serviceCategoria;
            _serviceUsuario = serviceUsuario;
        }

        public async Task<IActionResult> Index(int? categoria)
        {
            if (categoria == null)
            {
                return View(_service.FindAll()
                .OrderByDescending(r => r.contadorLikes));

            }
            else
            {
                return View(_service.FindAll()
                    .Where(r => r.categoriaId == categoria)
                    .OrderByDescending(r => r.contadorLikes));
            }
        }
        public async Task<IActionResult> Create()
        {
            ViewData["categoriaId"] = new SelectList(_serviceCategoria.FindAll(), "id", "descricao");
            return View();
        }

        [HttpPost]
        //public async Task<IActionResult> Create([Bind("id, usuarioId, categoriaId, relatorio, rua, bairro, cep, imagem, cidade, estado, data, contadorLikes, status, Address")] RelatoDTO relato)
        public async Task<IActionResult> Create(List<IFormFile> imagemRelato, [Bind("id, usuarioId, categoriaId, data, relatorio, contadorLikes, status, Address")] RelatoDTO relato)
        {
            if (ModelState.IsValid)
            {
                var username = Request.Cookies["user"];
                string[] infosCookie = username.Split('&');
                int userId = int.Parse(infosCookie[1]);
                relato.usuarioId = userId;

                if (imagemRelato.Count != 0) { 
                    var file = imagemRelato.FirstOrDefault();
                    var fileName = $"{file.FileName}";
                    relato.imagem = fileName;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//img", fileName);
                    var stream = new FileStream(path, FileMode.Create);
                    file.CopyToAsync(stream);

                }


                if (await _service.Save(relato) > 0) { 
                    
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
            

            var relato = await _service.FindById(id);

            var categoria = _serviceCategoria.FindById(relato.categoriaId);
            var usuario = _serviceUsuario.FindById(relato.usuarioId);

            ViewData["categoria"] = categoria.Result.descricao;
            ViewData["usuario"] = usuario.Result.nome;

            return View(relato);
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
