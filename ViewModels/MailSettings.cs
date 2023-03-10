using Microsoft.Extensions.Options;

namespace Blog23.ViewModels
{
    public class MailSettings
    {
        //to configure and use an smtp server (google)
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
