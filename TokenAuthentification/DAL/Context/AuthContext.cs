using Microsoft.AspNet.Identity.EntityFramework;

namespace TokenAuthentification.DAL
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }
    }
}