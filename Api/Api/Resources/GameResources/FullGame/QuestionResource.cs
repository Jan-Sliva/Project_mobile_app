using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Resources.GameResources.FullGame
{
    public abstract class QuestionResource : DbBaseResource
    {
#nullable disable
        public string QuestionText { get; set; } // HTML
#nullable enable
        public ICollection<ChoiceResource>? ChoicesThatOpensThis { get; set; }

    }
}