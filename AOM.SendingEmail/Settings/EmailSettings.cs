namespace AOM.SendingEmail.ClientEmail.Settings
{
    public class EmailSettings : IEmailSettings
    {
        public string PrimaryDomain { get; set; }
        public int PrimaryPort { get; set; }
        public string UsernameEmail { get; set; }
        public string DisplayName { get; set; }
        public string UsernamePassword { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string CcEmail { get; set; }
    }
}
