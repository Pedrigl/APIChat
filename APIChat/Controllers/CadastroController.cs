using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIChat.Models;

namespace APIPEDROCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ClientesController : Controller
    {
        private readonly CadastroContext _context;

        public ClientesController(CadastroContext context)
        {
            _context = context;
        }

        [HttpGet("user/password")]

        public async Task<IActionResult> Get(string user, string password)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.User == user ||m.Password == password);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpPost]

        public async Task<IActionResult> Post(Usuario usuario)
        {
            usuario.User = usuario.User.ToLower();
            usuario.User = (char.ToUpper(usuario.User[0]) + usuario.User.Substring(1));
            var users = _context.Usuarios.FirstOrDefault(m => m.User == usuario.User); 
            
            if (users != null)
                return BadRequest("Já existe um usuário com esse username, por favor escolha outro");

            _context.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]

        public async Task<IActionResult> Put(int Id, Usuario usuarioData)
        {
            if (usuarioData == null || Id == 0)
            {
                return BadRequest();
            }
            
            var usuario = await _context.Usuarios.FindAsync(Id);

            if (usuario == null)
                return BadRequest();
            usuario.Name = usuarioData.Name;
            usuario.Password = usuarioData.Password;
            usuario.User = usuarioData.User;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return BadRequest();
            _context.Remove(usuario);
            await _context.SaveChangesAsync();
            return Ok();

        }

    }
}
