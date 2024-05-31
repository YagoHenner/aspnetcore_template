using RegressivaAPI.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RegressivaAPI.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuarioById(int id);
        Task<Usuario> AddUsuario(Usuario usuario);
        Task<Usuario> UpdateUsuario(Usuario usuario);
        Task<bool> DeleteUsuario(int id);
    }
}
