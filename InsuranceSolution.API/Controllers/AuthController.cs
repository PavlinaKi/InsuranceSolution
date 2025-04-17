namespace InsuranceSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenGenerator _tokenGenerator;

        public AuthController(IJwtTokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Email and Password are required.");
            }
            else if (request.Email == "admin@example.com" && request.Password == "password")
            {
                var token = _tokenGenerator.GenerateToken("123", request.Email, "Admin");
                return Ok(new { Token = token });
            }
            else if (request.Email == "agent@example.com" && request.Password == "password")
            {
                var token = _tokenGenerator.GenerateToken("456", request.Email, "Agent");
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials");
        }
    }
}
