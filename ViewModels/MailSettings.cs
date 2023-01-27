using Microsoft.Extensions.Options;

namespace Blog23.ViewModels
{
    public class MailSettings
    {
        public MailSettings()
        {
        }

        public MailSettings(IConfiguration configuration)
        {
            Configuration = configuration;
            configuration.Bind(this);
        }


        public string? Email { get; set; }
        public string? DisplayName { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
        public IConfiguration? Configuration { get; }
    }

}
