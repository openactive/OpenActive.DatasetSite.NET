using OpenActive.NET;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace OpenActive.DatasetSite.NET.Tests
{
    public class SimpleImplementation
    {
        private readonly ITestOutputHelper output;

        public SimpleImplementation(ITestOutputHelper output)
        {
            this.output = output;
        }

        // Customer-specific settings for dataset JSON (these should come from a database)
        private DatasetSiteGeneratorSettings settings = new DatasetSiteGeneratorSettings
        {
            OpenDataFeedBaseUrl = "https://customer.example.com/feed".ParseUrlOrNull(),
            OpenBookingAPIBaseUrl = "https://customer.example.com/api/openbooking".ParseUrlOrNull(),
            OpenBookingAPIAuthenticationAuthorityUrl = "https://auth.acmebooker.example.com".ParseUrlOrNull(),
            DatasetSiteUrl = "https://halo-odi.legendonlineservices.co.uk/openactive/".ParseUrlOrNull(),
            DatasetDiscussionUrl = "https://github.com/gll-better/opendata".ParseUrlOrNull(),
            DatasetDocumentationUrl = "https://docs.acmebooker.example.com/".ParseUrlOrNull(),
            DatasetLanguages = new List<string> { "en-GB" },
            OrganisationName = "Better",
            OrganisationUrl = "https://www.better.org.uk/".ParseUrlOrNull(),
            OrganisationLegalEntity = "GLL",
            OrganisationPlainTextDescription = "Established in 1993, GLL is the largest UK-based charitable social enterprise delivering leisure, health and community services. Under the consumer facing brand Better, we operate 258 public Sports and Leisure facilities, 88 libraries, 10 children�s centres and 5 adventure playgrounds in partnership with 50 local councils, public agencies and sporting organisations. Better leisure facilities enjoy 46 million visitors a year and have more than 650,000 members.",
            OrganisationLogoUrl = "http://data.better.org.uk/images/logo.png".ParseUrlOrNull(),
            OrganisationEmail = "info@better.org.uk",
            PlatformName = "AcmeBooker",
            PlatformUrl = "https://acmebooker.example.com/".ParseUrlOrNull(),
            PlatformVersion = "2.0",
            BackgroundImageUrl = "https://data.better.org.uk/images/bg.jpg".ParseUrlOrNull(),
            DateFirstPublished = new DateTimeOffset(new DateTime(2019, 01, 14))
        };

        private List<OpportunityType> supportedFeeds = new List<OpportunityType> {
            OpportunityType.SessionSeries,
            OpportunityType.ScheduledSession,
            OpportunityType.FacilityUse,
            OpportunityType.FacilityUseSlot,
            OpportunityType.CourseInstance
        };

        [Fact]
        public void SettingsContainedInSingleFileTemplateRenderedPage()
        {
            var html = DatasetSiteGenerator.RenderSimpleDatasetSite(settings, supportedFeeds);
            output.WriteLine(html);
            Assert.Contains(settings.OrganisationPlainTextDescription, html);
        }

        [Fact]
        public void SettingsContainedInCspCompatibleRenderedPage()
        {
            var html = DatasetSiteGenerator.RenderSimpleDatasetSite(settings, supportedFeeds, "./example-assets-directory/");
            output.WriteLine(html);
            // Slash should be removed, which this asserts
            Assert.Contains("\"./example-assets-directory/datasetsite.styles", html);
        }
    }
}
