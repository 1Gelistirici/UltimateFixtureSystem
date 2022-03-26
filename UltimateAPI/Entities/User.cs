
namespace UltimateAPI.Entities
{
    public class User : BaseProperty
    {
        public string Password { get; set; }
        public string PasswordTry { get; set; }
        public string OldPassword { get; set; }
        public string Company { get; set; }
        public string Token { get; set; }
        public string MailAdress { get; set; }
        public string Telephone { get; set; }
        public string Title { get; set; }
        public int Department { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Linkedin { get; set; }
        public string About { get; set; }
        public bool Gender { get; set; }
        public bool Lock { get; set; }
        public string ImageUrl { get; set; }

    }
}
