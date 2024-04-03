using Academy.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AcademyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]

        public IActionResult Login([FromBody] LoginSystem login)
        {
            if (login.Login == "admin" && login.Password == "admin")
            {
                var token = GerarTokenJwt();
                return Ok(new { token });
            }
            return BadRequest("Invalid credentials. Please check your username and password!");
        }

        private string GerarTokenJwt()
        {
            string chaveSecreta = "7aa3ef07-9ecc-43b3-aa53-60dfcfa58721";

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("login", "admin"),
                new Claim("nome", "System Administrator")
            };

            var token = new JwtSecurityToken(
                issuer: "Gym",
                audience: "Gym",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credencial
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
