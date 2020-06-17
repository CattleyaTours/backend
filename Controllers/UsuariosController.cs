using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly CattleyaToursContext context;
        private readonly JWTSettings jwtSettings;

        private readonly ILogger<UsuariosController> logger;

        public UsuariosController(CattleyaToursContext _context, IOptions<JWTSettings> _jwtSettings, ILogger<UsuariosController> _logger)
        {
            context = _context;
            jwtSettings = _jwtSettings.Value;
            logger = _logger;
        }

        // GET: api/Usuarios/Login
        [HttpPost("Login")]
        public async Task<ActionResult<IEnumerable<UsuarioConToken>>> Login([FromBody] UsuarioAuth usuario)
        {
            var _usuario = await context.Usuarios
                .Where(x => x.Email == usuario.Email)
                .FirstOrDefaultAsync();

            if (_usuario == null || !BCrypt.Net.BCrypt.Verify(usuario.Password, _usuario.Password))
            {
                return Unauthorized("Credenciales invalidas");
            }

            _usuario.Password = null;
            UsuarioConToken usuario_con_token = new UsuarioConToken()
            {
                usuario = _usuario,
                token = GetNewTokenString(_usuario),
            };
            return Ok(usuario_con_token);
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await context.Usuarios.ToListAsync();
            usuarios.ForEach(u => u.Password = null);
            return usuarios;
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }
            usuario.Password = null;
            return usuario;
        }

        // PUT: api/Usuarios/rol/1
        [HttpPut("rol/{id}")]
        public async Task<IActionResult> PutUsuarioRol(int id, UsuarioDTO usuarioDTO)
        {

            if (id != usuarioDTO.Id)
            {
                return BadRequest("El id no corresponde al usuario que intenta modificar");
            }

            var usuario = await context.Usuarios
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            //Datos que cambiaron
            usuario.RolId=usuarioDTO.RolId;
            
            
            context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound("El usuario especificado no existe");
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest("El id no corresponde al usuario que intenta modificar");
            }
            //Si la contraseña cambio, encriptar la nueva contraseña
            if (usuario.Password != null)
            {
                usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            }
            context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound("El usuario especificado no existe");
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Usuarios/Register
        [HttpPost("Register")]
        public async Task<ActionResult<UsuarioConToken>> Register(Usuario usuario)
        {
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            var u = context.Usuarios.Where(x => x.Email == usuario.Email || x.Username == usuario.Username).FirstOrDefault();
            if (u != null)
            {
                if (u.Email == usuario.Email)
                {
                    return BadRequest("Este correo ya esta registrado");
                }
                return BadRequest("Este nombre de usuario ya esta registrado");
            }

            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();
            usuario.Password = null;
            UsuarioConToken usuarioConToken = new UsuarioConToken
            {
                usuario = usuario,
                token = GetNewTokenString(usuario)
            };
            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuarioConToken);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound("El usuario especificado no existe");
            }

            context.Usuarios.Remove(usuario);
            await context.SaveChangesAsync();
            usuario.Password = null;
            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return context.Usuarios.Any(e => e.Id == id);
        }

        private string GetNewTokenString(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Email, usuario.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
