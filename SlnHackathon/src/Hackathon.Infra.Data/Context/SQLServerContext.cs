using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Infra.Data.Context
{
	public class SQLServerContext : DbContext
	{
		public SQLServerContext(DbContextOptions<SQLServerContext> options)
			:base(options) {}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Categoria>()
				.HasData(
				new {Id = 1, Descricao = "Iluminação"},
				new {Id = 2, Descricao = "Segurança" },
				new {Id = 3, Descricao = "Transporte"},
				new {Id = 4, Descricao = "Vias"}
				);

			modelBuilder.Entity<Usuario>()
				.HasData(
				new { Id = 1, Nome = "Anônimo", Senha = "Anonimo"},
				new { Id = 2, Nome = "João", Senha = "Joao" },
				new { Id = 3, Nome = "Maria", Senha = "Maria" },
				new { Id = 4, Nome = "Felipe", Senha = "Felipe" }
				);

	}

		#region DbSets<Tables>
		public DbSet<Categoria> Categorias { get; set; }
		public DbSet<Relato> Relatos { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }
		#endregion
	}
}
