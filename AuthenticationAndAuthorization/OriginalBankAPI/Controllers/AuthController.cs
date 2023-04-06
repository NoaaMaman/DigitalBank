using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BankApI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public AuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpPost]
        [HttpPost]
        public IActionResult Authenticate([FromBody] Credential credential)
        {
            if (credential.UserName == "admin" && credential.Password == "password")
            {
                //Creating the security context
                var claims = new List<Claim> {
            new Claim(ClaimTypes.Name, "admin"),
            new Claim(ClaimTypes.Email, "admin@mywebsite.com"),
            new Claim("Admin","true"),
            new Claim("Manager","true"),
            new Claim("EmploymentDate","2022-05-01")
        };
                var expiresAt = DateTimeOffset.UtcNow.AddMinutes(10);

                return Ok(new
                {
                    access_token = CreateToken(claims, expiresAt.LocalDateTime),
                    expiresAt = expiresAt,
                });
            }
            ModelState.AddModelError("Unauthorized", "You are not authorized to access the endpoint");
            return Unauthorized(ModelState);

        }



        private string CreateToken(IEnumerable<Claim> claims, DateTime expiresAt)
        {
            var secretKey = configuration.GetValue<string>("SecretKey") ?? throw new ArgumentNullException("SecretKey is missing in configuration.");

            var jwt = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiresAt,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }


        //public string CreateToken(IEnumerable<Claim> claims,DateTime expiresAt)
        //{
        //    var secretKey = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretKey"));
        //    var jwt = new JwtSecurityToken(
        //        Claims: claims,
        //        notBefore: DateTime.UtcNow,
        //        expires: expiresAt,
        //        SigninCredentials: new SigningCredentials(
        //               new SymmetricSecurityKey(secretKey),
        //               SecurityAlgorithms.HmacSha256Signature));


        //    return new JwtSecurityTokenHandler().WriteToken(jwt); 
        //}
        public class Credential
        {
            public string UserName { get; set; }
            public string  Password{ get; set; }
        }
    }
}
