using RegressivaAPI.Domain.Entities;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegressivaAPI.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Result<IEnumerable<Usuario>>> GetAllUsuarios();
        Task<Result<Usuario>> GetUsuarioById(int id);
        Task<Result<Usuario>> AddUsuario(Usuario usuario);
        Task<Result<Usuario>> UpdateUsuario(Usuario usuario);
        Task<Result> DeleteUsuario(int id);
    }
}
