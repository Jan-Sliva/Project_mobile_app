using System;
using System.Collections.Generic;
using System.Text;

namespace Project_mobile_app.Models
{
    public class ChoiceStop : StopOpening
    {
        public Choice ChoiceOpensThis { get; set; }

        public int ChoiceOpensThisId { get; set; }

        public Stop Opens { get; set; }

        public int OpensId { get; set; }

    }
}
