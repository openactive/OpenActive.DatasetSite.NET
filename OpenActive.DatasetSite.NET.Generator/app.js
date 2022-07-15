var fs = require('fs');
var fsExtra = require('fs-extra');
var request = require('sync-request');
var path = require('path');
const { getModels, getEnums, getMetaData } = require('@openactive/data-models');
const { getDatasetSiteTemplateSync } = require('@openactive/dataset-site-template');

const DATA_MODEL_OUTPUT_DIR = "../OpenActive.DatasetSite.NET/metadata/";

removeFiles()
generateDatasetSiteMustacheTemplate();
generateOpportunityTypes();

function removeFiles() {
    // Empty output directories
    fsExtra.emptyDirSync(DATA_MODEL_OUTPUT_DIR);
}

function generateDatasetSiteMustacheTemplate (datasetSiteTemplateUrl) {
    var singleFileTemplate = getDatasetSiteTemplateSync(true);
    var cspTemplate = getDatasetSiteTemplateSync(false);
    writeFile('DatasetSiteMustacheTemplate', renderMustacheTemplateFile(singleFileTemplate, cspTemplate));
}

function renderMustacheTemplateFile(singleFileTemplate, cspTemplate) {
    return `
namespace OpenActive.DatasetSite.NET
{
    public static class DatasetSiteMustacheTemplate
    {
        public const string SingleTemplateFileContent = @"
${singleFileTemplate.replace(/\"/g, '""')}
";

        public const string CspCompatibleTemplateFileContent = @"
${cspTemplate.replace(/\"/g, '""')}
";
    }
}
`;
}

function generateOpportunityTypes() {
    // Returns the latest version of the models map
    const opportunityTypes = getMetaData().opportunityTypes;

    if (opportunityTypes) {
        writeFile('OpportunityTypes', renderOpportunityTypes(opportunityTypes));
    }
}

function renderOpportunityTypes(opportunityTypes) {
    return `
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenActive.DatasetSite.NET
{
    public enum OpportunityType
    {
        ${opportunityTypes.map(c => c.identifier).join(`,
        `)}
    }

    public static class OpportunityTypes
    {
        public readonly static Dictionary<OpportunityType, OpportunityTypeConfiguration> Configurations = new Dictionary<OpportunityType, OpportunityTypeConfiguration>
        {${opportunityTypes.map(c => `
            {
                OpportunityType.${c.identifier},
                new OpportunityTypeConfiguration {
                    Identifier = "${c.identifier}",
                    Name = "${c.name}",
                    SameAs = new Uri("${c.sameAs}")${c.parent ? `,               
                    Parent = OpportunityType.${c.parent}` : ''},
                    DefaultFeedPath = "${c.defaultFeedPath}",
                    Bookable = ${c.bookable}${c.themeDisplayName ? `,               
                    ThemeDisplayName = "${c.themeDisplayName}"` : ''}
                }
            }`).join(',')}
        };
    }
}
`
}

function writeFile(name, content) {
    var filename = name + ".cs";
    
    console.log("NAME: " + filename);
    console.log(content);

    fs.writeFile(DATA_MODEL_OUTPUT_DIR + filename, content, function (err) {
        if (err) {
            return console.log(err);
        }

        console.log("FILE SAVED: " + filename);
    });
}
