using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_mobile_app.Models
{
    [NotMapped]
    public abstract class DbBase
    {
        [Key]
        public int Id { get; set; }
    }
}
