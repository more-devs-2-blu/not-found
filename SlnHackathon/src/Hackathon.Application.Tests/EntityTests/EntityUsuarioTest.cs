using Hackathon.Domain.DTOs;
using Hackathon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Tests.EntityTests
{
    [TestFixture]
    public class EntityUsuarioTest
    {
        [Test]
        public void TestMapToEntity()
        {
            // Arrange
            var usuarioDTO = new UsuarioDTO
            {
                id = 1,
                nome = "Fulano",
                email = "fulano@gmail.com",
                senha = "senha123",
                telefone = "123456789"
            };

            // Act
            var usuario = usuarioDTO.mapToEntity();

            // Assert
            Assert.AreEqual(usuario.Id, usuarioDTO.id);
            Assert.AreEqual(usuario.Nome, usuarioDTO.nome);
            Assert.AreEqual(usuario.Email, usuarioDTO.email);
            Assert.AreEqual(usuario.Senha, usuarioDTO.senha);
            Assert.AreEqual(usuario.Telefone, usuarioDTO.telefone);
        }

        [Test]
        public void TestMapToDTO()
        {
            // Arrange
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "Fulano",
                Email = "fulano@gmail.com",
                Senha = "senha123",
                Telefone = "123456789",
                RelatosList = new List<Relato>()
            };

            // Act
            var usuarioDTO = new UsuarioDTO().mapToDTO(usuario);

            // Assert
            Assert.AreEqual(usuarioDTO.id, usuario.Id);
            Assert.AreEqual(usuarioDTO.nome, usuario.Nome);
            Assert.AreEqual(usuarioDTO.email, usuario.Email);
            Assert.AreEqual(usuarioDTO.senha, usuario.Senha);
            Assert.AreEqual(usuarioDTO.telefone, usuario.Telefone);
        }


    }
}
