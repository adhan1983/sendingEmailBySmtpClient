using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AOM.SendingEmail.Api.Controllers
{
    [ApiController]
    [Route("api/vi/sendingemail")]
    public class SendingEmailController : ControllerBase
    {       
        private readonly ILogger<SendingEmailController> _logger;
        private readonly IEmailProxyClient _proxyClient;

        public SendingEmailController(ILogger<SendingEmailController> logger, IEmailProxyClient proxyClient)
        {
            _logger = logger;
            _proxyClient = proxyClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _proxyClient.SendEmail("adhan.maldonado@yahoo.com.br", "Teste", "Teste Mensagem");

            return Ok("Email enviado com sucesso");
        }
    }
}
