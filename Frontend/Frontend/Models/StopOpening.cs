using System;
using System.Collections.Generic;
using System.Text;

namespace Frontend.Models
{
    public abstract class StopOpening : DbBase
    {
        public byte IfUnvisible { get; set; }

        public byte IfVisible { get; set; }

        public byte IfUnlocked { get; set; }

        public short Value { get; set; }

    }
}
