using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DataContext;
using Service.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AgoraContext _context;

        public UsuariosController(AgoraContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios([FromQuery] string? filter = "")
        {
            return await _context.Usuarios.Where
            (u => u.Nombre.Contains(filter, StringComparison.OrdinalIgnoreCase)
            || u.Apellido.Contains(filter, StringComparison.OrdinalIgnoreCase)
            || u.Email.Contains(filter, StringComparison.OrdinalIgnoreCase)
            || u.Dni.Contains(filter, StringComparison.OrdinalIgnoreCase)).AsNoTracking().ToListAsync();
        }

        [HttpGet("Deleteds")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuariosDeleteds()
        {
            // Devuelve solo los usuarios que tienen IsDeleted en true
            return await _context.Usuarios.IgnoreQueryFilters().Where(c => c.IsDeleted).ToListAsync();
        }
            [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            //controlamos que el email no exista ya y que el dni exista ya
            if (_context.Usuarios.IgnoreQueryFilters().Any(u => u.Email == usuario.Email))
            {
                return Conflict("El usuario ya registrado con el Email ingresado.");
            }
            if (_context.Usuarios.IgnoreQueryFilters().Any(u => u.Dni.Trim().Replace(".", "") == usuario.Dni.Trim()))
            {
                return Conflict("El usuario ya registrado con el DNI ingresado.");
            }
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.IsDeleted = true;
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("Restore/{id}")]
        public async Task<IActionResult> RestoreUsuario(int id)
        {
            var usuario = await _context.Usuarios.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (usuario == null)
            {
                return NotFound();
            }
            usuario.IsDeleted = false;
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
