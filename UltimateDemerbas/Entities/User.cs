namespace UltimateDemerbas.Entities
{
    public class User:BaseProperty
    {
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string PasswordTry { get; set; }
        public string Company { get; set; }
        public string Token { get; set; }
        public string MailAdress { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
    }
}
