

namespace Frontend.Models
{
    public abstract class Account : DbBase
    {

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}