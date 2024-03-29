﻿using System;
using System.Collections.Generic;
using System.Text;


namespace Frontend.RestClient.Resources.GameResources.FullGame
{
    public class StopResource : DbBaseResource
    {


        public string Name { get; set; } // HTML

        public bool? IsFinal { get; set; }

        public bool? IsInitial { get; set; }

        public short? State1Requirement { get; set; }

        public short? State2Requirement { get; set; }

        public short? State3Requirement { get; set; }

        public short? State4Requirement { get; set; }

        public ICollection<StopStopResource> Opens { get; set; }

        public ICollection<QuestionResource> Questions { get; set; }

        public ICollection<ChoiceStopResource> ChoicesOpenThis { get; set; }

        public ICollection<DisplayObjectStopDisplayAfterDisplayResource> DisplayObjectsHints { get; set; }

        public ICollection<DisplayObjectStopDisplayAfterUnlockResource>  DisplayObjectsRewards { get; set; }

        public MapPositionResource Position { get; set; }

        public ICollection<MapPositionResource> PositionsDisplayAfterDisplay { get; set; }

        public ICollection<MapPositionResource> PositionsDisplayAfterUnlock { get; set; }

        public ICollection<PasswordGameRequirementResource> Passwords { get; set; }
    }
}
