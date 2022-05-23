using System.Threading.Tasks;
using AOM.SendingEmail.ClientEmail.Dtos;

namespace AOM.SendingEmail.ClientEmail.Interfaces.Services
{
    public interface IEmailClient
    {
        Task SendEmail(EmailClientDto email);
    }
}
