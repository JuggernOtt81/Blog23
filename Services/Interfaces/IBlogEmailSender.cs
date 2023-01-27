using Microsoft.AspNetCore.Identity.UI.Services;

using Blog23.ViewModels;
using Blog23.Services;
using Blog23.Services.Interfaces;

namespace Blog23.Services;

public interface IBlogEmailSender : IEmailSender
{
    Task SendContactEmailAsync(string emailFrom, string name, string subject, string htmlMessage);
}
