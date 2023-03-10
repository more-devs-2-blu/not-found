using Hackathon.Domain.Entities;
using Hackathon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Domain.DTOs
{
	public class RelatoDTO
	{
		public int id { get; set; }
		public int usuarioId { get; set; }
		public int categoriaId { get; set; }
		public string titulo { get; set; }
		public string relatorio { get; set; }
		public string? rua { get; set; }
		public string? bairro { get; set; }
		public string? cep { get; set; }
		public string? imagem { get; set; }
		public string? latitude { get; set; }
		public string? longitude { get; set; }
		public DateTime data { get; set; }
		public int contadorLikes { get; set; }
		public StatusEnum status { get; set; }

		public virtual UsuarioDTO? usuario { get; set; }
		public virtual CategoriaDTO? categoria { get; set; }

		public Relato mapToEntity()
		{
			return new Relato
			{
				Id = id,
				UsuarioId = usuarioId,
				CategoriaId = categoriaId,
				Titulo = titulo,
				Relatorio = relatorio,
				Rua = rua,
				Bairro = bairro,
				CEP = cep,
				Imagem = imagem,
				Latitude = latitude,
				Longitude = longitude,
				Data = data,
				ContadorLikes = contadorLikes,
				Status = status
			};
		}

		public RelatoDTO mapToDTO(Relato relato)
		{
			return new RelatoDTO()
			{
				id = relato.Id,
				usuarioId = relato.UsuarioId,
				categoriaId = relato.CategoriaId,
				titulo = relato.Titulo,
				relatorio = relato.Relatorio,
				rua = relato.Rua,
				bairro = relato.Bairro,
				cep = relato.CEP,
				imagem = relato.Imagem,
				latitude = relato.Latitude,
				longitude = relato.Longitude,
				data = relato.Data,
				contadorLikes = relato.ContadorLikes,
				status = relato.Status
			};
		}
	}
}
