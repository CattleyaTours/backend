using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using backend.Models;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class UsuariosController : ControllerBase
    {
        private readonly CattleyaToursContext _context;
        private readonly IConfiguration _configuration;

        public UsuariosController(CattleyaToursContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Login(string password, string email)
        {
            var usuario = await _context.Usuarios
                .Where(x => x.Email == email)
                .FirstOrDefaultAsync();

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(password, usuario.Password))
            {
                return Unauthorized("Credenciales invalidas");
            }

            usuario.Password = null;

            return Ok(new { usuario, token = GetNewTokenString(usuario)});
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            usuarios.ForEach(u => u.Password = null);
            return Ok(usuarios);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetUsuario(string username)
        {
            var usuario = await _context.Usuarios.FindAsync(username);

            if (usuario == null)
            {
                return NotFound();
            }
            usuario.Password = null;
            return Ok(usuario);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> PutUsuario(Usuario usuario)
        {
            //Si la contraseña cambio, encriptar la nueva contraseña
            if (usuario.Password != null)
            {
                usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            }

            var oldUsuario = await _context.Usuarios.FindAsync(usuario.Username);
            if (oldUsuario == null)
            {
                return NotFound("El usuario especificado no existe");
            }

            oldUsuario.Nacionalidad = usuario.Nacionalidad;
            oldUsuario.Rol = usuario.Rol;
            oldUsuario.Nombres = usuario.Nombres;
            oldUsuario.Telefono = usuario.Telefono;

            if (oldUsuario.Email != usuario.Email)
            {
                if (_context.Usuarios.Any(x => x.Email == usuario.Email))
                {
                    return BadRequest("Este correo ya esta registrado");
                }
                oldUsuario.Email = usuario.Email;
            }

            if (usuario.Username != oldUsuario.Username)
            {
                if (_context.Usuarios.Any(x => x.Username == usuario.Username))
                {
                    return BadRequest("Este nombre de usuario ya esta registrado");
                }
                oldUsuario.Username = usuario.Username;
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Usuario usuario)
        {
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuario.Password);
            
            if (_context.Usuarios.Any(x => x.Email == usuario.Email))
            {
                return BadRequest("Este correo ya esta registrado");
            }
            if (_context.Usuarios.Any(x => x.Username == usuario.Username))
            {
                return BadRequest("Este nombre de usuario ya esta registrado");
            }

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
;
            return Created("Register", new { usuario, token = GetNewTokenString(usuario) });
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult> DeleteUsuario(string username)
        {
            var usuario = await _context.Usuarios.FindAsync(username);
            if (usuario == null)
            {
                return NotFound("El usuario especificado no existe");
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private string GetNewTokenString(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWTKey:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
