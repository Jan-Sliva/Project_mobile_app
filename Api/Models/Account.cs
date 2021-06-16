using System.ComponentModel.DataAnnotations.Schema;

namespace Project_mobile_app.Models
{
    public abstract class Account : DbBase
    {
#nullable disable
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}