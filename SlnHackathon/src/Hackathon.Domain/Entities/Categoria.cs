using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Domain.Entities
{
	public class Categoria
	{
		public int Id { get; set; }
		public string Descricao { get; set; }

		public virtual ICollection<Relato> RelatosList { get; set; }
	}
}
