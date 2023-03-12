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
	public class RelatoService : IRelatoService
	{
		private readonly IRelatoRepository _repository;
		public RelatoService(IRelatoRepository repository)
		{
			_repository = repository;
		}
		public async Task<int> Delete(int id)
		{
			return await this._repository.Delete(await this._repository.FindById(id));
		}

		public List<RelatoDTO> FindAll()
		{
			return this._repository.FindAll()
									.Select(r => new RelatoDTO()
									{
										id = r.Id,
										categoriaId = r.CategoriaId,
										usuarioId = r.UsuarioId,
										relatorio = r.Relatorio,
										rua = r.Rua,
										bairro = r.Bairro,
										cep = r.CEP,
										imagem = r.Imagem,
										estado = r.Estado,
										cidade = r.Cidade,
										data = r.Data,
										contadorLikes = r.ContadorLikes,
										status = r.Status,
										categoria = new CategoriaDTO()
										{
											id = r.Categoria.Id,
											descricao = r.Categoria.Descricao
										},
										usuario= new UsuarioDTO()
										{
											id = r.Usuario.Id,
											nome = r.Usuario.Nome,
											email = r.Usuario.Email,
											senha = r.Usuario.Senha,
											telefone = r.Usuario.Telefone
										}
									}).ToList();
		}

		public async Task<RelatoDTO> FindById(int id)
		{
			var dto = new RelatoDTO();
			return dto.mapToDTO(await this._repository.FindById(id));
		}

		public Task<int> Save(RelatoDTO dto)
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
