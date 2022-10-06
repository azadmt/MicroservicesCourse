using System.Collections.Generic;

namespace IdentityServer.Controllers
{
    public static class InMemoryDB
    {
        public static List<User> Users = new List<User>();
        public static Dictionary<string, SecurityToken> Tokens = new Dictionary<string, SecurityToken>();
        public static Dictionary<string, string[]> UserPermissions = new Dictionary<string, string[]>();
        static InMemoryDB()
        {
            Users.Add(new User { Id = 1, Username = "admin", Password = "123", EmailAddress = "admin@mail.com" });
            Users.Add(new User { Id = 2, Username = "guest", Password = "123", EmailAddress = "guest@mail.com" });
            UserPermissions.Add("admin", new[] { "RegisterCustomer", "CreateAccount" });
            UserPermissions.Add("guest", new[] { "RegisterCustomer" });

        }
    }
}
