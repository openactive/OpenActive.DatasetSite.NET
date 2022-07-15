using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenActive.NET;
using Stubble.Core.Builders;
using Stubble.Extensions.JsonNet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenActive.DatasetSite.NET
{
    public static class DatasetSiteGenerator
    {
        /// <summary>
        /// Returns a string corresponding to the compiled HTML, based on an embedded version of `datasetsite.mustache`, the provided `settings`, and `supportedFeedTypes`.
        /// </summary>
        /// <param name="settings">Configuration settings for the dataset site</param>
        /// <param name="supportedFeedTypes">The supplied list auto-generates the metadata associated which each feed using best-practice values.</param>
        /// <param name="staticAssetsPathUrl">A relative or absolute URI path of the directory containing the self-hosted static asset files for the CSP-compatible template. If set, the CSP-compatible template will be used.</param>
        /// <returns>String containing human readable list</returns>
        public static string RenderSimpleDatasetSite(DatasetSiteGeneratorSettings settings, List<OpportunityType> supportedFeedTypes, string staticAssetsPathUrl = null)
        {
            // Check input is not null
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            if (supportedFeedTypes == null) throw new ArgumentNullException(nameof(supportedFeedTypes));

            var supportedOpportunityTypes = supportedFeedTypes.Select(x => OpportunityTypes.Configurations[x]);

            var dataDownloads = supportedOpportunityTypes
                .Select(x => new DataDownload
                {
                    Identifier = x.Identifier,
                    Name = x.Name,
                    AdditionalType = x.SameAs,
                    EncodingFormat = OpenActiveMediaTypes.RealtimePagedDataExchange.Version1,
                    ContentUrl = new Uri(settings.OpenDataFeedBaseUrl + x.DefaultFeedPath)
                })
                .ToList();

            var dataFeedDescriptions = supportedOpportunityTypes.Select(x => x.ThemeDisplayName).Distinct().ToList();

            return RenderSimpleDatasetSiteFromDataDownloads(settings, dataDownloads, dataFeedDescriptions, staticAssetsPathUrl);
        }

        /// <summary>
        /// Converts a list of nouns into a human readable list
        /// 
        /// ["One", "Two", "Three", "Four"] => "One, Two, Three and Four"
        /// </summary>
        /// <param name="list">List of nouns</param>
        /// <returns>String containing human readable list</returns>
        public static string ToHumanisedList(this List<string> list)
        {
            const string separator = ", ";
            var humanList = String.Join(separator, list);
            int i = humanList.LastIndexOf(separator, StringComparison.InvariantCulture);
            if (i >= 0)
                humanList = humanList.Substring(0, i) + " and " + humanList.Substring(i + separator.Length);
            return humanList;
        }

        /// <summary>
        /// Returns a string corresponding to the compiled HTML, based on an embedded version of `datasetsite.mustache`, the provided `settings`, `dataDownloads` and `dataFeedDescriptions`.
        /// </summary>
        /// <param name="settings">Configuration settings for the dataset site</param>
        /// <param name="dataDownloads">A list of DataDownload objects which each describe an available open data feed</param>
        /// <param name="dataFeedDescriptions">A list of strings that each describe the dataset</param>
        /// <param name="staticAssetsPathUrl">A relative or absolute URI path of the directory containing the self-hosted static asset files for the CSP-compatible template. If set, the CSP-compatible template will be used.</param>
        /// <returns>Returns a string corresponding to the compiled HTML</returns>
        public static string RenderSimpleDatasetSiteFromDataDownloads(DatasetSiteGeneratorSettings settings, List<DataDownload> dataDownloads, List<string> dataFeedDescriptions, string staticAssetsPathUrl = null)
        {
            // Check input is not null
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            if (dataDownloads == null) throw new ArgumentNullException(nameof(dataDownloads));
            if (dataFeedDescriptions == null) throw new ArgumentNullException(nameof(dataFeedDescriptions));

            if (settings.OpenDataFeedBaseUrl == null)
            {
                throw new ArgumentNullException($"{nameof(settings.OpenDataFeedBaseUrl)} must not be null", nameof(settings));
            }
            if (settings.OpenDataFeedBaseUrl.ToString().EndsWith("/", System.StringComparison.InvariantCulture))
            {
                throw new ArgumentException($"{nameof(settings.OpenDataFeedBaseUrl)} must not contain a trailing /", nameof(settings));
            }
            if (settings.OpenBookingAPIBaseUrl?.ToString().EndsWith("/", System.StringComparison.InvariantCulture) == true)
            {
                throw new ArgumentException($"{nameof(settings.OpenBookingAPIBaseUrl)} must not contain a trailing /", nameof(settings));
            }

            // Pre-process list of feed descriptions
            var dataFeedHumanisedList = dataFeedDescriptions.ToHumanisedList();
            var keywords = new List<string> {
                    "Activities",
                    "Sports",
                    "Physical Activity",
                    "OpenActive"
                };
            keywords.InsertRange(0, dataFeedDescriptions);

            // Strongly typed JSON generation based on OpenActive.NET
            var dataset = new Dataset
            {
                Id = settings.DatasetSiteUrl,
                Url = settings.DatasetSiteUrl,
                Name = settings.OrganisationName + " " + dataFeedHumanisedList,
                Description = $"Near real-time availability and rich descriptions relating to the {dataFeedHumanisedList.ToLowerInvariant()} available from {settings.OrganisationName}",
                Keywords = keywords,
                License = new Uri("https://creativecommons.org/licenses/by/4.0/"),
                DiscussionUrl = settings.DatasetDiscussionUrl,
                Documentation = settings.DatasetDocumentationUrl ?? new Uri("https://permalink.openactive.io/dataset-site/open-data-documentation"),
                InLanguage = settings.DatasetLanguages,
                SchemaVersion = new Uri("https://openactive.io/modelling-opportunity-data/2.0/"),
                Publisher = new OpenActive.NET.Organization
                {
                    Name = settings.OrganisationName,
                    LegalName = settings.OrganisationLegalEntity,
                    Description = settings.OrganisationPlainTextDescription,
                    Email = settings.OrganisationEmail,
                    Url = settings.OrganisationUrl,
                    Logo = new OpenActive.NET.ImageObject
                    {
                        Url = settings.OrganisationLogoUrl
                    }
                },
                Distribution = dataDownloads,
                DatePublished = settings.DateFirstPublished,
                DateModified = DateTimeOffset.UtcNow,
                BackgroundImage = new ImageObject {
                    Url = settings.BackgroundImageUrl
                },
                BookingService = settings.PlatformName == null ? null : new BookingService
                {
                    Name = settings.PlatformName,
                    Url = settings.PlatformUrl,
                    SoftwareVersion = settings.PlatformVersion,
                    HasCredential = settings.TestSuiteCertificateUrl
                },
                AccessService = settings.OpenBookingAPIBaseUrl == null ? null : new WebAPI
                {
                    Name = "Open Booking API",
                    Description = $"API that allows for seamless booking experiences to be created for {dataFeedHumanisedList.ToLowerInvariant()} available from {settings.OrganisationName}",
                    Documentation = settings.OpenBookingAPIDocumentationUrl ?? new Uri("https://permalink.openactive.io/dataset-site/open-booking-api-documentation"),
                    TermsOfService = settings.OpenBookingAPITermsOfServiceUrl,
                    EndpointUrl = settings.OpenBookingAPIBaseUrl,
                    AuthenticationAuthority = settings.OpenBookingAPIAuthenticationAuthorityUrl,
                    ConformsTo = new List<Uri> { new Uri("https://openactive.io/open-booking-api/EditorsDraft/") },
                    EndpointDescription = new Uri("https://www.openactive.io/open-booking-api/EditorsDraft/swagger.json"),
                    LandingPage = settings.OpenBookingAPIRegistrationUrl
                }
            };
            return RenderDatasetSite(dataset, staticAssetsPathUrl);
        }

        /// <summary>
        /// Returns a string corresponding to the compiled HTML, based on an embedded version of `datasetsite.mustache`, and the provided `dataset`.
        /// </summary>
        /// <param name="dataset">The an object containing the properties required to render the dataset site</param>
        /// <param name="staticAssetsPathUrl">A relative or absolute URI path of the directory containing the self-hosted static asset files for the CSP-compatible template. If set, the CSP-compatible template will be used.</param>
        /// <returns>Returns a string corresponding to the compiled HTML</returns>
        public static string RenderDatasetSite(Dataset dataset, string staticAssetsPathUrl = null)
        {
            var template = staticAssetsPathUrl == null ? 
                DatasetSiteMustacheTemplate.SingleTemplateFileContent :
                DatasetSiteMustacheTemplate.CspCompatibleTemplateFileContent;

            return RenderDatasetSiteWithTemplate(dataset, template, staticAssetsPathUrl);
        }

        /// <summary>
        /// Returns a string corresponding to the compiled HTML, based on the supplied content of `datasetsite.mustache`, and the provided `dataset`.
        /// </summary>
        /// <param name="dataset">The an object containing the properties required to render the dataset site</param>
        /// <param name="mustacheTemplate">A string containing the contents of a potentially customised version of datasetsite.mustache</param>
        /// <param name="staticAssetsPathUrl">A relative or absolute URI path of the directory containing the self-hosted static asset files for the CSP-compatible template. If set, the CSP-compatible template will be used.</param>
        /// <returns>Returns a string corresponding to the compiled HTML</returns>
        public static string RenderDatasetSiteWithTemplate(Dataset dataset, string mustacheTemplate, string staticAssetsPathUrl = null)
        {
            // Check input dataset is not null
            if (dataset == null) throw new ArgumentNullException(nameof(dataset));

            // OpenActive.NET creates complete JSON from the strongly typed structure, complete with schema.org types.
            var jsonString = OpenActiveSerializer.SerializeToHtmlEmbeddableString(dataset);

            // Deserialize the completed JSON object to make it compatible with the mustache template
            JObject jsonObj = JObject.Parse(jsonString);

            // Stringify the input JSON using formatting, and place the contents of the string
            // within the "jsonld" property at the root of the JSON itself.
            jsonObj.Add("jsonld", jsonObj.ToString(Formatting.Indented));

            // For the CSP-compatible template, set the "staticAssetsPathUrl" property at the root of the JSON to the relative or absolute
            // URL path of the provided directory (containing the CSP static asset files), without a trailing slash (/)
            if (staticAssetsPathUrl != null) {
                jsonObj.Add("staticAssetsPathUrl", staticAssetsPathUrl.TrimEnd(new[] { '/' }));
            }

            //Use the resulting JSON with the mustache template to render the dataset site.
            var stubble = new StubbleBuilder().Configure(s => s.AddJsonNet()).Build();
            return stubble.Render(mustacheTemplate, jsonObj);
        }
    }
}
