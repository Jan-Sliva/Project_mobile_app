using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Resources.GameResources.FullGame
{
    public abstract class ChoiceResource : DbBaseResource
    {
#nullable enable

        public ICollection<MapPositionResource>? OpensMapPositions { get; set; }
    }
}