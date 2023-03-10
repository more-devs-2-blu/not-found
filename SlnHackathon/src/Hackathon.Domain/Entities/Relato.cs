using Hackathon.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Domain.Entities
{
	public class Relato
	{
		public int Id { get; set; }
		public int UsuarioId { get; set; }
		public int CategoriaId { get; set; }
		public string Titulo { get; set; }
		public string Relatorio { get; set; }
		public string? Rua { get; set; }
		public string? Bairro { get; set; }
		public string? CEP { get; set; }
		public string? Imagem { get; set; }
		public string? Latitude { get; set; }
		public string? Longitude { get; set; }
		public DateTime Data { get; set; }
		public int ContadorLikes { get; set; }
		public StatusEnum Status { get; set; }

		public virtual Usuario? Usuario { get; set; }
		public virtual Categoria? Categoria { get; set; }
	}
}
