
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
        OnDemandEvent,
        Place
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
                    DefaultFeedPath = "/session-series",
                    Bookable = false,               
                    ThemeDisplayName = "Sessions"
                }
            },
            {
                OpportunityType.ScheduledSession,
                new OpportunityTypeConfiguration {
                    Identifier = "ScheduledSession",
                    Name = "ScheduledSession",
                    SameAs = new Uri("https://openactive.io/ScheduledSession"),               
                    Parent = OpportunityType.SessionSeries,
                    DefaultFeedPath = "/scheduled-sessions",
                    Bookable = true,               
                    ThemeDisplayName = "Sessions"
                }
            },
            {
                OpportunityType.FacilityUse,
                new OpportunityTypeConfiguration {
                    Identifier = "FacilityUse",
                    Name = "FacilityUse",
                    SameAs = new Uri("https://openactive.io/FacilityUse"),
                    DefaultFeedPath = "/facility-uses",
                    Bookable = false,               
                    ThemeDisplayName = "Facilities"
                }
            },
            {
                OpportunityType.IndividualFacilityUse,
                new OpportunityTypeConfiguration {
                    Identifier = "IndividualFacilityUse",
                    Name = "IndividualFacilityUse",
                    SameAs = new Uri("https://openactive.io/IndividualFacilityUse"),
                    DefaultFeedPath = "/individual-facility-uses",
                    Bookable = false,               
                    ThemeDisplayName = "Facilities"
                }
            },
            {
                OpportunityType.FacilityUseSlot,
                new OpportunityTypeConfiguration {
                    Identifier = "FacilityUseSlot",
                    Name = "Slot for FacilityUse",
                    SameAs = new Uri("https://openactive.io/Slot"),               
                    Parent = OpportunityType.FacilityUse,
                    DefaultFeedPath = "/facility-use-slots",
                    Bookable = true,               
                    ThemeDisplayName = "Facilities"
                }
            },
            {
                OpportunityType.IndividualFacilityUseSlot,
                new OpportunityTypeConfiguration {
                    Identifier = "IndividualFacilityUseSlot",
                    Name = "Slot for IndividualFacilityUse",
                    SameAs = new Uri("https://openactive.io/Slot"),               
                    Parent = OpportunityType.IndividualFacilityUse,
                    DefaultFeedPath = "/individual-facility-use-slots",
                    Bookable = true,               
                    ThemeDisplayName = "Facilities"
                }
            },
            {
                OpportunityType.Course,
                new OpportunityTypeConfiguration {
                    Identifier = "Course",
                    Name = "Course",
                    SameAs = new Uri("https://schema.org/Course"),
                    DefaultFeedPath = "/courses",
                    Bookable = false,               
                    ThemeDisplayName = "Courses"
                }
            },
            {
                OpportunityType.CourseInstance,
                new OpportunityTypeConfiguration {
                    Identifier = "CourseInstance",
                    Name = "CourseInstance",
                    SameAs = new Uri("https://schema.org/CourseInstance"),               
                    Parent = OpportunityType.Course,
                    DefaultFeedPath = "/course-instances",
                    Bookable = true,               
                    ThemeDisplayName = "Courses"
                }
            },
            {
                OpportunityType.CourseInstanceSubEvent,
                new OpportunityTypeConfiguration {
                    Identifier = "CourseInstanceSubEvent",
                    Name = "Event for CourseInstance",
                    SameAs = new Uri("https://schema.org/Event"),               
                    Parent = OpportunityType.CourseInstance,
                    DefaultFeedPath = "/course-instance-subevents",
                    Bookable = true,               
                    ThemeDisplayName = "Courses"
                }
            },
            {
                OpportunityType.HeadlineEvent,
                new OpportunityTypeConfiguration {
                    Identifier = "HeadlineEvent",
                    Name = "HeadlineEvent",
                    SameAs = new Uri("https://openactive.io/HeadlineEvent"),               
                    Parent = OpportunityType.EventSeries,
                    DefaultFeedPath = "/headline-events",
                    Bookable = true,               
                    ThemeDisplayName = "Headline Events"
                }
            },
            {
                OpportunityType.HeadlineEventSubEvent,
                new OpportunityTypeConfiguration {
                    Identifier = "HeadlineEventSubEvent",
                    Name = "Event for HeadlineEvent",
                    SameAs = new Uri("https://schema.org/Event"),               
                    Parent = OpportunityType.HeadlineEvent,
                    DefaultFeedPath = "/headline-event-subevents",
                    Bookable = true,               
                    ThemeDisplayName = "Headline Events"
                }
            },
            {
                OpportunityType.Event,
                new OpportunityTypeConfiguration {
                    Identifier = "Event",
                    Name = "Event",
                    SameAs = new Uri("https://schema.org/Event"),               
                    Parent = OpportunityType.EventSeries,
                    DefaultFeedPath = "/events",
                    Bookable = true,               
                    ThemeDisplayName = "Events"
                }
            },
            {
                OpportunityType.EventSeries,
                new OpportunityTypeConfiguration {
                    Identifier = "EventSeries",
                    Name = "EventSeries",
                    SameAs = new Uri("https://schema.org/EventSeries"),
                    DefaultFeedPath = "/event-series",
                    Bookable = false
                }
            },
            {
                OpportunityType.OnDemandEvent,
                new OpportunityTypeConfiguration {
                    Identifier = "OnDemandEvent",
                    Name = "OnDemandEvent",
                    SameAs = new Uri("https://schema.org/OnDemandEvent"),
                    DefaultFeedPath = "/on-demand-events",
                    Bookable = true,               
                    ThemeDisplayName = "On Demand Events"
                }
            },
            {
                OpportunityType.Place,
                new OpportunityTypeConfiguration {
                    Identifier = "Place",
                    Name = "Place",
                    SameAs = new Uri("https://schema.org/Place"),
                    DefaultFeedPath = "/places",
                    Bookable = false,               
                    ThemeDisplayName = "Places"
                }
            }
        };
    }
}
