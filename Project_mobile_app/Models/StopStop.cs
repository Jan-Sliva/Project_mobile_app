using System;
using System.Collections.Generic;
using System.Text;

namespace Project_mobile_app.Models
{
    public class StopStop : StopOpening
    {
        public Stop StopOpensThis { get; set; }

        public int StopOpensThisId { get; set; }

        public Stop Opens { get; set; }

        public int OpensId { get; set; }

    }
}
