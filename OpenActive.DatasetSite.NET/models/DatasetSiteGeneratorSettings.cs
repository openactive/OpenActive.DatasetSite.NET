
using System;
using System.Collections.Generic;

namespace OpenActive.DatasetSite.NET
{
    public class DatasetSiteGeneratorSettings
    {
        // **** OPEN DATA ****

        /// <summary>
        /// The the base URL for the open data feeds.
        /// </summary>
        public Uri OpenDataFeedBaseUrl { get; set; }

        /// <summary>
        /// The URL where this dataset site is displayed (the dataset homepage's own URL).
        /// </summary>
        public Uri DatasetSiteUrl { get; set; }

        /// <summary>
        /// The GitHub issues page for the dataset.
        /// </summary>
        public Uri DatasetDiscussionUrl { get; set; }

        /// <summary>
        /// Any documentation specific to the dataset. Defaults to https://developer.openactive.io/ if not provided, which should be used if no documentation is available.
        /// </summary>
        public Uri DatasetDocumentationUrl { get; set; } = new Uri("https://developer.openactive.io/");

        /// <summary>
        /// The languages available in the dataset, following the IETF BCP 47 standard. Defaults to 'en-GB'.
        /// </summary>
        public List<string> DatasetLanguages { get; set; } = new List<string> { "en-GB" };

        /// <summary>
        /// The publishing organisation's name.
        /// </summary>
        public string OrganisationName { get; set; }

        /// <summary>
        /// The publishing organisation's URL.
        /// </summary>
        public Uri OrganisationUrl { get; set; }

        /// <summary>
        /// The legal name of the publishing organisation of this dataset.
        /// </summary>
        public string OrganisationLegalEntity { get; set; }

        /// <summary>
        /// A plain text description of this organisation.
        /// </summary>
        public string OrganisationPlainTextDescription { get; set; }

        /// <summary>
        /// An image URL of the publishing organisation's logo, ideally in PNG format.
        /// </summary>
        public Uri OrganisationLogoUrl { get; set; }
        /// <summary>
        /// The contact email of the publishing organisation of this dataset.
        /// </summary>
        public string OrganisationEmail { get; set; }

        /// <summary>
        /// The software platform's name. Only set this if different from the publishing organisation.
        /// </summary>
        public string PlatformName { get; set; }

        /// <summary>
        /// The software platform's name. Only set this if PlatformName as been set.
        /// </summary>
        public Uri PlatformUrl { get; set; }

        /// <summary>
        /// The software platform's version, useful for on-premise installations.
        /// </summary>
        public string PlatformVersion { get; set; }

        /// <summary>
        /// The background image to show on the Dataset Site page.
        /// </summary>
        public Uri BackgroundImageUrl { get; set; }

        /// <summary>
        /// The date the dataset was first published.
        /// </summary>
        public DateTimeOffset DateFirstPublished { get; set; }

        // **** OPEN BOOKING ****

        /// <summary>
        /// The the base URL for the Open Booking API.
        /// </summary>
        public Uri OpenBookingAPIBaseUrl { get; set; }

        /// <summary>
        /// The the base URL for the Open Booking API.
        /// </summary>
        public Uri OpenBookingAPIDocumentationUrl { get; set; }

        /// <summary>
        /// The the base URL for the Open Booking API.
        /// </summary>
        public Uri OpenBookingAPITermsOfServiceUrl { get; set; }

        /// <summary>
        /// The the base URL for the Open Booking API.
        /// </summary>
        public Uri OpenBookingAPIRegistrationUrl { get; set; }


    }
}