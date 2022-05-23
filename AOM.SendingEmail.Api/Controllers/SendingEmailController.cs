using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AOM.SendingEmail.ClientEmail.Dtos;
using AOM.SendingEmail.ClientEmail.Interfaces.Services;

namespace AOM.SendingEmail.Api.Controllers
{
    [ApiController]
    [Route("api/v1/sendingemail")]
    public class SendingEmailController : ControllerBase
    {   
        private readonly IEmailClient _proxyClient;
        public SendingEmailController(IEmailClient proxyClient) => _proxyClient = proxyClient;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EmailClientDto email)
        {
            await _proxyClient.SendEmail(email);

            return Ok("Email enviado com sucesso");
        }      
    }
}
