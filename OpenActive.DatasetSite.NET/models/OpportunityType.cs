using System;
using System.Collections.Generic;
using System.Text;

namespace OpenActive.DatasetSite.NET
{
    public class OpportunityTypeConfiguration
    {
        public string Name { get; internal set; }
        public Uri SameAs { get; internal set; }
        public string DefaultFeedPath { get; internal set; }
        public List<string> PossibleKinds { get; internal set; }
        public string DisplayName { get; internal set; }
        public string Identifier { get; internal set; }
        public OpportunityType Parent { get; internal set; }
        public bool Bookable { get; internal set; }
    }
}
