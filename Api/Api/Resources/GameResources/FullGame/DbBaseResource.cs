using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Resources.GameResources.FullGame
{
    public abstract class DbBaseResource
    {
        public int Id { get; set; }
    }
}
