using RegressivaAPI.Application.Interfaces;
using RegressivaAPI.Domain.Entities;
using FluentResults;
using System.Collections.Generic;
using System.Threading.Tasks;
using BCrypt.Net;

namespace RegressivaAPI.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Result<IEnumerable<Usuario>>> GetAllUsuarios()
        {
            var usuarios = await _usuarioRepository.GetAllUsuarios();
            return Result.Ok(usuarios);
        }

        public async Task<Result<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await _usuarioRepository.GetUsuarioById(id);
            return usuario != null ? Result.Ok(usuario) : Result.Fail("Usuário não encontrado");
        }

        public async Task<Result<Usuario>> AddUsuario(Usuario usuario)
        {
            usuario.senha = BCrypt.Net.BCrypt.HashPassword(usuario.senha);
            var addedUsuario = await _usuarioRepository.AddUsuario(usuario);
            return Result.Ok(addedUsuario);
        }

        public async Task<Result<Usuario>> UpdateUsuario(Usuario usuario)
        {
            var updatedUsuario = await _usuarioRepository.UpdateUsuario(usuario);
            return Result.Ok(updatedUsuario);
        }

        public async Task<Result> DeleteUsuario(int id)
        {
            var success = await _usuarioRepository.DeleteUsuario(id);
            return success ? Result.Ok() : Result.Fail("Erro ao deletar usuário");
        }
    }
}
