using Hackathon.Domain.DTOs;
using Hackathon.Domain.Interfaces.IRepositories;
using Hackathon.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.Service.Services
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IUsuarioRepository _repository;
		public UsuarioService(IUsuarioRepository repository)
		{
			_repository = repository;
		}
		public async Task<int> Delete(int id)
		{
			return await this._repository.Delete(await this._repository.FindById(id));
		}

		public List<UsuarioDTO> FindAll()
		{
			return this._repository.FindAll()
									.Select(u => new UsuarioDTO()
									{
										id = u.Id,
										nome = u.Nome,
										email = u.Email,
										senha = u.Senha,
										telefone = u.Telefone
									}).ToList();
		}

		public async Task<UsuarioDTO> FindById(int id)
		{
			var dto = new UsuarioDTO();
			return dto.mapToDTO(await this._repository.FindById(id));
		}

		public Task<int> Save(UsuarioDTO dto)
		{
			if(dto.id > 0)
			{
				return this._repository.Update(dto.mapToEntity());
			}
			else
			{
				return this._repository.Save(dto.mapToEntity());
			}
		}
	}
}
