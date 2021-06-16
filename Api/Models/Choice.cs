using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_mobile_app.Models
{
    public abstract class Choice : DbBase
    {
#nullable enable
        public ICollection<ChoiceStop>? OpensStops { get; set; }

        public ICollection<Question>? OpensQuestions { get; set; }

        public ICollection<MapPosition>? OpensMapPositions { get; set; }
    }
}