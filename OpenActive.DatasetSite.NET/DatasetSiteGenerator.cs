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
        /// <returns>String containing human readable list</returns>
        public static string RenderSimpleDatasetSite(DatasetSiteGeneratorSettings settings, List<FeedType> supportedFeedTypes)
        {
            // Check input is not null
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            if (supportedFeedTypes == null) throw new ArgumentNullException(nameof(supportedFeedTypes));

            var supportedFeedConfigurations = supportedFeedTypes.Select(x => FeedConfigurations.Configurations[x]);

            var dataDownloads = supportedFeedConfigurations
                .Select(x => new DataDownload
                {
                    Name = x.Name,
                    AdditionalType = x.SameAs,
                    EncodingFormat = OpenActiveDiscovery.MediaTypes.Version1.RealtimePagedDataExchange.ToString(),
                    ContentUrl = new Uri(settings.OpenDataFeedBaseUrl + x.DefaultFeedPath)
                })
                .ToList();

            var dataFeedDescriptions = supportedFeedConfigurations.Select(x => x.DisplayName).Distinct().ToList();

            return RenderSimpleDatasetSiteFromDataDownloads(settings, dataDownloads, dataFeedDescriptions);
        }

        /// <summary>
        /// Converts a list of nouns into a human readable list
        /// 
        /// ["One", "Two", "Three", "Four"] => "One, Two, Three and Four"
        /// </summary>
        /// <param name="list">List of nouns</param>
        /// <returns>String containing human readable list</returns>
        private static string ToHumanisedList(this List<string> list)
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
        /// <returns>Returns a string corresponding to the compiled HTML</returns>
        public static string RenderSimpleDatasetSiteFromDataDownloads(DatasetSiteGeneratorSettings settings, List<DataDownload> dataDownloads, List<string> dataFeedDescriptions)
        {
            // Check input is not null
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            if (dataDownloads == null) throw new ArgumentNullException(nameof(dataDownloads));
            if (dataFeedDescriptions == null) throw new ArgumentNullException(nameof(dataFeedDescriptions));

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
                Documentation = settings.DatasetDocumentationUrl,
                InLanguage = settings.DatasetLanguages,
                SchemaVersion = new Uri("https://www.openactive.io/modelling-opportunity-data/2.0/"),
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
                    SoftwareVersion = settings.PlatformVersion
                }
            };
            return RenderDatasetSite(dataset);
        }

        /// <summary>
        /// Returns a string corresponding to the compiled HTML, based on an embedded version of `datasetsite.mustache`, and the provided `dataset`.
        /// </summary>
        /// <param name="dataset">The an object containing the properties required to render the dataset site</param>
        /// <returns>Returns a string corresponding to the compiled HTML</returns>
        public static string RenderDatasetSite(Dataset dataset)
        {
            return RenderDatasetSiteWithTemplate(dataset, DatasetSiteMustacheTemplate.Content);
        }

        /// <summary>
        /// Returns a string corresponding to the compiled HTML, based on the supplied content of `datasetsite.mustache`, and the provided `dataset`.
        /// </summary>
        /// <param name="dataset">The an object containing the properties required to render the dataset site</param>
        /// <param name="mustacheTemplate">A string containing the contents of a potentially customised version of datasetsite.mustache</param>
        /// <returns>Returns a string corresponding to the compiled HTML</returns>
        public static string RenderDatasetSiteWithTemplate(Dataset dataset, string mustacheTemplate)
        {
            // Check input dataset is not null
            if (dataset == null) throw new ArgumentNullException(nameof(dataset));

            // OpenActive.NET creates complete JSON from the strongly typed structure, complete with schema.org types.
            var jsonString = dataset.ToOpenActiveHtmlEmbeddableString();

            // Deserialize the completed JSON object to make it compatible with the mustache template
            JObject jsonObj = JObject.Parse(jsonString);

            // Stringify the input JSON using formatting, and place the contents of the string
            // within the "json" property at the root of the JSON itself.
            jsonObj.Add("json", jsonObj.ToString(Formatting.Indented));

            //Use the resulting JSON with the mustache template to render the dataset site.
            var stubble = new StubbleBuilder().Configure(s => s.AddJsonNet()).Build();
            return stubble.Render(mustacheTemplate, jsonObj);
        }
    }
}
