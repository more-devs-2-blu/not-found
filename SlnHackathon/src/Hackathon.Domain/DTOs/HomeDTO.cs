using Hackathon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Domain.DTOs
{
	public class HomeDTO
	{
        public List<Relato> Relatos { get; set; }
        public int ViasCount { get; set; }
        public int TransporteCount { get; set; }
        public int SegurancaCount { get; set; }
        public int IluminacaoCount { get; set; }
    }
}
