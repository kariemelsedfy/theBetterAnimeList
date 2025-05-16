using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Helpers;
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly OAuthService _oauthService;

        public AuthController(IConfiguration config, OAuthService oauthService)
        {
            _config = config;
            _oauthService = oauthService;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            var clientId = _config["MAL:ClientId"];
            var redirect_uri = Uri.EscapeDataString(_config["MAL:RedirectUri"]);
            var state  = Guid.NewGuid().ToString();
            var code_challenge = PkceHelper.GenerateCodeChallegne();
            Console.WriteLine(code_challenge);
            var url = $"https://myanimelist.net/v1/oauth2/authorize?response_type=code" +
                      $"&client_id={clientId}&code_challenge={code_challenge}&redirect_uri={redirect_uri}&state={state}";

            return Redirect(url);
        }

        [HttpGet("callback")]
        public async Task<IActionResult> Callback([FromQuery] string code, [FromQuery] string state)
        {
            var tokenResponse = await _oauthService.ExchangeCodeForTokenAsync(code);
            Console.WriteLine(tokenResponse);
            return Ok(tokenResponse); // or redirect to Angular with token
        }
    }
}