using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_mobile_app.Api.Resources.GameResources.FullGame
{
    public abstract class ChoiceResource : DbBaseResource
    {
#nullable enable

        public ICollection<MapPositionResource>? OpensMapPositions { get; set; }
    }
}