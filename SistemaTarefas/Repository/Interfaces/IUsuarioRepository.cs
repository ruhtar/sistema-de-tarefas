using SistemaTarefas.Models;

namespace SistemaTarefas.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarUsuarioPorId(int id);
        Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario);
        Task<UsuarioModel> EditarUsuario(UsuarioModel usuario, int id);
        Task<bool> DeletarUsuario(int id);
    }
}
