using Hackathon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Domain.DTOs
{
	public class UsuarioDTO
	{
		public int id { get; set; }
		public string nome { get; set; }
		public string? email { get; set; }
		public string senha { get; set; }
		public string? telefone { get; set; }

		public virtual ICollection<RelatoDTO>? relatosList { get; set; }

		public Usuario mapToEntity()
		{
			return new Usuario
			{
				Id = id,
				Nome = nome,
				Email = email,
				Senha = senha,
				Telefone = telefone
			};
		}

		public UsuarioDTO mapToDTO(Usuario usuario)
		{
			return new UsuarioDTO()
			{
				id = usuario.Id,
				nome = usuario.Nome,
				email = usuario.Email,
				senha = usuario.Senha,
				telefone = usuario.Telefone
			};
		}
	}
}
