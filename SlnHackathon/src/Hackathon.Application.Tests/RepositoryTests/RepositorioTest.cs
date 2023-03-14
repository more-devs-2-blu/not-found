using Hackathon.Domain.DTOs;
using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces.IRepositories;
using Hackathon.Infra.Data.Context;
using Hackathon.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Tests.RepositoryTests
{
    [TestFixture]
    public class RepositorioTest
    {
        private static DbContextOptions<SQLiteContext> dbContextOptions = new DbContextOptionsBuilder<SQLiteContext>()
            .UseInMemoryDatabase(databaseName: "Testes unitarios")
            .Options;

        private SQLiteContext _context;
        private IBaseRepository<Categoria> _categoriaRepository;
        private IBaseRepository<Relato> _relatoRepository;
        private IBaseRepository<Usuario> _usuarioRepository;


        [OneTimeSetUp]
        public void Setup()
        {
            _context = new SQLiteContext(dbContextOptions);
            _context.Database.EnsureCreated();

            _categoriaRepository = new BaseRepository<Categoria>(_context);
            _relatoRepository = new BaseRepository<Relato>(_context);
            _usuarioRepository = new BaseRepository<Usuario>(_context);
        }
        [Test]
        public async Task salvandoEntidade()
        {
            // Arrange
            var categoria = new Categoria { Descricao = "Categoria de teste" };
            var relato = new Relato
            {
                UsuarioId = 1,
                CategoriaId = 1,
                Relatorio = "informações aqui- teste",
                Rua = "teste rua",
                Bairro = "teste bairro",
                CEP = "teste cep",
                Cidade = "Cidade Teste",
                Estado = "Estado Teste",
                Imagem = "teste img",
                Data = new DateTime(2023, 03, 11),
                ContadorLikes = 3,
                Status = 0
            };
            var usuario = new Usuario
            {
                Nome = "usuario de teste",
                Email = "teste@gmail.com",
                Senha = "123",
                Telefone = "47123456789"
            };


            // Act
            await _categoriaRepository.Save(categoria);
            await _relatoRepository.Save(relato);
            await _usuarioRepository.Save(usuario);

            // Assert
            var categoriaAdicionada = _context.Categorias.FirstOrDefault(c => c.Id == categoria.Id);
            var relatoAdicionado = _context.Relatos.FirstOrDefault(c => c.Id == relato.Id);
            var usuarioAdicionado = _context.Usuarios.FirstOrDefault(c => c.Id == usuario.Id);

            Assert.AreEqual(categoria, categoriaAdicionada);
            Assert.AreEqual(relato, relatoAdicionado);
            Assert.AreEqual(usuario, usuarioAdicionado);
        }

        [Test]
        public async Task atualizandoEntidade()
        {
            // Arrange
            var categoria = new Categoria
            {
                Descricao = "Teste descricao atualizada"
            };
            var relato = new Relato
            {
                UsuarioId = 1,
                CategoriaId = 1,
                Relatorio = "informações aqui- teste",
                Rua = "teste rua",
                Bairro = "teste bairro",
                CEP = "teste cep",
                Cidade = "Cidade Teste",
                Estado = "Estado Teste",
                Imagem = "teste img",
                Data = new DateTime(2023, 03, 11),
                ContadorLikes = 3,
                Status = Domain.Enums.StatusEnum.Novo
            };
            var usuario = new Usuario
            {
                Nome = "usuario de teste",
                Email = "teste@gmail.com",
                Senha = "123",
                Telefone = "47123456789"
            };

            await _categoriaRepository.Save(categoria);
            await _relatoRepository.Save(relato);
            await _usuarioRepository.Save(usuario);

            // Act
            categoria.Descricao = "descrição altualiza";

            relato.UsuarioId = 2;
            relato.CategoriaId = 2;
            relato.Relatorio = "Testado, alterado descrição!!!!";
            relato.Rua = "Nova rua testada";
            relato.Bairro = "Novo bairro testado";
            relato.CEP = "123456789";
            relato.Cidade = "Cidade Teste";
            relato.Estado = "Estado Teste";
            relato.Imagem = "/img/testesdeimgem.png";
            relato.Data = new DateTime(2023, 03, 17);
            relato.ContadorLikes = 5;
            relato.Status = Domain.Enums.StatusEnum.Andamento;


            await _categoriaRepository.Update(categoria);
            await _relatoRepository.Update(relato);
            await _usuarioRepository.Update(usuario);

            // Assert
            var categoriaAtualizada = _context.Categorias.FirstOrDefault(p => p.Id == categoria.Id);
            var relatoAtualizado = _context.Relatos.FirstOrDefault(p => p.Id == relato.Id);
            var usuarioAtualizado = _context.Usuarios.FirstOrDefault(p => p.Id == usuario.Id);

            Assert.AreEqual(categoria.Descricao, categoriaAtualizada.Descricao);

            Assert.AreEqual(relato.UsuarioId, relatoAtualizado.UsuarioId);
            Assert.AreEqual(relato.CategoriaId, relatoAtualizado.CategoriaId);
            Assert.AreEqual(relato.Relatorio, relatoAtualizado.Relatorio);
            Assert.AreEqual(relato.Rua, relatoAtualizado.Rua);
            Assert.AreEqual(relato.Bairro, relatoAtualizado.Bairro);
            Assert.AreEqual(relato.CEP, relatoAtualizado.CEP);
            Assert.AreEqual(relato.Cidade, relatoAtualizado.Cidade);
            Assert.AreEqual(relato.Estado, relatoAtualizado.Estado);
            Assert.AreEqual(relato.Imagem, relatoAtualizado.Imagem);
            Assert.AreEqual(relato.Data, relatoAtualizado.Data);
            Assert.AreEqual(relato.ContadorLikes, relatoAtualizado.ContadorLikes);
            Assert.AreEqual(relato.Status, relatoAtualizado.Status);
        }

        [Test]
        public async Task EncontrandoEntidadePeloID()
        {
            // Arrange
            var categoria = new Categoria { Descricao = "Teste findByID" };
            var relato = new Relato
            {
                UsuarioId = 1,
                CategoriaId = 1,
                Relatorio = "informações aqui- teste",
                Rua = "teste rua",
                Bairro = "teste bairro",
                CEP = "teste cep",
                Cidade = "Cidade Teste",
                Estado = "Estado Teste",
                Imagem = "teste img",
                Data = new DateTime(2023, 03, 11),
                ContadorLikes = 3,
                Status = Domain.Enums.StatusEnum.Novo
            };
            var usuario = new Usuario
            {
                Nome = "usuario de teste",
                Email = "teste@gmail.com",
                Senha = "123",
                Telefone = "47123456789"
            };

            await _categoriaRepository.Save(categoria);
            await _relatoRepository.Save(relato);
            await _usuarioRepository.Save(usuario);

            // Act
            var categoriaEncontrada = await _categoriaRepository.FindById(categoria.Id);
            var relatoEncontrado = await _relatoRepository.FindById(relato.Id);
            var usuarioEncontrado = await _usuarioRepository.FindById(usuario.Id);

            // Assert
            Assert.AreEqual(categoria, categoriaEncontrada);
            Assert.AreEqual(relato, relatoEncontrado);
            Assert.AreEqual(usuario, usuarioEncontrado);
        }

        [Test]
        public async Task ExcluindoEntidade()
        {
            // Arrange
            var categoria = new Categoria { Descricao = "Teste findByID" };
            var relato = new Relato
            {
                UsuarioId = 1,
                CategoriaId = 1,
                Relatorio = "informações aqui- teste",
                Rua = "teste rua",
                Bairro = "teste bairro",
                CEP = "teste cep",
                Cidade = "Cidade Teste",
                Estado = "Estado Teste",
                Imagem = "teste img",
                Data = new DateTime(2023, 03, 11),
                ContadorLikes = 3,
                Status = Domain.Enums.StatusEnum.Novo
            };
            var usuario = new Usuario
            {
                Nome = "usuario de teste",
                Email = "teste@gmail.com",
                Senha = "123",
                Telefone = "47123456789"
            };

            await _categoriaRepository.Save(categoria);
            await _relatoRepository.Save(relato);
            await _usuarioRepository.Save(usuario);

            // Act
            await _categoriaRepository.Delete(categoria);
            await _relatoRepository.Delete(relato);
            await _usuarioRepository.Delete(usuario);

            // Assert
            var categoriaExcluida = _context.Categorias.FirstOrDefault(p => p.Id == categoria.Id);
            var relatoExcluido = _context.Relatos.FirstOrDefault(p => p.Id == relato.Id);
            var usuarioExcluido = _context.Usuarios.FirstOrDefault(p => p.Id == usuario.Id);

            Assert.IsNull(categoriaExcluida);
            Assert.IsNull(relatoExcluido);
            Assert.IsNull(usuarioExcluido);
        }

        [Test]
        public void ListandoEntidades()
        {
            // Arrange
            var categoria = new Categoria { Descricao = "Teste findByID" };
            var relato = new Relato
            {
                UsuarioId = 1,
                CategoriaId = 1,
                Relatorio = "informações aqui- teste",
                Rua = "teste rua",
                Bairro = "teste bairro",
                CEP = "teste cep",
                Cidade = "teste cidade",
                Estado = "Estado cep",
                Imagem = "teste img",
                Data = new DateTime(2023, 03, 11),
                ContadorLikes = 3,
                Status = Domain.Enums.StatusEnum.Novo
            };
            var usuario = new Usuario
            {
                Nome = "usuario de teste",
                Email = "teste@gmail.com",
                Senha = "123",
                Telefone = "47123456789"
            };

            var categoria1 = new Categoria { Descricao = "Teste findByID" };
            var relato1 = new Relato
            {
                UsuarioId = 1,
                CategoriaId = 1,
                Relatorio = "informações aqui- teste",
                Rua = "teste rua",
                Bairro = "teste bairro",
                CEP = "teste cep",
                Cidade = "Cidade Teste",
                Estado = "Estado Teste",
                Imagem = "teste img",
                Data = new DateTime(2023, 03, 11),
                ContadorLikes = 3,
                Status = Domain.Enums.StatusEnum.Novo
            };
            var usuario1 = new Usuario
            {
                Nome = "usuario de teste",
                Email = "teste@gmail.com",
                Senha = "123",
                Telefone = "47123456789"
            };

            _categoriaRepository.Save(categoria).Wait();
            _categoriaRepository.Save(categoria1).Wait();
            _relatoRepository.Save(relato).Wait();
            _relatoRepository.Save(relato1).Wait();
            _usuarioRepository.Save(usuario).Wait();
            _usuarioRepository.Save(usuario1).Wait();

            // Act
            var categorias = _categoriaRepository.FindAll().ToList();
            var relatos = _relatoRepository.FindAll().ToList();
            var usuarios = _usuarioRepository.FindAll().ToList();

            // Assert
            Assert.Contains(categoria1, categorias);
            Assert.Contains(relato1, relatos);
            Assert.Contains(usuario1, usuarios);

        }

        [OneTimeTearDown]
        public void Limpeza()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
