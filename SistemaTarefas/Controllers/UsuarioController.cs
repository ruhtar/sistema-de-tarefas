using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Models;
using SistemaTarefas.Repository;
using SistemaTarefas.Repository.Interfaces;

namespace SistemaTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet] //Verbo Get
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> listaDeUsuarios = await _usuarioRepository.BuscarTodosUsuarios();
            return listaDeUsuarios;
        }

        [HttpGet("{id}")]
        public async Task<UsuarioModel> BuscarUsuarioPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepository.BuscarUsuarioPorId(id);
            return usuario;
        }

        [HttpPost]
        public async Task<UsuarioModel> AdicionarUsuario([FromBody] UsuarioModel usuario)
        {
            UsuarioModel usuarioSalvo = await _usuarioRepository.AdicionarUsuario(usuario);
            return usuarioSalvo;
        }

        [HttpPut("{id}")]
        public async Task<UsuarioModel> EditarUsuario([FromBody] UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioEditado = await _usuarioRepository.EditarUsuario(usuario, id);
            return usuarioEditado;
        }

        [HttpDelete("{id}")]
        public async Task<string> DeletarUsuario(int id)
        {
            bool operacao = await _usuarioRepository.DeletarUsuario(id);
            if(operacao)
            {
                return "Usuário deletado com sucesso!";
            }
            else
            {
                return "Usuário não foi encontrado.";
            }
        }

    }
}
