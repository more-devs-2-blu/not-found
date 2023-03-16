using Hackathon.Domain.Entities;
using Hackathon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Domain.DTOs
{
	public class RelatoDTO
	{
		public int id { get; set; }
		public int usuarioId { get; set; }

        [Display(Name = "Categoria")]
        public int categoriaId { get; set; }

        [Display(Name = "Relato")]
        public string relatorio { get; set; }
		public string? rua { get; set; }
		public string? bairro { get; set; }
		public string? cep { get; set; }
		public string? estado { get; set; }
		public string? cidade { get; set; }
		public string? imagem { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime data { get; set; }
		public int contadorLikes { get; set; }
		public StatusEnum status { get; set; }

        [Display(Name = "Endereço")]
        public string Address { get; set; }


        public virtual UsuarioDTO? usuario { get; set; }

        [Display(Name = "Categoria")]
        public virtual CategoriaDTO? categoria { get; set; }

		public Relato mapToEntity()
		{
			return new Relato
			{
				Id = id,
				UsuarioId = usuarioId,
				CategoriaId = categoriaId,
				Relatorio = relatorio,
				Rua = rua ?? "",
				Bairro = bairro ?? "",
				CEP = cep ?? "",
				Imagem = imagem,
				Cidade = cidade ?? "",
				Estado = estado ?? "",
				Data = data,
				ContadorLikes = contadorLikes,
				Status = status,
                Address = Address
            };
		}

		public RelatoDTO mapToDTO(Relato relato)
		{
			return new RelatoDTO()
			{
				id = relato.Id,
				usuarioId = relato.UsuarioId,
				categoriaId = relato.CategoriaId,
				relatorio = relato.Relatorio,
				rua = relato.Rua ?? "",
				bairro = relato.Bairro ?? "",
				cep = relato.CEP ?? "",
				imagem = relato.Imagem,
				estado = relato.Estado ?? "",
				cidade = relato.Cidade ?? "",
				data = relato.Data,
				contadorLikes = relato.ContadorLikes,
				status = relato.Status,
                Address = relato.Address
            };
		}
	}
}
