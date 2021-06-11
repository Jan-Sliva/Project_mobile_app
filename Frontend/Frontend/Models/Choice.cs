using System.Collections.Generic;


namespace Frontend.Models
{
    public abstract class Choice : DbBase
    {

        public ICollection<ChoiceStop> OpensStops { get; set; }

        public ICollection<Question> OpensQuestions { get; set; }

        public ICollection<MapPosition> OpensMapPositions { get; set; }
    }
}