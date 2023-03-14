using Hackathon.Domain.Entities;
using Hackathon.Domain.Interfaces.IRepositories;
using Hackathon.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Infra.Data.Repositories
{
	public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
	{
		public UsuarioRepository(SQLiteContext context): base(context) { }
	}
}
