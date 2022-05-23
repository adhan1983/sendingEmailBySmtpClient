namespace AOM.SendingEmail.ClientEmail.Settings
{
    public interface IEmailSettings
    {
        string PrimaryDomain { get; set; }
        int PrimaryPort { get; set; }
        string UsernameEmail { get; set; }
        string DisplayName { get; set; }
        string UsernamePassword { get; set; }
        string FromEmail { get; set; }
        string ToEmail { get; set; }
        string CcEmail { get; set; }
    }
}
