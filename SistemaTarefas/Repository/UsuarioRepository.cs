using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Models;
using SistemaTarefas.Repository.Interfaces;

namespace SistemaTarefas.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _dbContext;

        public UsuarioRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UsuarioModel> BuscarUsuarioPorId(int id)
        {
            try
            {
                return await _dbContext.Usuarios.FirstOrDefaultAsync(element => element.Id == id);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            try
            {
                return await _dbContext.Usuarios.ToListAsync();
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            try
            {
                await _dbContext.Usuarios.AddAsync(usuario);
                await _dbContext.SaveChangesAsync(); //Confirmar a alteração na base de dados
                return usuario;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public async Task<UsuarioModel> EditarUsuario(UsuarioModel usuario, int id)
        {
            var usuarioPorId = await BuscarUsuarioPorId(id);
            if (usuarioPorId == null) throw new Exception($"Usuario {id} não existe");
            try
            {
                usuarioPorId.Nome = usuario.Nome;
                usuarioPorId.Email = usuario.Email;

                _dbContext.Usuarios.Update(usuarioPorId);
                await _dbContext.SaveChangesAsync();
                return usuarioPorId;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }
        public async Task<bool> DeletarUsuario(int id)
        {
            var usuarioPorId = await BuscarUsuarioPorId(id);
            if (usuarioPorId == null) throw new Exception($"Usuario {id} não existe");
            try
            {
                _dbContext.Usuarios.Remove(usuarioPorId);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

    }
}
