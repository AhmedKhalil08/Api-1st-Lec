using API.DTO;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private IConfiguration _config;
        public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Address = dto.Address
            };
            var result = await _userManager.CreateAsync(user,dto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok(new { msg = "Registered" });
        }

        // login
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserName);
            if(user!= null)
            {
                var valid = await _userManager.CheckPasswordAsync(user, dto.Password);
                if (valid)
                {
                    var token = GenerateToken(user);
                    return Ok(new {token});
                }
                return Unauthorized(new { msg = "Invalid username or password" });
            }
            return Unauthorized(new { msg = "Invalid username or password" });

        }
        // Generation of the token
        private string GenerateToken(ApplicationUser user)
        {
            var claims = new List<Claim> 
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name,user.UserName ?? ""),
                new Claim(ClaimTypes.Email,user.Email?? ""),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
