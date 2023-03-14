using Hackathon.Domain.DTOs;
using Hackathon.Domain.Entities;
using Hackathon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Tests.EntityTests
{
    [TestFixture]
    public class EntityRelatoTest
    {
        [Test]
        public void TestMapToEntity()
        {
            // Arrange
            RelatoDTO relatoDTO = new RelatoDTO
            {
                id = 1,
                usuarioId = 1,
                categoriaId = 2,
                relatorio = "Relatório Teste",
                rua = "Rua Teste",
                bairro = "Bairro Teste",
                cep = "12345-678",
                cidade = "Cidade Teste", 
                estado = "Estado Teste", 
                imagem = "Imagem Teste",
                data = DateTime.Now,
                contadorLikes = 0,
                status = StatusEnum.Novo
            };

            // Act
            Relato relato = relatoDTO.mapToEntity();

            // Assert
            Assert.AreEqual(1, relato.Id);
            Assert.AreEqual(1, relato.UsuarioId);
            Assert.AreEqual(2, relato.CategoriaId);
            Assert.AreEqual("Relatório Teste", relato.Relatorio);
            Assert.AreEqual("Rua Teste", relato.Rua);
            Assert.AreEqual("Bairro Teste", relato.Bairro);
            Assert.AreEqual("12345-678", relato.CEP);
            Assert.AreEqual("Cidade Teste", relato.Cidade);
            Assert.AreEqual("Estado Teste", relato.Estado);
            Assert.AreEqual("Imagem Teste", relato.Imagem);
            Assert.AreEqual(relatoDTO.data, relato.Data);
            Assert.AreEqual(0, relato.ContadorLikes);
            Assert.AreEqual(StatusEnum.Novo, relato.Status);
        }

        [Test]
        public void TestMapToDto()
        {
            // Arrange
            Relato relato = new Relato
            {
                Id = 1,
                UsuarioId = 1,
                CategoriaId = 2,
                Relatorio = "Relatório Teste",
                Rua = "Rua Teste",
                Bairro = "Bairro Teste",
                CEP = "12345-678",
                Cidade = "Cidade Teste",
                Estado = "Estado Teste",
                Imagem = "Imagem Teste",
                Data = DateTime.Now,
                ContadorLikes = 0,
                Status = StatusEnum.Novo
            };

            // Act
            RelatoDTO relatoDTO = new RelatoDTO().mapToDTO(relato);

            // Assert
            Assert.AreEqual(1, relatoDTO.id);
            Assert.AreEqual(1, relatoDTO.usuarioId);
            Assert.AreEqual(2, relatoDTO.categoriaId);
            Assert.AreEqual("Relatório Teste", relatoDTO.relatorio);
            Assert.AreEqual("Rua Teste", relatoDTO.rua);
            Assert.AreEqual("Bairro Teste", relatoDTO.bairro);
            Assert.AreEqual("12345-678", relatoDTO.cep);
            Assert.AreEqual("Cidade Teste", relatoDTO.cidade);
            Assert.AreEqual("Estado Teste", relatoDTO.estado);
            Assert.AreEqual("Imagem Teste", relatoDTO.imagem);
            Assert.AreEqual(0, relatoDTO.contadorLikes);
            Assert.AreEqual(StatusEnum.Novo, relatoDTO.status);
        }
    }
}

