
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenActive.DatasetSite.NET
{
    public enum OpportunityType
    {
        SessionSeries,
        ScheduledSession,
        FacilityUse,
        IndividualFacilityUse,
        FacilityUseSlot,
        IndividualFacilityUseSlot,
        Course,
        CourseInstance,
        CourseInstanceSubEvent,
        HeadlineEvent,
        HeadlineEventSubEvent,
        Event,
        EventSeries,
        OnDemandEvent
    }

    public static class OpportunityTypes
    {
        public readonly static Dictionary<OpportunityType, OpportunityTypeConfiguration> Configurations = new Dictionary<OpportunityType, OpportunityTypeConfiguration>
        {
            {
                OpportunityType.SessionSeries,
                new OpportunityTypeConfiguration {
                    Identifier = "SessionSeries",
                    Name = "SessionSeries",
                    SameAs = new Uri("https://openactive.io/SessionSeries"),               
                    Parent = OpportunityType.EventSeries,
                    DefaultFeedPath = "session-series",
                    Bookable = false
                }
            },
            {
                OpportunityType.ScheduledSession,
                new OpportunityTypeConfiguration {
                    Identifier = "ScheduledSession",
                    Name = "ScheduledSession",
                    SameAs = new Uri("https://openactive.io/ScheduledSession"),               
                    Parent = OpportunityType.SessionSeries,
                    DefaultFeedPath = "scheduled-sessions",
                    Bookable = true
                }
            },
            {
                OpportunityType.FacilityUse,
                new OpportunityTypeConfiguration {
                    Identifier = "FacilityUse",
                    Name = "FacilityUse",
                    SameAs = new Uri("https://openactive.io/FacilityUse"),
                    DefaultFeedPath = "facility-uses",
                    Bookable = false
                }
            },
            {
                OpportunityType.IndividualFacilityUse,
                new OpportunityTypeConfiguration {
                    Identifier = "IndividualFacilityUse",
                    Name = "IndividualFacilityUse",
                    SameAs = new Uri("https://openactive.io/IndividualFacilityUse"),
                    DefaultFeedPath = "individual-facility-uses",
                    Bookable = false
                }
            },
            {
                OpportunityType.FacilityUseSlot,
                new OpportunityTypeConfiguration {
                    Identifier = "FacilityUseSlot",
                    Name = "Slot for FacilityUse",
                    SameAs = new Uri("https://openactive.io/Slot"),               
                    Parent = OpportunityType.FacilityUse,
                    DefaultFeedPath = "facility-use-slots",
                    Bookable = true
                }
            },
            {
                OpportunityType.IndividualFacilityUseSlot,
                new OpportunityTypeConfiguration {
                    Identifier = "IndividualFacilityUseSlot",
                    Name = "Slot for IndividualFacilityUse",
                    SameAs = new Uri("https://openactive.io/Slot"),               
                    Parent = OpportunityType.IndividualFacilityUse,
                    DefaultFeedPath = "individual-facility-use-slots",
                    Bookable = true
                }
            },
            {
                OpportunityType.Course,
                new OpportunityTypeConfiguration {
                    Identifier = "Course",
                    Name = "Course",
                    SameAs = new Uri("https://schema.org/Course"),
                    DefaultFeedPath = "courses",
                    Bookable = false
                }
            },
            {
                OpportunityType.CourseInstance,
                new OpportunityTypeConfiguration {
                    Identifier = "CourseInstance",
                    Name = "CourseInstance",
                    SameAs = new Uri("https://schema.org/CourseInstance"),               
                    Parent = OpportunityType.Course,
                    DefaultFeedPath = "course-instances",
                    Bookable = true
                }
            },
            {
                OpportunityType.CourseInstanceSubEvent,
                new OpportunityTypeConfiguration {
                    Identifier = "CourseInstanceSubEvent",
                    Name = "Event for CourseInstance",
                    SameAs = new Uri("https://schema.org/Event"),               
                    Parent = OpportunityType.CourseInstance,
                    DefaultFeedPath = "course-instance-subevents",
                    Bookable = true
                }
            },
            {
                OpportunityType.HeadlineEvent,
                new OpportunityTypeConfiguration {
                    Identifier = "HeadlineEvent",
                    Name = "HeadlineEvent",
                    SameAs = new Uri("https://openactive.io/HeadlineEvent"),               
                    Parent = OpportunityType.EventSeries,
                    DefaultFeedPath = "headline-events",
                    Bookable = true
                }
            },
            {
                OpportunityType.HeadlineEventSubEvent,
                new OpportunityTypeConfiguration {
                    Identifier = "HeadlineEventSubEvent",
                    Name = "Event for HeadlineEvent",
                    SameAs = new Uri("https://schema.org/Event"),               
                    Parent = OpportunityType.HeadlineEvent,
                    DefaultFeedPath = "headline-event-subevents",
                    Bookable = true
                }
            },
            {
                OpportunityType.Event,
                new OpportunityTypeConfiguration {
                    Identifier = "Event",
                    Name = "Event",
                    SameAs = new Uri("https://schema.org/Event"),               
                    Parent = OpportunityType.EventSeries,
                    DefaultFeedPath = "events",
                    Bookable = true
                }
            },
            {
                OpportunityType.EventSeries,
                new OpportunityTypeConfiguration {
                    Identifier = "EventSeries",
                    Name = "EventSeries",
                    SameAs = new Uri("https://schema.org/EventSeries"),
                    DefaultFeedPath = "event-series",
                    Bookable = false
                }
            },
            {
                OpportunityType.OnDemandEvent,
                new OpportunityTypeConfiguration {
                    Identifier = "OnDemandEvent",
                    Name = "OnDemandEvent",
                    SameAs = new Uri("https://schema.org/OnDemandEvent"),
                    DefaultFeedPath = "on-demand-event",
                    Bookable = true
                }
            }
        };
    }
}
