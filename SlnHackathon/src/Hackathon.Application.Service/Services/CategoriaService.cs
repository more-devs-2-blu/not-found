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
	public class CategoriaService : ICategoriaService
	{
		private readonly ICategoriaRepository _repository;
		public CategoriaService(ICategoriaRepository repository)
		{
			_repository = repository;
		}
		public async Task<int> Delete(int id)
		{
			return await this._repository.Delete(await this._repository.FindById(id));
		}

		public List<CategoriaDTO> FindAll()
		{
			return this._repository.FindAll()
								.Select(c => new CategoriaDTO()
								{
									id = c.Id,
									descricao= c.Descricao
								}).ToList();
		}

		public async Task<CategoriaDTO> FindById(int id)
		{
			var dto = new CategoriaDTO();
			return dto.mapToDto(await this._repository.FindById(id));
		}

		public Task<int> Save(CategoriaDTO dto)
		{
			if (dto.id > 0) 
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
