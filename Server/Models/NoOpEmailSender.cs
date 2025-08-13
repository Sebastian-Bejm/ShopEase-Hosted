using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

public class NoOpEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // No-op: log or ignore
        return Task.CompletedTask;
    }
}