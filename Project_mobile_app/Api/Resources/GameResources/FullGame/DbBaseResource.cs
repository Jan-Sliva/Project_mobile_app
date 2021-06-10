using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_mobile_app.Api.Resources.GameResources.FullGame
{
    public abstract class DbBaseResource
    {
        public int Id { get; set; }
    }
}
