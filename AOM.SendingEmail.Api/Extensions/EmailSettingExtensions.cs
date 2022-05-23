using Microsoft.Extensions.Configuration;
using AOM.SendingEmail.ClientEmail.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.SendingEmail.Api.Extensions
{
    public static class EmailSettingExtensions
    {
        public static IServiceCollection AddingEmailSettginsExtensions(this IServiceCollection services, IConfiguration Configuration) 
        {
            services.AddSingleton<IEmailSettings, EmailSettings>(scope =>
            {
                EmailSettings settings = new EmailSettings();

                var sectionEmailSettings = Configuration.GetSection("EmailSettings");

                settings.PrimaryDomain = sectionEmailSettings.GetValue<string>("PrimaryDomain");
                settings.PrimaryPort = sectionEmailSettings.GetValue<int>("PrimaryPort");
                settings.UsernameEmail = sectionEmailSettings.GetValue<string>("UsernameEmail");
                settings.DisplayName = sectionEmailSettings.GetValue<string>("DisplayName");
                settings.UsernamePassword = sectionEmailSettings.GetValue<string>("UsernamePassword");
                settings.FromEmail = sectionEmailSettings.GetValue<string>("FromEmail");
                settings.ToEmail = sectionEmailSettings.GetValue<string>("ToEmaill");
                settings.CcEmail = sectionEmailSettings.GetValue<string>("CcEmail");

                return settings;
            });

            return services;
        }
    }
}
