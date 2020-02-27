using System.Threading.Tasks;

namespace AOM.SendingEmail.Api
{
    public interface IEmailProxyClient
    {
        Task SendEmail(string email, string subject, string message);
    }
}
