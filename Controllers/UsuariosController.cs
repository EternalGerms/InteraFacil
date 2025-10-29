using Microsoft.AspNetCore.Mvc;
using InteraFacil.API.Models;
using InteraFacil.API.DTOs;
using InteraFacil.API.Data;
using Microsoft.EntityFrameworkCore;

namespace InteraFacil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        // Salva a conexão com o BD
        private readonly ApiDbContext _context;

        public UsuariosController(ApiDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<List<Usuario>> ListarUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> buscarUsuarioPorId(int id)
        {
            Usuario buscaUsuario = await _context.Usuarios.FindAsync(id);
            if (buscaUsuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }
            return Ok(buscaUsuario);
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario(UsuarioDTO usuario)
        {
            var novoUsuario = new Usuario
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Senha = usuario.Senha
            };

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(buscarUsuarioPorId),
                new { id = novoUsuario.Id },
                novoUsuario
            );

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario(int id, UsuarioDTO usuarioAtualizado)
        {
            var buscaUsuario = await _context.Usuarios.FindAsync(id);
            if (buscaUsuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }
            buscaUsuario.Nome = usuarioAtualizado.Nome;
            buscaUsuario.Email = usuarioAtualizado.Email;
            buscaUsuario.Senha = usuarioAtualizado.Senha;
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deletarUsuario(int id)
        {
            var buscaUsuario = await _context.Usuarios.FindAsync(id);
            if (buscaUsuario == null)
            {
                return NotFound($"Usuário com ID {id} não encontrado.");
            }
            _context.Usuarios.Remove(buscaUsuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}