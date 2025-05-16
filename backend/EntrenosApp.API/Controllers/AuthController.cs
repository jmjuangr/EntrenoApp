using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EntrenosApp.Data;
using EntrenosApp.Models;

namespace EntrenosApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly EntrenosDbContext _context;
        private readonly IConfiguration _config;

        public AuthController(EntrenosDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public class LoginRequest
        {
            public string Nombre { get; set; } = string.Empty;
            public string Pass { get; set; } = string.Empty;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u =>
                u.Nombre == request.Nombre && u.Pass == request.Pass);

            if (usuario == null)
                return Unauthorized(new { mensaje = "Credenciales incorrectas" });

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Role, usuario.Admin ? "Admin" : "User"),
                new Claim("UsuarioId", usuario.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new
            {
                token = tokenString,
                usuario = new
                {
                    usuario.Id,
                    usuario.Nombre,
                    usuario.Admin
                }
            });
        }
    }
}
