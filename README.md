# OpenActive.DatasetSite.NET [![Nuget](https://img.shields.io/nuget/v/OpenActive.DatasetSite.NET.svg)](https://www.nuget.org/packages/OpenActive.DatasetSite.NET/)
C# .NET helper functions supporting dataset site creation, to create something like [this example](https://opendata.fusion-lifestyle.com/OpenActive/) (or any of the other examples listed [here](http://status.openactive.io/)).

This package intends to simplify creation of [OpenActive Dataset Sites](https://developer.openactive.io/publishing-data/dataset-sites) using templates.

For comparison, see the [PHP](https://github.com/openactive/dataset-site-template-php) and [Ruby](https://github.com/openactive/dataset-site-template-ruby) implementations.

Please find full documentation that covers creation of the accompanying GitHub issues board at https://developer.openactive.io/publishing-data/dataset-sites.

## Table Of Contents
- [Requirements](#requirements)
- [Dependencies](#dependencies)
- [Usage options](#usage-options)
    - [Simple implementation](#simple-implementation)
    - [Feed-level customisation](#feed-level-customisation)
    - [Model-level customisation](#model-level-customisation)
	- [Total customisation](#total-customisation)

## Requirements
This project requires .NET Framework 4.5 or .NET Standard 2.0.

## Dependencies
This library makes use of [datasetsite.mustache](https://github.com/openactive/dataset-site-template/), which is designed to conform to the [Dataset API Discovery specification](https://www.openactive.io/dataset-api-discovery/EditorsDraft/). Pull requests and suggestions for improvements to [datasetsite.mustache](https://github.com/openactive/dataset-site-template/) are welcome via its [GitHub repository](https://github.com/openactive/dataset-site-template/).

[OpenActive.NET](https://github.com/openactive/OpenActive.NET) is also used for strongly typed OpenActive models, and [Stubble](https://github.com/StubbleOrg/Stubble) for rendering the dataset site mustache template.

## Usage options

Simply call one of the Render methods detailed below to output self-contained HTML of the dataset site, which includes embedded styles.

### Simple implementation

> `RenderSimpleDatasetSite(settings, supportedOpportunityTypes)`

Returns a string corresponding to the compiled HTML, based on an embedded version of `datasetsite.mustache`, the provided `settings`, and `supportedOpportunityTypes`.

`supportedOpportunityTypes` must be a `List<OpportunityType>`, which auto-generates the metadata associated which each feed using best-practice values.

`settings` must contain the following object:

#### DatasetSiteGeneratorSettings

| Property                           | Type     | Description |
| ---------------------------------- | -------- | ----------- |
| `OpenDataFeedBaseUrl`              | `Uri`    | The base URL for the open data feeds (must not contain trailing `/`) |
| `DatasetSiteUrl`                   | `Uri`    | The URL where this dataset site is displayed (the page's own URL) |
| `DatasetDiscussionUrl`             | `Uri`    | The GitHub issues page for the dataset |
| `DatasetDocumentationUrl`          | `Uri`    | Any documentation specific to the dataset. Defaults to https://developer.openactive.io/ if not provided, which should be used if no documentation is available. |
| `DatasetLanguages`           | `List<string>` | The languages available in the dataset, following the IETF BCP 47 standard. Defaults to 'en-GB'. |
| `OrganisationName`                 | `string` | The publishing organisation's name |
| `OrganisationUrl`                  | `Uri`    | The publishing organisation's URL |
| `OrganisationLegalEntity`          | `string` | The legal name of the publishing organisation of this dataset |
| `OrganisationPlainTextDescription` | `string` | A plain text description of this organisation |
| `OrganisationLogoUrl`              | `Uri`    | An image URL of the publishing organisation's logo, ideally in PNG format |
| `OrganisationEmail`                | `string` | The contact email of the publishing organisation of this dataset |
| `PlatformName`                     | `string` | The software platform's name. Only set this if different from the publishing organisation, otherwise leave as null to exclude platform metadata. |
| `PlatformUrl`                      | `Uri`    | The software platform's website |
| `PlatformSoftwareVersion`          | `string` | The software platform's software version |
| `BackgroundImageUrl`               | `Uri`    | The background image to show on the Dataset Site page |
| `DateFirstPublished`               | `DateTimeOffset` | The date the dataset was first published |



#### Example

```cs
[Route("openactive")]
public class DatasetSiteController : Controller
{
    // GET: /openactive/
    public IActionResult Index()
    {
        // Customer-specific settings for dataset JSON (these should come from a database)
        var settings = new DatasetSiteGeneratorSettings
        {
            OpenDataFeedBaseUrl = "https://customer.example.com/feed".ParseUrlOrNull(),
            OpenBookingAPIBaseUrl = "https://customer.example.com/api/openbooking".ParseUrlOrNull(),
            OpenBookingAPIAuthenticationAuthority = "https://auth.acmebooker.example.com/".ParseUrlOrNull(),
            DatasetSiteUrl = "https://halo-odi.legendonlineservices.co.uk/openactive/".ParseUrlOrNull(),
            DatasetDiscussionUrl = "https://github.com/gll-better/opendata".ParseUrlOrNull(),
            DatasetDocumentationUrl = "https://docs.acmebooker.example.com/".ParseUrlOrNull(),
            DatasetLanguages = new List<string> { "en-GB" },
            OrganisationName = "Better",
            OrganisationUrl = "https://www.better.org.uk/".ParseUrlOrNull(),
            OrganisationLegalEntity = "GLL",
            OrganisationPlainTextDescription = "Established in 1993, GLL is the largest UK-based charitable social enterprise delivering leisure, health and community services. Under the consumer facing brand Better, we operate 258 public Sports and Leisure facilities, 88 libraries, 10 children’s centres and 5 adventure playgrounds in partnership with 50 local councils, public agencies and sporting organisations. Better leisure facilities enjoy 46 million visitors a year and have more than 650,000 members.",
            OrganisationLogoUrl = "http://data.better.org.uk/images/logo.png".ParseUrlOrNull(),
            OrganisationEmail = "info@better.org.uk",
            PlatformName = "AcmeBooker",
            PlatformUrl = "https://acmebooker.example.com/".ParseUrlOrNull(),
            PlatformVersion = "2.0",
            BackgroundImageUrl = "https://data.better.org.uk/images/bg.jpg".ParseUrlOrNull(),
            DateFirstPublished = new DateTimeOffset(new DateTime(2019, 01, 14))
        };

        var supportedFeeds = new List<OpportunityType> {
            OpportunityType.SessionSeries,
            OpportunityType.ScheduledSession,
            OpportunityType.FacilityUse,
            OpportunityType.FacilityUseSlot,
            OpportunityType.CourseInstance
        };

        return Content(DatasetSiteGenerator.RenderSimpleDatasetSite(settings, supportedFeeds), "text/html");
    }
}
```


### Feed-level customisation

> `RenderSimpleDatasetSiteFromDataDownloads(settings, dataDownloads, dataFeedDescriptions)`

Returns a string corresponding to the compiled HTML, based on an embedded version of `datasetsite.mustache`, the provided [`settings`](#datasetsitegeneratorsettings), `dataDownloads` and `dataFeedDescriptions`.

The `dataDownloads` argument must be a `List<OpenActive.NET.DataDownload>`, which each describe an available open data feed.

The `dataFeedDescriptions` must be a `List<string>` of strings that each describe the dataset, e.g:
```cs
var dataFeedDescriptions = new List<string> {
    "Sessions",
    "Facilities"
};
```

#### Example

```cs
[Route("openactive")]
public class DatasetSiteController : Controller
{
    // GET: /openactive/
    public IActionResult Index()
    {
        // Customer-specific settings for dataset JSON (these should come from a database)
        var settings = new DatasetSiteGeneratorSettings
        {
            OpenDataFeedBaseUrl = "https://customer.example.com/feed".ParseUrlOrNull(),
            OpenBookingAPIBaseUrl = "https://customer.example.com/api/openbooking".ParseUrlOrNull(),
            OpenBookingAPIAuthenticationAuthority = "https://auth.acmebooker.example.com/".ParseUrlOrNull(),
            DatasetSiteUrl = "https://halo-odi.legendonlineservices.co.uk/openactive/".ParseUrlOrNull(),
            DatasetDiscussionUrl = "https://github.com/gll-better/opendata".ParseUrlOrNull(),
            DatasetDocumentationUrl = "https://docs.acmebooker.example.com/".ParseUrlOrNull(),
            DatasetLanguages = new List<string> { "en-GB" },
            OrganisationName = "Better",
            OrganisationUrl = "https://www.better.org.uk/".ParseUrlOrNull(),
            OrganisationLegalEntity = "GLL",
            OrganisationPlainTextDescription = "Established in 1993, GLL is the largest UK-based charitable social enterprise delivering leisure, health and community services. Under the consumer facing brand Better, we operate 258 public Sports and Leisure facilities, 88 libraries, 10 children’s centres and 5 adventure playgrounds in partnership with 50 local councils, public agencies and sporting organisations. Better leisure facilities enjoy 46 million visitors a year and have more than 650,000 members.",
            OrganisationLogoUrl = "http://data.better.org.uk/images/logo.png".ParseUrlOrNull(),
            OrganisationEmail = "info@better.org.uk",
            PlatformName = "AcmeBooker",
            PlatformUrl = "https://acmebooker.example.com/".ParseUrlOrNull(),
            PlatformVersion = "2.0",
            BackgroundImageUrl = "https://data.better.org.uk/images/bg.jpg".ParseUrlOrNull(),
            DateFirstPublished = new DateTimeOffset(new DateTime(2019, 01, 14))
        };

        var dataDownloads = new List<DataDownload>
        {
            new DataDownload
            {
                Name = "SessionSeries",
                AdditionalType = new Uri("https://openactive.io/SessionSeries"),
                EncodingFormat = OpenActiveMediaTypes.RealtimePagedDataExchange.Version1,
                ContentUrl = new Uri(settings.OpenDataFeedBaseUrl + "/session-series"),
                Identifier = "SessionSeries"
            },
            new DataDownload
            {
                Name = "ScheduledSession",
                AdditionalType = new Uri("https://openactive.io/ScheduledSession"),
                EncodingFormat = OpenActiveMediaTypes.RealtimePagedDataExchange.Version1,
                ContentUrl = new Uri(settings.OpenDataFeedBaseUrl + "/scheduled-sessions"),
                Identifier = "ScheduledSession"
            },
            new DataDownload
            {
                Name = "FacilityUse",
                AdditionalType = new Uri("https://openactive.io/FacilityUse"),
                EncodingFormat = OpenActiveMediaTypes.RealtimePagedDataExchange.Version1,
                ContentUrl = new Uri(settings.OpenDataFeedBaseUrl + "/facility-uses"),
                Identifier = "FacilityUse"
            },
            new DataDownload
            {
                Name = "Slot for FacilityUse",
                AdditionalType = new Uri("https://openactive.io/Slot"),
                EncodingFormat = OpenActiveMediaTypes.RealtimePagedDataExchange.Version1,
                ContentUrl = new Uri(settings.OpenDataFeedBaseUrl + "/slots"),
                Identifier = "FacilityUseSlot"
            }
        };

        var dataFeedDescriptions = new List<string> {
            "Sessions",
            "Facilities"
        };

        return Content(DatasetSiteGenerator.RenderSimpleDatasetSiteFromDataDownloads(settings, dataDownloads, dataFeedDescriptions), "text/html");
    }
}
```


### Model-level customisation

> `RenderDatasetSite(dataset)`

Returns a string corresponding to the compiled HTML, based on an embedded version of `datasetsite.mustache`, and the provided `dataset`.

The `dataset` argument must be an object of type `OpenActive.NET.Dataset`, and must contain the properties required to render the dataset site.

#### Example

```cs
[Route("openactive")]
public class DatasetSiteController : Controller
{
    // GET: /openactive/
    public IActionResult Index()
    {
        // Customer-specific settings for dataset JSON (these should come from a database)
        var settings = new DatasetSiteGeneratorSettings
        {
            OpenDataFeedBaseUrl = "https://customer.example.com/feed".ParseUrlOrNull(),
            OpenBookingAPIBaseUrl = "https://customer.example.com/api/openbooking".ParseUrlOrNull(),
            OpenBookingAPIAuthenticationAuthority = "https://auth.acmebooker.example.com/".ParseUrlOrNull(),
            DatasetSiteUrl = "https://halo-odi.legendonlineservices.co.uk/openactive/".ParseUrlOrNull(),
            DatasetDiscussionUrl = "https://github.com/gll-better/opendata".ParseUrlOrNull(),
            DatasetDocumentationUrl = "https://docs.acmebooker.example.com/".ParseUrlOrNull(),
            DatasetLanguages = new List<string> { "en-GB" },
            OrganisationName = "Better",
            OrganisationUrl = "https://www.better.org.uk/".ParseUrlOrNull(),
            OrganisationLegalEntity = "GLL",
            OrganisationPlainTextDescription = "Established in 1993, GLL is the largest UK-based charitable social enterprise delivering leisure, health and community services. Under the consumer facing brand Better, we operate 258 public Sports and Leisure facilities, 88 libraries, 10 children’s centres and 5 adventure playgrounds in partnership with 50 local councils, public agencies and sporting organisations. Better leisure facilities enjoy 46 million visitors a year and have more than 650,000 members.",
            OrganisationLogoUrl = "http://data.better.org.uk/images/logo.png".ParseUrlOrNull(),
            OrganisationEmail = "info@better.org.uk",
            PlatformName = "AcmeBooker",
            PlatformUrl = "https://acmebooker.example.com/".ParseUrlOrNull(),
            PlatformVersion = "2.0",
            BackgroundImageUrl = "https://data.better.org.uk/images/bg.jpg".ParseUrlOrNull(),
            DateFirstPublished = new DateTimeOffset(new DateTime(2019, 01, 14))
        };

        var dataFeedHumanisedList = "Sessions and Facilities";

        var dataset = new Dataset
        {
            Id = settings.DatasetSiteUrl,
            Url = settings.DatasetSiteUrl,
            Name = settings.OrganisationName + " " + dataFeedHumanisedList,
            Description = $"Near real-time availability and rich descriptions relating to the {dataFeedHumanisedList.ToLowerInvariant()} available from {settings.OrganisationName}",
            Keywords = new List<string> {
                "Sessions",
                "Facilities",
                "Activities",
                "Sports",
                "Physical Activity",
                "OpenActive"
            },
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
            Distribution = new List<DataDownload>
            {
                new DataDownload
                {
                    Name = "SessionSeries",
                    AdditionalType = new Uri("https://openactive.io/SessionSeries"),
                    EncodingFormat = OpenActiveMediaTypes.RealtimePagedDataExchange.Version1,
                    ContentUrl = new Uri(settings.OpenDataFeedBaseUrl + "/session-series"),
                    Identifier = "SessionSeries"
                },
                new DataDownload
                {
                    Name = "ScheduledSession",
                    AdditionalType = new Uri("https://openactive.io/ScheduledSession"),
                    EncodingFormat = OpenActiveMediaTypes.RealtimePagedDataExchange.Version1,
                    ContentUrl = new Uri(settings.OpenDataFeedBaseUrl + "/scheduled-sessions"),
                    Identifier = "ScheduledSession"
                },
                new DataDownload
                {
                    Name = "FacilityUse",
                    AdditionalType = new Uri("https://openactive.io/FacilityUse"),
                    EncodingFormat = OpenActiveMediaTypes.RealtimePagedDataExchange.Version1,
                    ContentUrl = new Uri(settings.OpenDataFeedBaseUrl + "/facility-uses"),
                    Identifier = "FacilityUse"
                },
                new DataDownload
                {
                    Name = "Slot for FacilityUse",
                    AdditionalType = new Uri("https://openactive.io/Slot"),
                    EncodingFormat = OpenActiveMediaTypes.RealtimePagedDataExchange.Version1,
                    ContentUrl = new Uri(settings.OpenDataFeedBaseUrl + "/slots"),
                    Identifier = "FacilityUseSlot"
                }
            },
            DatePublished = settings.DateFirstPublished,
            DateModified = DateTimeOffset.UtcNow,
            BackgroundImage = new ImageObject
            {
                Url = settings.BackgroundImageUrl
            },
            BookingService = settings.PlatformName == null ? null : new BookingService
            {
                Name = settings.PlatformName,
                Url = settings.PlatformUrl,
                SoftwareVersion = settings.PlatformVersion
            }
        };

        return Content(DatasetSiteGenerator.RenderDatasetSite(dataset), "text/html");
    }
}
```


### Total customisation

> `RenderDatasetSiteWithTemplate(dataset, mustacheTemplate)`

Returns a string corresponding to the compiled HTML, based on the supplied version of `datasetsite.mustache`, and the provided `dataset`.

The `dataset` argument must be an object of type `OpenActive.NET.Dataset`, and must contain the properties required to render the dataset site.

The `mustacheTemplate` argument must be a string containing the contents of a potentially customised version of `datasetsite.mustache`.

Please note that any customisations must maintain conformance with the [Dataset API Discovery specification](https://www.openactive.io/dataset-api-discovery/EditorsDraft/).
