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
    public class EntityCategoriaTest
    {
        [Test]
        public void TestMapToEntity()
        {
            // Arrange
            CategoriaDTO categoriaDTO = new CategoriaDTO
            {
                id = 1,
                descricao = "Categoria Teste",
                relatosList = new List<RelatoDTO>()
            };

            // Act
            Categoria categoria = categoriaDTO.mapToEntity();

            // Assert
            Assert.AreEqual(1, categoria.Id);
            Assert.AreEqual("Categoria Teste", categoria.Descricao);
        }

        [Test]
        public void TestMapToDto()
        {
            // Arrange
            Categoria categoria = new Categoria
            {
                Id = 1,
                Descricao = "Categoria Teste",
                RelatosList = new List<Relato>()
            };

            // Act
            CategoriaDTO categoriaDTO = new CategoriaDTO().mapToDto(categoria);

            // Assert
            Assert.AreEqual(1, categoriaDTO.id);
            Assert.AreEqual("Categoria Teste", categoriaDTO.descricao);
        }


    }
}

