var fs = require('fs');
var fsExtra = require('fs-extra');
var request = require('sync-request');
var path = require('path');
const { getModels, getEnums, getMetaData } = require('@openactive/data-models');
const { getDatasetSiteTemplateSync, getStaticAssetsArchiveUrl, getStaticAssetsVersion } = require('@openactive/dataset-site-template');
const { exit } = require('process');

const DATA_MODEL_OUTPUT_DIR = "../OpenActive.DatasetSite.NET/metadata/";
const SOLUTION_README_FILE_PATH = "../README.md";
const VERSION_FILE_PATH = "../version.json";

updateVersionFile();
removeFiles()
generateDatasetSiteMustacheTemplate();
generateOpportunityTypes();
updateReadme();

function removeFiles() {
    // Empty output directories
    fsExtra.emptyDirSync(DATA_MODEL_OUTPUT_DIR);
}

function generateDatasetSiteMustacheTemplate (datasetSiteTemplateUrl) {
    var singleFileTemplate = getDatasetSiteTemplateSync(true);
    var cspTemplate = getDatasetSiteTemplateSync(false);
    writeFile('DatasetSiteMustacheTemplate', renderMustacheTemplateFile(singleFileTemplate, cspTemplate));
}

function updateReadme() {
    updateFile(SOLUTION_README_FILE_PATH, x => x.replace(/\[CSP compatible static assets archive[^\]]*\]\([^)]*\.zip\)/g, (match) => {
        return `[CSP compatible static assets archive v${getStaticAssetsVersion()}](${getStaticAssetsArchiveUrl()})`;
    }));
}

function getMajorVersion(version) {
    return version.substring(0, version.indexOf("."));
}

function updateVersionFile() {
    // Align version number major version to version of template
    updateFile(VERSION_FILE_PATH, x => {
        const json = JSON.parse(x);
        const oldMajorVersion = getMajorVersion(json.version);
        const newMajorVersion = getStaticAssetsVersion();
        if (parseInt(newMajorVersion) <= parseInt(oldMajorVersion)) {
            console.log("NO MAJOR VERSION CHANGE DETECTED: Hence no update is required. Updates to the template within dataset-site-template must come with a major version bump");
            exit();
        }
        json.version = `${newMajorVersion}.0`;
        return JSON.stringify(json, null, 2);
    });
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

    fs.writeFileSync(DATA_MODEL_OUTPUT_DIR + filename, content);

    console.log("FILE SAVED: " + filename);
}

function updateFile(filepath, mutationFn) {
    const currentContent = fs.readFileSync(filepath, "utf-8");
    const newContent = mutationFn(currentContent);
    
    console.log("NAME: " + filepath);
    console.log(newContent);

    fs.writeFileSync(filepath, newContent);

    console.log("FILE SAVED: " + filepath);
}
