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

namespace backend.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        
        private readonly CattleyaToursContext _context;
        private readonly JWTSettings _jwtSettings;

        public AuthenticationController(CattleyaToursContext context, IOptions<JWTSettings> jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        // GET: api/Login
        [HttpPost("Login")]
        public async Task<ActionResult<IEnumerable<UsuarioConToken>>> Login([FromBody] UsuarioAuth usuario)
        {
            var _usuario =  await _context.Usuarios
                .Where(x => (x.Email == usuario.Email || x.Username == usuario.Username) && x.Password == usuario.Password)
                .FirstOrDefaultAsync();
            if (_usuario == null){
                return NotFound();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor(){
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, usuario.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            UsuarioConToken usuario_con_token = new UsuarioConToken(){
                usuario = _usuario,
                token = tokenHandler.WriteToken(token),
            };
            return Ok(usuario_con_token);
        }

    }
}
