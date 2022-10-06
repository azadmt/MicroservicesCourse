namespace IdentityServer
{
    public class UserModel
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }

        public string[] Roles { get; set; }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

    }

    public class SecurityToken
    {
        public string Username { get; set; }
        public string[] Roles { get; set; }
    }
}
