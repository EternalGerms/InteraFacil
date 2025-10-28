using Microsoft.AspNetCore.Mvc;
using InteraFacil.API.Models;
using InteraFacil.API.DTOs;

namespace InteraFacil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private static List<Usuario> _usuarios = new List<Usuario>();

        [HttpGet]
        public List<Usuario> ListarUsuarios()
        {
            return _usuarios;
        }

        [HttpGet("{id}")]
        public IActionResult buscarUsuarioPorId(int id)
        {
            Usuario buscaUsuario = _usuarios.Find(u => u.Id == id);
            if (buscaUsuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }
            return Ok(buscaUsuario);
        }

        [HttpPost]
        public IActionResult CriarUsuario(UsuarioDTO usuario)
        {
            var novoUsuario = new Usuario();
            novoUsuario.Nome = usuario.Nome;
            novoUsuario.Email = usuario.Email;
            novoUsuario.Senha = usuario.Senha;
            novoUsuario.Id = _usuarios.Count + 1;
            _usuarios.Add(novoUsuario);

            return CreatedAtAction(nameof(buscarUsuarioPorId), new { id = novoUsuario.Id}, novoUsuario);

        }

        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, UsuarioDTO usuarioAtualizado)
        {
            var buscaUsuario = _usuarios.Find(u => u.Id == id);
            if (buscaUsuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }     
            buscaUsuario.Nome = usuarioAtualizado.Nome;
            buscaUsuario.Email = usuarioAtualizado.Email;
            buscaUsuario.Senha = usuarioAtualizado.Senha;
            return Ok($"Usuário atualizado: {buscaUsuario.Nome}, Email: {buscaUsuario.Email}");

        }

        [HttpDelete("{id}")]
        public IActionResult deletarUsuario(int id)
        {
            var buscaUsuario = _usuarios.Find(u => u.Id == id);
            if (buscaUsuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }
            _usuarios.Remove(buscaUsuario);
            return Ok($"Usuário com ID {id} deletado com sucesso.");
        }
    }
}