using Hackathon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Domain.DTOs
{
	public class CategoriaDTO
	{
		public int id { get; set; }
		public string descricao { get; set; }

		public virtual ICollection<RelatoDTO>? relatosList { get; set; }

		public Categoria mapToEntity()
		{
			return new Categoria
			{
				Id = id,
				Descricao = descricao
			};
		}

		public CategoriaDTO mapToDto(Categoria categoria)
		{
			return new CategoriaDTO()
			{
				id = categoria.Id,
				descricao = categoria.Descricao
			};
		}
	}
}
