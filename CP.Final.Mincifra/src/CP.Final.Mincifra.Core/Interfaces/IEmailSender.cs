using System.Threading.Tasks;

namespace CP.Final.Mincifra.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
