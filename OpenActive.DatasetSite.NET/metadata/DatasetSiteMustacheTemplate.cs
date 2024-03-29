
namespace OpenActive.DatasetSite.NET
{
    public static class DatasetSiteMustacheTemplate
    {
        public const string SingleTemplateFileContent = @"
<!DOCTYPE HTML>
<!--
  OpenActive Dataset Site Template version 7, from https://unpkg.com/@openactive/dataset-site-template@7.0.0/dist/datasetsite.mustache
-->
<!--
  Design: Identity by HTML5 UP
  html5up.net | @ajlkn
  Free for personal and commercial use under the CCA 3.0 license (html5up.net/license)

  DCAT Template: Nick Evans / imin
  imin.co | @nickevans / @_imin_
  For openactive.io
  Free for personal and commercial use under the CC-BY v4.0 license (https://creativecommons.org/licenses/by/4.0/)
-->
<html prefix=""dct: http://purl.org/dc/terms/
              rdf: http://www.w3.org/1999/02/22-rdf-syntax-ns#
              dcat: http://www.w3.org/ns/dcat#
              foaf: http://xmlns.com/foaf/0.1/
              og: http://ogp.me/ns#
              odrs: http://schema.theodi.org/odrs#""
      lang=""en"">
<head>
    <title>{{name}} - Open Data</title>

    <meta name=""title"" content=""{{name}}  - Open Data"" />
    <meta name=""identifier"" content=""{{url}}"" />
    <meta name=""Keywords"" content=""{{#keywords}}{{.}},{{/keywords}}Open Data"" />
    <meta name=""Description"" content=""{{description}}"" />
    <meta name=""language"" content=""English"" />

    <meta property=""og:title"" content=""{{name}} - Open Data"" />
    <meta property=""og:description"" content=""{{description}}"" />
    <meta property=""og:locale"" content=""en_GB"" />
    <meta property=""og:url"" content=""{{url}}"" />
    <meta property=""og:image"" content=""{{publisher.logo.url}}"" />

    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
    
    <!-- JSON-LD conforming to Google Structured Data specification. -->
    <script type=""application/ld+json"">
{{{jsonld}}}
    </script>
    
    <link rel=""stylesheet"" href=""https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,600"" crossorigin=""anonymous"">
    <style>
/*
    Identity by HTML5 UP
    html5up.net | @ajlkn
    Free for personal and commercial use under the CCA 3.0 license (html5up.net/license)
*/

/*
Font Awesome 4.7.0
Extracts from: https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.css
*/

@font-face {
    font-family: 'FontAwesome';
    font-style: normal;
    font-weight: normal;
    src: url(https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/fonts/fontawesome-webfont.woff) format('woff');
}

.fa {
    display: inline-block;
    font: normal normal normal 14px/1 FontAwesome;
    font-size: inherit;
    text-rendering: auto;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
}
.fa-info:before {
    content: ""\f129"";
}
.fa-comments:before {
    content: ""\f086"";
}
.fa-certificate:before {
    content: ""\f0a3"";
}
.fa-cloud-download:before {
    content: ""\f0ed"";
}
.fa-key:before {
    content: ""\f084"";
}

/* OpenActive logo */

.openactive-logo {
    background: url(data:image/png;base64,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) no-repeat;
    background-size: contain;
    background-position: center;
    width: 8.5em;
    height: 1.5em;
}

/* Reset */

    html, body, div, span, applet, object, iframe, h1, h2, h3, h4, h5, h6, p, blockquote, pre, a, abbr, acronym, address, big, cite, code, del, dfn, em, img, ins, kbd, q, s, samp, small, strike, strong, sub, sup, tt, var, b, u, i, center, dl, dt, dd, ol, ul, li, fieldset, form, label, legend, table, caption, tbody, tfoot, thead, tr, th, td, article, aside, canvas, details, embed, figure, figcaption, footer, header, hgroup, menu, nav, output, ruby, section, summary, time, mark, audio, video {
        margin: 0;
        padding: 0;
        border: 0;
        font-size: 100%;
        font: inherit;
        vertical-align: baseline;
    }

    article, aside, details, figcaption, figure, footer, header, hgroup, menu, nav, section {
        display: block;
    }

    body {
        line-height: 1;
    }

    ol, ul {
        list-style: none;
    }

    blockquote, q {
        quotes: none;
    }

    blockquote:before, blockquote:after, q:before, q:after {
        content: '';
        content: none;
    }

    table {
        border-collapse: collapse;
        border-spacing: 0;
    }

    body {
        -webkit-text-size-adjust: none;
    }

/* Box Model */

    *, *:before, *:after {
        -moz-box-sizing: border-box;
        -webkit-box-sizing: border-box;
        box-sizing: border-box;
    }

/* Basic */

    @media screen and (max-width: 480px) {

        html, body {
            min-width: 320px;
        }

    }

    @keyframes fadeOnLoad {
        0% {
            opacity: 0;
        }
        100% {
        }
    }

    @keyframes twistFadeOnLoad {
        0% {
            opacity: 0;
            transform: rotateX(15deg);  
        }
        100% {
        }
    }
    
    @keyframes fadeFromWhiteOnLoad {
        0% {
            opacity: 1;
            background-color: #FFFFFF;
        }
        100% {
        }
    }

    html {
        height: 100%;
    }

    body {
        height: 100%;
        background-color: #ffffff;
        background-repeat: repeat,          no-repeat,          no-repeat;
        background-size: cover;
        background-position: top left,      center center,      bottom center;
        background-attachment: fixed,           fixed,              fixed;
    }

        body:after {
            content: '';
            display: block;
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: inherit;
            opacity: 1;
            z-index: -2;
            background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAMgAAADIAgMAAADQNkYNAAAADFBMVEWfu8x9lq5idJBIUWs5ew2TAAAABHRSTlMVFRUVlNGiUwAAC4RJREFUaN7t2WmMc1MYB/D/WdqeztzOnM7UXtx2imJwZ6YYDE6nRfGK2hJrUktCrLUvsZxZUBS1REgsfb2IxDbWkBCn06IY1BJLELVEfEDGEsQWtb+cji++zrfJ/NLb25zzPOd5zgPJ5W67E0S/zq04r3nRjzjDIY1DB9h81jsnkFVu1XZMTtUi4x/AqBdbXPO+Pkhj/OW4uw41qjBIn7UdKvGOUHB/0DwYgFMn9Ww03Mejg2uWL0hOS0JsR/SkNN1jam/v5HHn+L00MHDkipBclDuNDjEOKZTtIPPkmFA/9b6qNghodLNh/lASDygJeGtfO0k926FWGhYC0VHyXoIyEln5ItXXqj6AZTDlR9F2cOlBBXYcGNzwlNiTWH8GJ6/F9eJVzgZTL0uR5MR2CDewC198ugEEPO2SzSLewIwCKpikQGHLedtR3ouxck15BTWMxcOpC4p0bU1AegtihWdyXfyZL0vbe7SBEW8WtP9RqEoRC140la7Jdro2coztqHp9ZMc1EHo8T310bkV0QtaJOk7Xw8xQBs+xHc6lHi727Trry5mh9oVZti9IYFoL+K6e4i4XQduBfDgpjmcyd/F+VxrW/JBqrmgFuPxwLI7DSNuxbki1Dwz1GSXMMAGgRaH30nm99QZ8sBnYk3u2gyotgMouD2BibQDOdA4lHlDiIhFfRRSyXdwtYW52nQ8kVKBehJP0z/HKFOmRoSnGdcbJ2I4pP90aM/Fs9OwvoSgGa/V10JoNLd46HCMGONV2+Ik3onxi08wVrsOdz5CDareJ4+CY+TipDHPbcW7yMm/q0Ul8gct1SLnNqwIbnKslNF8sPq1SMWY7HNLYbb1Whm677zVUVTaBEw/8I25tBzCv+TdbO82e6MCRL5UCPSeo/XfwAiJ9cwwc525rO9RuQR1GAp4hTQny9WyxeDdKjgoGKwvyTSlsB4cUH6HhLBXNtoOjGfKDbqzi5Lk6ndndKbfG4/2Rh8jjaqD4FZG2461Xs9u6yVpzpdETalQASMvRcBu6oRVNN8K2Q4JghJdOH/8RE1d4SWSxKSBel/1MOwQ+Yjs0ZS5DJGHyA1/xd/SqQPxiii/QdAHCVXM321G8cy48obZujrixtZuAjO+pDn6ympoQ9RdnJIewHVenwRrM1QAPs9gGEE6OIxFNr39TahKkt4v/FkoDQ4OqsavuGmq2w8Ho368w0KrSZ6EAc8Q+QpiA8JEu/vCrrNerNyLV6zwSBgdzd9YSl37TgnbH662DbUd2b9nTw3Hr1mG3VBq6gUUI3O0C1EOd5QLteDevhMTuUOxQ90SpJ9RQgeXFaCL9zC0uh0smoiO2w/1iz7Rk/rePL/JVcy2nVUD8KOpG7/aSqUrzBTZtOwDAOCzpsIse03v9iC3FOFnFVO7PFGE7moB7xVFOnkN/FBWGOSF3Q10ify2f7TBV4oIwx8zWHV5qtEbC1R66HhoDsdc+XMSX47ZjHtoLYSzHCC7cP7a9y/I+A1LLRwbr60kgajvGBQlUT8vSHoI0d8DEh2JhI3mowtNp7rFVF9qOCPe8of7tHSURm7/V7DmpexMEYOSSrDuEqGs7xELst5Q4/SaZOBL+EJXldZ+JQsxetee0CjBpO+QaQ6i+khlK9YmZp7bASZLfOGGyBKOBeUGja6xrOyDuWzEv1zzdzax85VLjPOhMpPcIHomwhMIo+47YjqSJ/PGsK6fXkKEc+AY9cLHmHlxq6SZGbf/1NzWyX+ANt6Fnj3QBdckW5NifdWvxj99sO1S7lLjKZFF75O0oSX6aYqm1IW5AKbC50xNKjI7Zju9i+/z674l9W/4vsHt9gSvJ3HNdHavts5Ls6wnbYST+I4THuzgmvePcdc3AJOdJtQ13Bogz4ky7tLfAvyhj7ZSwHd8JDRd0egrJy7O5eFx8rJ6CEn1pU4ZnXiG245qiqzDzOWQiijEnEJLF7Lgsrjh45MdbheK+Lo6hA9VSm17iNnRxEFxYCHINYGGN8PMYO3k+x6XZIRIeWPxtz9uOyGaesZO9CzkXTEg2SG1H57Sm/vcFa9Bt0O00tx3akyBAs7/NEX/iIbiiz/t6zXtOM08h4t7eN247qhRLLDpe00i3bYcfgOsxPMfw/r2FwQvQO92HY0xrAEiEj9f9toNXprCytvHEd7p4x2u+zIMo/rNisR1p1gZzr0ackBaNTYs7TR5hVFz/jBcdRu+g7bjcS+VcvX4Ru+ElDFWY9IKb+SZqjfbI/dsA2N129I35lqqQgtU50cXRCb2UPp+6fInQtB2/Rge4M0YHHa/bAWg7HoWaQSPstOPVZ4DZFbMAG/1+tcrYduiGNr6gF+GP17qVGbaj833r9kLjQy/vrC17OyeKKgFaFnfRv72P7egkQGe9E+43A1fU1Vha45KK0KfMmb8SpO0wufIk/qtRsD3jZNjfu8Sue21Hg+CPszp0ipMTu44CXFzdWvO+T/5op2zv7PXj/siL3ROg7UD0tb/j3D77bMcz2IPME5WBM+dBCO2k0IMnFQ8mimF4JzzSxTtdhLN60rK6DMsxGAOnSq/rmOIchvfi/Xoq6JoRnhkXd44YxGxHClgjP/uJDqm1gIBP5fd2jlfAqYJiYGWGJG1Hp6tZ/X3srsd2U0n4G28CZOOUebmfsA/jnqcIZsnTX0tz+Wu32Q76LAp2Ifp3lWc7Ol1c6LcSSq3XIJv0e2EoZ2px+q8uz3ZAJvS/i0lj4MbhtZCkP3VxoaLZ/+oRbAdXctHLzIHVAT162kcreYyID4hpz6AY2BWe7ZDmmJCZKqR2IBjCHAcoYnrLzXvw2llyb3f94S4+67tp8p+nabSI+MAuWwYRddSQZzvg8WzEW/rVbMfa7qX6UbftL4eIC5pes4nFAoDRoEtduT7itiM7pnWpML2ZFwFXCUGqC4Fe0EZLfSfk1Q6TtkPudvSpS/QtAwTBQBePgB/spbhGkB/ispoG0ExoodVp+P3htouSv/ivs3HsIeISNqO555FVtiMDEvv34UiOqqYFoTQTLxPbUUA8A+gS6grV3q+hrt6NrF7j2w43rYGc69YVCgGc+Sy02SV5qq5uJFkHWsZ2OA6UoKy8o++uw7q18bb/Wtdk/qvusR2dP5ifU9Pvl3HA5dFw4R9dge34Eor8fkElGhWOref/VdDYjl87Re0gfw1Rey4MnkLL0UujYrVO0nZ0okLEICN0ryWixvbmKuSK+x+j9i/TncT+amsX8qwkNA5KykkoXbEdqPbO2/0Hnmd/rJ/t6HzsnxcCGwpXrPZY2xEb+Xa1y0NHvLvHiiBVN8IrrZ/gOPVl21G5wan92UFJqpiD6BSwYW63QI8RutHFIScQBk+Fn2tVBl/O4+2n4OY357V6zfEi/kedEdtB0hMJnXbY/enwVmixlPakOGBy8FZsjUOB6Bq2o5Or/nNVbMfGDKigjoCrEHglXJufo+4IEhtnvExBxUjUdoSEMv/ViNuOTj+Wj4na3ScblHaPPJpAcQTl1fo12yE/tS9efIcCs5Bu2Oc4XbxTxzIADJyZ4YDxCex9ZH5B/1Xn2o5OBkaEK/A1iqASSv8rA9uOMLwDf703XqrEsB2tTzmhacM8U3w5wDNTAf7Uqg2fc2eh8sFtqU/bju+a5cCSRXXGKNtR6zP/uj8F5AEGQhFKZN508c4aVb3wHtF2MphFG0h5QhYCvCeK8m+XKbbjcaYm5mJPFc3aNO0CGPNlTzHOO8WrCff6nuJZ28Fquh/CgRnVZvy46/l7hrZn9Lp/nQ+2o7Ndf72ZXjLJ2A5HBeEcJTPYfnw/3eU60naAif6l7gY8yC6O6jPoKftAZJDimDEyb3B/Su5EeeKP5sB20N2jgOPfSOoyijovDRt2QKnLQqB6qxaxfXn+sjx/WZ6/LM9flucvy/OX5fnL8vxlef6yPH9Znr8sz1+W5y/L85f/M3/5BZ+/aGtuVoTFAAAAAElFTkSuQmCC), linear-gradient(60deg, rgba(255, 165, 150, 0.5) 5%, rgba(0, 228, 255, 0.35));
            background-repeat: repeat, no-repeat;
            background-size: 100px 100px, cover;
            background-position: top left, center center;

            animation: 1.75s ease-out 0s 1 fadeFromWhiteOnLoad;
        }

/* Type */

    body, input, select, textarea {
        color: #414f57;
        font-family: ""Source Sans Pro"", Helvetica, sans-serif;
        font-size: 14pt;
        font-weight: 300;
        line-height: 2;
        letter-spacing: 0.2em;
        text-transform: uppercase;

        -moz-transition: font-size 0.3s ease;
        -webkit-transition: font-size 0.3s ease;
        -ms-transition: font-size 0.3s ease;
        transition: font-size 0.3s ease;
    }

        @media screen and (max-width: 1680px) {

            body, input, select, textarea {
                font-size: 11pt;
            }

        }

        @media screen and (max-width: 480px) {

            body, input, select, textarea {
                font-size: 10pt;
                line-height: 1.75;
            }

        }

    a {
        -moz-transition: color 0.2s ease, border-color 0.2s ease;
        -webkit-transition: color 0.2s ease, border-color 0.2s ease;
        -ms-transition: color 0.2s ease, border-color 0.2s ease;
        transition: color 0.2s ease, border-color 0.2s ease;
        color: #0065af;
        text-decoration: none;
    }

        a:before {
            -moz-transition: color 0.2s ease, text-shadow 0.2s ease;
            -webkit-transition: color 0.2s ease, text-shadow 0.2s ease;
            -ms-transition: color 0.2s ease, text-shadow 0.2s ease;
            transition: color 0.2s ease, text-shadow 0.2s ease;
        }

        a:hover {
            color: #ff7496;
        }

    strong, b {
        color: #313f47;
    }

    em, i {
        font-style: italic;
    }

    p {
        margin: 0 0 1.5em 0;
    }

    h1, h2, h3, h4, h5, h6 {
        color: #313f47;
        line-height: 1.5;
        margin: 0 0 0.75em 0;
    }

        h1 a, h2 a, h3 a, h4 a, h5 a, h6 a {
            color: inherit;
            text-decoration: none;
        }

    h1 {
        font-size: 1.85em;
        letter-spacing: 0.22em;
        margin: 0 0 0.525em 0;
    }

    h2 {
        font-size: 1em;
        line-height: inherit;
        margin: 0 0 1.5em 0;
    }

    h3 {
        font-size: 1em;
    }

    h4 {
        font-size: 1em;
    }

    h5 {
        font-size: 1em;
    }

    h6 {
        font-size: 1em;
    }

    @media screen and (max-width: 480px) {

        h1 {
            font-size: 1.65em;
        }

    }

    sub {
        font-size: 0.8em;
        position: relative;
        top: 0.5em;
    }

    sup {
        font-size: 0.8em;
        position: relative;
        top: -0.5em;
    }

    hr {
        border: 0;
        border-bottom: solid 1px #c8cccf;
        margin: 3em 0;
    }

/* Form */

    form {
        margin: 0 0 1.5em 0;
    }

        form > .field {
            margin: 0 0 1.5em 0;
        }

            form > .field > :last-child {
                margin-bottom: 0;
            }

    label {
        color: #313f47;
        display: block;
        font-size: 0.8em;
        margin: 0 0 0.75em 0;
    }

    input[type=""text""],
    input[type=""password""],
    input[type=""email""],
    input[type=""tel""],
    select,
    textarea {
        -moz-appearance: none;
        -webkit-appearance: none;
        -ms-appearance: none;
        appearance: none;
        border-radius: 4px;
        border: solid 1px #c8cccf;
        color: inherit;
        display: block;
        outline: 0;
        padding: 0 1em;
        text-decoration: none;
        width: 100%;
    }

        input[type=""text""]:invalid,
        input[type=""password""]:invalid,
        input[type=""email""]:invalid,
        input[type=""tel""]:invalid,
        select:invalid,
        textarea:invalid {
            box-shadow: none;
        }

        input[type=""text""]:focus,
        input[type=""password""]:focus,
        input[type=""email""]:focus,
        input[type=""tel""]:focus,
        select:focus,
        textarea:focus {
            border-color: #ff7496;
        }

    .select-wrapper {
        text-decoration: none;
        display: block;
        position: relative;
    }

        .select-wrapper:before {
            content: """";
            -moz-osx-font-smoothing: grayscale;
            -webkit-font-smoothing: antialiased;
            font-family: FontAwesome;
            font-style: normal;
            font-weight: normal;
            text-transform: none !important;
        }

        .select-wrapper:before {
            color: #c8cccf;
            display: block;
            height: 2.75em;
            line-height: 2.75em;
            pointer-events: none;
            position: absolute;
            right: 0;
            text-align: center;
            top: 0;
            width: 2.75em;
        }

        .select-wrapper select::-ms-expand {
            display: none;
        }

    input[type=""text""],
    input[type=""password""],
    input[type=""email""],
    select {
        height: 2.75em;
    }

    textarea {
        padding: 0.75em 1em;
    }

    input[type=""checkbox""],
    input[type=""radio""] {
        -moz-appearance: none;
        -webkit-appearance: none;
        -ms-appearance: none;
        appearance: none;
        display: block;
        float: left;
        margin-right: -2em;
        opacity: 0;
        width: 1em;
        z-index: -1;
    }

        input[type=""checkbox""] + label,
        input[type=""radio""] + label {
            text-decoration: none;
            color: #414f57;
            cursor: pointer;
            display: inline-block;
            font-size: 1em;
            font-weight: 300;
            padding-left: 2.4em;
            padding-right: 0.75em;
            position: relative;
        }

            input[type=""checkbox""] + label:before,
            input[type=""radio""] + label:before {
                -moz-osx-font-smoothing: grayscale;
                -webkit-font-smoothing: antialiased;
                font-family: FontAwesome;
                font-style: normal;
                font-weight: normal;
                text-transform: none !important;
            }

            input[type=""checkbox""] + label:before,
            input[type=""radio""] + label:before {
                border-radius: 4px;
                border: solid 1px #c8cccf;
                content: '';
                display: inline-block;
                height: 1.65em;
                left: 0;
                line-height: 1.58125em;
                position: absolute;
                text-align: center;
                top: 0.15em;
                width: 1.65em;
            }

        input[type=""checkbox""]:checked + label:before,
        input[type=""radio""]:checked + label:before {
            color: #ff7496;
            content: '\f00c';
        }

        input[type=""checkbox""]:focus + label:before,
        input[type=""radio""]:focus + label:before {
            border-color: #ff7496;
        }

    input[type=""checkbox""] + label:before {
        border-radius: 4px;
    }

    input[type=""radio""] + label:before {
        border-radius: 100%;
    }

    ::-webkit-input-placeholder {
        color: #616f77 !important;
        opacity: 1.0;
    }

    :-moz-placeholder {
        color: #616f77 !important;
        opacity: 1.0;
    }

    ::-moz-placeholder {
        color: #616f77 !important;
        opacity: 1.0;
    }

    :-ms-input-placeholder {
        color: #616f77 !important;
        opacity: 1.0;
    }

    .formerize-placeholder {
        color: #616f77 !important;
        opacity: 1.0;
    }

/* Icon */

    .icon {
        text-decoration: none;
        position: relative;
        border-bottom: none;
    }

        .icon:before {
            -moz-osx-font-smoothing: grayscale;
            -webkit-font-smoothing: antialiased;
            font-family: FontAwesome;
            font-style: normal;
            font-weight: normal;
            text-transform: none !important;
        }

        .icon > .label {
            display: none;
        }


/* List */

    ul.download {
        cursor: default;
        list-style: none;
        padding-left: 0;
        margin-top: -0.675em;
    }

        ul.download li {
            padding: 0.375em 0.5em;
            text-align: center;
            line-height: 1.5em;
        }


    ol {
        list-style: decimal;
        margin: 0 0 1.5em 0;
        padding-left: 1.25em;
    }

        ol li {
            padding-left: 0.25em;
        }

    ul {
        list-style: disc;
        margin: 0 0 1.5em 0;
        padding-left: 1em;
    }

        ul li {
            padding-left: 0.5em;
        }

        ul.alt {
            list-style: none;
            padding-left: 0;
        }

            ul.alt li {
                border-top: solid 1px #c8cccf;
                padding: 0.5em 0;
            }

                ul.alt li:first-child {
                    border-top: 0;
                    padding-top: 0;
                }

        ul.icons {
            cursor: default;
            list-style: none;
            padding-left: 0;
            margin-top: -0.5em;
            display: flex;
            flex-wrap: wrap;
            align-items: center;
            justify-content: center;
            text-align: center;
        }

            ul.icons li {
                display: inline-block;
                padding: 0.675em 0em;
                text-align: center;
                line-height: 1.5em;
                flex-grow: 1;
                flex-shrink: 0;
                flex-basis: 8.5em;
                align-self: center;
                max-width: 10em;
            }

            /* IE10 and IE11 have flexbox bugs */
            @media all and (-ms-high-contrast:none)
            {
                ul.icons {
                    display: block;
                }
    
                ul.icons li {
                    margin: 0.5em 0.5em 0 0.5em;
                }
            }

                ul.icons li a {
                    text-decoration: none;
                    position: relative;
                    display: inline-block;
                    width: 3.75em;
                    height: 3.75em;
                    border-radius: 100%;
                    border: solid 1px #c8cccf;
                    line-height: 3.75em;
                    overflow: hidden;
                    text-align: center;
                    text-indent: 3.75em;
                    white-space: nowrap;
                }

                    ul.icons li a:before {
                        -moz-osx-font-smoothing: grayscale;
                        -webkit-font-smoothing: antialiased;
                        font-family: FontAwesome;
                        font-style: normal;
                        font-weight: normal;
                        text-transform: none !important;
                    }

                    ul.icons li span {
                        font-size: 0.8em;
                        padding: 0;
                        margin: 0;
                    }

                    ul.icons li a:before {
                        color: #ffffff;
                        text-shadow: 1.25px 0px 0px #c8cccf, -1.25px 0px 0px #c8cccf, 0px 1.25px 0px #c8cccf, 0px -1.25px 0px #c8cccf;
                    }

                    ul.icons li a:hover:before {
                        text-shadow: 1.25px 0px 0px #ff7496, -1.25px 0px 0px #ff7496, 0px 1.25px 0px #ff7496, 0px -1.25px 0px #ff7496;
                    }

                    ul.icons li a:before {
                        position: absolute;
                        top: 0;
                        left: 0;
                        width: inherit;
                        height: inherit;
                        font-size: 1.85rem;
                        line-height: inherit;
                        text-align: center;
                        text-indent: 0;
                    }

                    ul.icons li a:hover {
                        border-color: #ff7496;
                    }

            @media screen and (max-width: 480px) {

                ul.icons li a:before {
                    font-size: 1.5rem;
                }

            }

        ul.actions {
            cursor: default;
            list-style: none;
            padding-left: 0;
        }

            ul.actions li {
                display: inline-block;
                padding: 0 0.75em 0 0;
                vertical-align: middle;
            }

                ul.actions li:last-child {
                    padding-right: 0;
                }

    dl {
        margin: 0 0 1.5em 0;
    }

        dl dt {
            display: block;
            margin: 0 0 0.75em 0;
        }

        dl dd {
            margin-left: 1.5em;
        }

/* Button */

    input[type=""submit""],
    input[type=""reset""],
    input[type=""button""],
    button,
    .button {
        -moz-appearance: none;
        -webkit-appearance: none;
        -ms-appearance: none;
        appearance: none;
        -moz-transition: background-color 0.2s ease-in-out, border-color 0.2s ease-in-out, color 0.2s ease-in-out;
        -webkit-transition: background-color 0.2s ease-in-out, border-color 0.2s ease-in-out, color 0.2s ease-in-out;
        -ms-transition: background-color 0.2s ease-in-out, border-color 0.2s ease-in-out, color 0.2s ease-in-out;
        transition: background-color 0.2s ease-in-out, border-color 0.2s ease-in-out, color 0.2s ease-in-out;
        display: inline-block;
        height: 2.75em;
        line-height: 2.75em;
        padding: 0 1.5em;
        background-color: transparent;
        border-radius: 4px;
        border: solid 1px #c8cccf;
        color: #414f57 !important;
        cursor: pointer;
        text-align: center;
        text-decoration: none;
        white-space: nowrap;
    }

        input[type=""submit""]:hover,
        input[type=""reset""]:hover,
        input[type=""button""]:hover,
        button:hover,
        .button:hover {
            border-color: #ff7496;
            color: #ff7496 !important;
        }

        input[type=""submit""].icon,
        input[type=""reset""].icon,
        input[type=""button""].icon,
        button.icon,
        .button.icon {
            padding-left: 1.35em;
        }

            input[type=""submit""].icon:before,
            input[type=""reset""].icon:before,
            input[type=""button""].icon:before,
            button.icon:before,
            .button.icon:before {
                margin-right: 0.5em;
            }

        input[type=""submit""].fit,
        input[type=""reset""].fit,
        input[type=""button""].fit,
        button.fit,
        .button.fit {
            display: block;
            width: 100%;
            margin: 0 0 0.75em 0;
        }

        input[type=""submit""].small,
        input[type=""reset""].small,
        input[type=""button""].small,
        button.small,
        .button.small {
            font-size: 0.8em;
        }

        input[type=""submit""].big,
        input[type=""reset""].big,
        input[type=""button""].big,
        button.big,
        .button.big {
            font-size: 1.35em;
        }

        input[type=""submit""].disabled, input[type=""submit""]:disabled,
        input[type=""reset""].disabled,
        input[type=""reset""]:disabled,
        input[type=""button""].disabled,
        input[type=""button""]:disabled,
        button.disabled,
        button:disabled,
        .button.disabled,
        .button:disabled {
            -moz-pointer-events: none;
            -webkit-pointer-events: none;
            -ms-pointer-events: none;
            pointer-events: none;
            opacity: 0.5;
        }

/* Card Flip */
    .tab {
        background-color: #FFFFFF;
        border-radius: 4px 4px 0px 0px;
        position: absolute;
        top: 0.5em;
        height: 2.5em;
        width: 45%;
        display: block;
        cursor: pointer;
        overflow: hidden;
        display: flex;
        align-items: center;
        justify-content: center;
        opacity: 0.95;
        z-index: 0;
    }

    .bar {
        background-color: #FFFFFF;
        /*background: -moz-linear-gradient(top,  rgba(255,255,255,1) 0%, rgba(255,255,255,0) 70%);
        background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(255,255,255,1)), color-stop(70%,rgba(255,255,255,0)));
        background: -webkit-linear-gradient(top,  rgba(255,255,255,1) 0%,rgba(255,255,255,0) 70%);
        background: -o-linear-gradient(top,  rgba(255,255,255,1) 0%,rgba(255,255,255,0) 70%);
        background: -ms-linear-gradient(top,  rgba(255,255,255,1) 0%,rgba(255,255,255,0) 70%);
        background: linear-gradient(to bottom,  rgba(255,255,255,1) 0%,rgba(255,255,255,0) 70%);*/
        border-radius: 4px 4px 0px 0px;
        position: relative;
        z-index: 0;
        display: block;
        opacity: 0.95;
        margin: 0;

        padding: 0.5em 0em 0em 0em;
    }

    @supports (-webkit-touch-callout: none) {
        /* Fix for iOS rendering */
        .bar {
            margin: 0 0 -1px 0;
        }
    }

    .tab div {
        font-size: 1.1em;
    }

    #booking:target .tab.left, #booking:not(:target) .tab.right {
        background-color: rgb(242, 242, 242);
        z-index: -1;
    }
    #booking:target .tab.left {
        -moz-box-shadow: inset -10px  -10px 10px -10px #666;
        -webkit-box-shadow: inset -10px  -10px 10px -10px #666;
        box-shadow: inset -10px -10px 10px -10px #666;
    }

    #booking:not(:target) .tab.right {
        -moz-box-shadow: inset 10px -10px 10px -10px #666;
        -webkit-box-shadow: inset 10px -10px 10px -10px #666;
        box-shadow: inset 10px -10px 10px -10px #666;
    }

    #booking:target .tab.right, #booking:not(:target) .tab.left {
        background-color: #FFFFFF;
        -moz-box-shadow: none;
        -webkit-box-shadow: none;
        box-shadow: none;
        color: #000;
        cursor: default;
    }

    .tab.left {
        left: 5%;
    }
    .tab.right {
        left: 50%;
    }
   
    @media screen and (max-width: 480px) {
        .tab {
           width: 40%;
        }

        .tab.left {
            left: 10%;
        }
    }

    @media screen and (max-width: 540px) {

        .tab .short {
            display: none;
        }

    }

    .baseurl {
        margin-bottom: 1.5em;
    }

    .baseurls {
        margin-bottom: 2.5em;
    }

    .code {
        font-family: 'Courier New', Courier, monospace;
        font-size: 0.8em;
        text-transform: none;
        letter-spacing: 0px;
    }

        
/* Main */

    .front {
        display: block;
    }
    .back {
        display: none;
    }

    #booking:target .front {
        display: none;
    }

    #booking:target .back {
        display: block;
    }

    /* Only enable animation on modern browsers */
    @supports (((backface-visibility: hidden) or (-webkit-backface-visibility: hidden)) and (transform-style: preserve-3d) and (display: grid)) {
        .flip {
            position: relative;
            display: grid;
            grid-template: 1fr / 1fr;
            align-items: start;
            justify-items: stretch;
        }
        .flip > * {
            grid-column: 1 / 1;
            grid-row: 1 / 1;
        }

        /* Multi-level perspective is buggy in firefox */
        @supports not (-moz-backface-visibility: hidden) {
            .outerscene {
                perspective: 1000px;
            }

            #wrapper {
                transform-style: preserve-3d;
                animation: 1s ease 0s 1 twistFadeOnLoad;
            }
        }

        @supports (-moz-backface-visibility: hidden) {
            #wrapper {
                animation: 0.5s ease 0s 1 fadeOnLoad;
            }
        }

        #anchor {
            display: block;
            width: 100%;
            height: 0.5em;
        }

        .content {
            z-index: 2;
        }

        .scene {
            perspective: 1000px;
            z-index: 3;
        }
    
        .flip {
            transform-style: preserve-3d;
            transition: transform 0.75s;
        }
        
        .front,
        .back {
            -webkit-backface-visibility: hidden;
            backface-visibility: hidden;
            
            top: 0;
            left: 0;

            display: block !important;
            position: relative;
        }

        .front {
            transform: rotateY(0deg);
        }

        .back {
            transform: rotateY(-180deg);
        }

        #booking:target .flip {
            transform: rotateY( 180deg ) ;
        }
    }

    .card {
        /* position: relative; */
        overflow: hidden;
        max-width: 45em;
        min-width: 27em;
        background: #ffffff;
        cursor: default;
        opacity: 0.95;
        text-align: center;
    }

    .front, .back {
        padding: 2em 3em 3em 3em;
        border-radius: 0px 0px 4px 4px;
    }

        .card .avatar {
            position: relative;
            display: block;
            margin-bottom: 1.5em;
        }

            .card .avatar img, .card .avatar .logo-sm {
                display: block;
                margin: 0 auto;
                box-shadow: 0 0 0 1.5em #ffffff;
                background-color: white;
            }

            .card .avatar:before {
                content: '';
                display: block;
                position: absolute;
                top: 50%;
                left: -3em;
                width: calc(100% + 6em);
                height: 1px;
                z-index: -1;
                background: #c8cccf;
            }

        @media screen and (max-width: 480px) {

            .card {
                min-width: 0;
                width: 100%;
                padding: 2.5em 2em 2.5em 2em ;
            }

                .card .avatar:before {
                    left: -2em;
                    width: calc(100% + 4em);
                }

        }

/* Footer */

    #footer {
        -moz-align-self: -moz-flex-end;
        -webkit-align-self: -webkit-flex-end;
        -ms-align-self: -ms-flex-end;
        align-self: flex-end;
        width: 100%;
        padding: 1.5em 0 0 0;
        color: rgba(255, 255, 255, 0.75);
        cursor: default;
        text-align: center;
    }

        #footer .copyright {
            margin: 0;
            padding: 0;
            font-size: 0.8em;
            list-style: none;
        }

            #footer .copyright li {
                display: inline-block;
                margin: 0 0 0 0.45em;
                padding: 0 0 0 0.85em;
                border-left: solid 1px rgba(255, 255, 255, 0.5);
                line-height: 1;
            }

                #footer .copyright li:first-child {
                    border-left: 0;
                }

/* Wrapper */

body {
    text-align: center;
}

    #wrapper {
        display: inline-block;
        align-items: center;
        position: relative;
        min-height: 100%;
        padding: 3em 1.5em 1.5em 1.5em;
        z-index: 2;
    }

        #wrapper > * {
            /*z-index: 1;*/
        }

        #wrapper:before {
            content: '';
            display: block;
        }

        @media screen and (max-width: 360px) {

            #wrapper {
                padding: 2.25 0.75em 0.75em 0.75em;
            }

        }

.metadata, .always-hidden {
    display: none;
}

.license, .description {
    font-size: 0.8em;
    max-width: 45em;
    display: inline-block;
}

.license {
    margin-bottom: 3em;
}

.warning {
    font-size: 0.9em;
    max-width: 45em;
    display: inline-block;
    color: red;
    margin: 0.3em 0;
    padding: 0 3em;
    font-weight: 600;
    letter-spacing: 0.1em;
}

.logo {
    max-width: 230px;
    max-height: 80px;
}

.badge {
    background-size: contain;
    background-repeat: no-repeat;
    background-position: center; 
    border-radius: initial !important;
    border: none !important;
    opacity: 0.5;
}

.badge:hover {
    opacity: 1;
}
</style>
</head>
<body id=""booking"" background=""{{backgroundImage.url}}"">
    <div class=""outerscene"">
        <div id=""anchor""></div>
        <!-- Wrapper -->
        <div id=""wrapper"" typeof=""dcat:Dataset"" resource=""{{url}}"">
            {{#accessService}}
                <a class=""tab left"" href=""#""><div>Open Data</div></a>
                <a class=""tab right"" href=""#booking""><div><span class=""short"">Open</span> Booking <span class=""short"">API</span></div></a>
            {{/accessService}}
            <div class=""content"">
                <div class=""bar"">
                    {{#disambiguatingDescription}}
                    <p class=""warning"">{{.}}</p>
                    {{/disambiguatingDescription}}
                </div>
                <div class=""scene"">
                    <div class=""flip"">
                        <!-- Front -->
                        <section id=""main"" class=""front card"">
                            
                            <header>                    
                                <div>
                                    <a href=""{{publisher.url}}"" about=""{{publisher.url}}"" property=""foaf:homepage"">
                                        <span class=""avatar"" property=""foaf:name"" content=""{{publisher.name}}""><img class=""logo"" src=""{{publisher.logo.url}}"" alt="""" /></span>
                                    </a>
                                </div>

                                <h1>Open Data</h1>

                                <h2 property=""dct:title"">{{name}}</h2>

                                <p class=""description"">{{description}}, published using <a href='https://www.openactive.io/'>OpenActive</a> <a href='https://openactive.io/realtime-paged-data-exchange/1.0/'>RPDE 1.0</a> and <a href='{{schemaVersion}}'>Model 2.0</a>.</p>
                                <p class=""metadata"" property=""dct:description"">{{description}}.</p>
                                <p class=""metadata"" property=""dct:created"" content='{{datePublished}}' datatype='xsd:dateTime'></p>
                                {{#keywords}}
                                <p class=""metadata"" property=""dcat:keyword"">{{.}}</p>
                                {{/keywords}}
                                <a class=""metadata"" href=""http://purl.org/linked-data/sdmx/2009/code#freq-N"" property=""dct:accrualPeriodicity"">Every minute</a>
                                <ul class=""icons"">
                                    <li><a href=""{{documentation}}"" class=""fa-info"">Documentation</a><br /><span>Documentation</span></li>
                                    <li><a href=""{{discussionUrl}}"" class=""fa-comments"">Discussion</a><br /><span>Discussion</span></li>
                                    {{#bookingService.hasCredential}}
                                    <li><a href=""{{.}}"" class=""fa-certificate"">Certificate</a><br /><span>Certificate</span></li>
                                    {{/bookingService.hasCredential}}
                                </ul> 
                            </header>

                            <ul class=""download"">
                                {{#distribution}}
                                <li>
                                    <a property='dcat:distribution' typeof='dcat:Distribution' href='{{contentUrl}}'>
                                        <i class=""fa fa-cloud-download""></i>
                                        <span property=""dct:title"">{{name}}</span>
                                        <span class=""metadata"" content='{{encodingFormat}}' property='dcat:mediaType'>OpenActive RPDE v1.0 Endpoints conforming to Modelling Specification 2.0.</span>
                                    </a>
                                </li>
                                {{/distribution}}
                            </ul>

                            <footer>
                                <div class=""license"">
                                    <span property=""dct:license"" resource=""{{license}}"">
                                        This data is owned by <a property=""dct:publisher"" href=""{{publisher.url}}"">{{publisher.legalName}}</a> and is licensed under the
                                        <a href=""{{license}}""><span property=""dct:title"">Creative Commons Attribution Licence (CC-BY v4.0)</span></a>
                                        for anyone to access, use and share;
                                    </span>
                                    <span property=""dct:rights"" resource=""#rights"" typeof=""odrs:RightsStatement"">
                                        <span class=""metadata"" property=""rdfs:label"">Rights Statement</span>
                                        <a class=""metadata"" href=""{{license}}"" property=""odrs:dataLicense"">Creative Commons Attribution Licence (CC-BY v4.0)</a>
                                        <a class=""metadata"" href=""{{license}}"" property=""odrs:contentLicense"">Creative Commons Attribution Licence (CC-BY v4.0)</a>
                                        using attribution
                                        ""<a href=""{{url}}"" property=""odrs:attributionURL""><span property=""odrs:attributionText"">{{publisher.name}}</span></a>"".
                                    </span>
                                </div>
                                <span class=""avatar""><a href=""https://www.openactive.io/""><div class=""logo-sm openactive-logo"" alt=""OpenActive""></div></a></span>
                            </footer>
                        </section>

                        <!-- Back -->
                        <section id=""access"" class=""back card"">
                            <header>
                                <div>
                                    <a href=""{{publisher.url}}"">
                                        <span class=""avatar""><img class=""logo"" src=""{{publisher.logo.url}}"" alt="""" /></span>
                                    </a>
                                </div>

                                <h1>Open Booking API</h1>

                                <h2>{{name}}</h2>

                                <p class=""description"">{{accessService.description}}, conforming to <a href='https://www.openactive.io/'>OpenActive</a> <a href='https://openactive.io/open-booking-api/EditorsDraft/1.0CR3/'>Open Booking 1.0 CR3</a>.</p>
                                <ul class=""icons"">
                                    <li><a href=""{{accessService.landingPage}}"" class=""fa-key"">Access</a><br /><span>Access</span></li>
                                    <li><a href=""{{accessService.documentation}}"" class=""fa-info"">Documentation</a><br /><span>Documentation</span></li>
                                    <li><a href=""{{discussionUrl}}"" class=""fa-comments"">Discussion</a><br /><span>Discussion</span></li>
                                    <li><a href=""{{bookingService.hasCredential}}"" class=""fa-certificate"">Certificate</a><br /><span>Certificate</span></li>
                                </ul> 
                            </header>
                            
                            <div class=""baseurls"">
                                <div class=""baseurl"">
                                    <label for=""txtEndpointUrl"">Base URI</label>
                                    <input id=""txtEndpointUrl"" type=""text"" class=""code"" value=""{{accessService.endpointUrl}}"" disabled>
                                </div>
                                
                                {{#accessService.authenticationAuthority}}
                                <div class=""baseurl"">
                                    <label for=""txtAuthenticationAuthority"">Authentication Authority</label>
                                    <input id=""txtAuthenticationAuthority"" type=""text"" class=""code"" value=""{{.}}"" disabled>
                                </div>
                                {{/accessService.authenticationAuthority}}
                            </div>

                            <footer>
                                {{#accessService.termsOfService}}
                                <div class=""license"">
                                    Use of this API is governed by specific <a href=""{{.}}"">Terms of Service</a>.
                                </div>
                                {{/accessService.termsOfService}}
                                <span class=""avatar""><a href=""https://www.openactive.io/""><div class=""logo-sm openactive-logo"" alt=""OpenActive""></div></a></span>
                            </footer>
                        </section>
                    </div>
                </div>
            </div>

            <!-- Footer -->
            <footer id=""footer"">
                <ul class=""copyright"">
                    <li>{{#bookingService.name}}Platform: {{/bookingService.name}}{{#bookingService.url}}<a href=""{{.}}"">{{/bookingService.url}}{{bookingService.name}}{{#bookingService.softwareVersion}} {{.}}{{/bookingService.softwareVersion}}{{#bookingService.url}}</a>{{/bookingService.url}}{{#bookingService.name}}. {{/bookingService.name}}Design: <a href=""http://html5up.net"">HTML5 UP</a>.</li>
                </ul>
            </footer>
        </div>
    </div>
</body>
</html>

";

        public const string CspCompatibleTemplateFileContent = @"
<!DOCTYPE HTML>
<!--
  OpenActive Dataset Site Template version 7, from https://unpkg.com/@openactive/dataset-site-template@7.0.0/dist/datasetsite-csp.mustache
  
  This HTML file must reference a self-hosted 'datasetsite.styles.v7.css' file, co-located with the rest
  of the static assets from the following archive:
  https://unpkg.com/@openactive/dataset-site-template@7.0.0/dist/datasetsite-csp.static.zip
-->
<!--
  Design: Identity by HTML5 UP
  html5up.net | @ajlkn
  Free for personal and commercial use under the CCA 3.0 license (html5up.net/license)

  DCAT Template: Nick Evans / imin
  imin.co | @nickevans / @_imin_
  For openactive.io
  Free for personal and commercial use under the CC-BY v4.0 license (https://creativecommons.org/licenses/by/4.0/)
-->
<html prefix=""dct: http://purl.org/dc/terms/
              rdf: http://www.w3.org/1999/02/22-rdf-syntax-ns#
              dcat: http://www.w3.org/ns/dcat#
              foaf: http://xmlns.com/foaf/0.1/
              og: http://ogp.me/ns#
              odrs: http://schema.theodi.org/odrs#""
      lang=""en"">
<head>
    <title>{{name}} - Open Data</title>

    <meta name=""title"" content=""{{name}}  - Open Data"" />
    <meta name=""identifier"" content=""{{url}}"" />
    <meta name=""Keywords"" content=""{{#keywords}}{{.}},{{/keywords}}Open Data"" />
    <meta name=""Description"" content=""{{description}}"" />
    <meta name=""language"" content=""English"" />

    <meta property=""og:title"" content=""{{name}} - Open Data"" />
    <meta property=""og:description"" content=""{{description}}"" />
    <meta property=""og:locale"" content=""en_GB"" />
    <meta property=""og:url"" content=""{{url}}"" />
    <meta property=""og:image"" content=""{{publisher.logo.url}}"" />

    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"" />
    
    <!-- JSON-LD conforming to Google Structured Data specification. -->
    <script type=""application/ld+json"">
{{{jsonld}}}
    </script>
    
    <!--
      This stylesheet href must reference a self-hosted 'datasetsite.styles.v7.css' file in
      the same directory as the other static assets sourced from the following archive:
      https://unpkg.com/@openactive/dataset-site-template@7.0.0/dist/datasetsite-csp.static.zip
    -->
    <link rel=""stylesheet"" href=""{{{staticAssetsPathUrl}}}/datasetsite.styles.v7.css"" crossorigin=""anonymous"">

</head>
<body id=""booking"" background=""{{backgroundImage.url}}"">
    <table class=""always-hidden"" bgcolor=""#FFFFFF"" width=""100%"" height=""500px""><tr><td align=""center"">
      <p></p>
      <p><large><strong>Error: Static Assets Not Found</strong><large></p>
      <p>This HTML page must reference self-hosted static assets located at the relative or absolute path configured by ""staticAssetsPathUrl"" in the mustache template source data.</p>
      <p>""staticAssetsPathUrl"" is currently set to ""{{staticAssetsPathUrl}}"", and this page has failed to access this file: <pre>{{staticAssetsPathUrl}}/datasetsite.styles.v7.css</pre></p>
      <p>Please ensure that the assets at this location exactly match those in
      <a href=""https://unpkg.com/@openactive/dataset-site-template@7.0.0/dist/datasetsite-csp.static.zip"">datasetsite-csp.static.zip version 7</a>.</p>
      <p></p>
      <p>See the <a href=""https://github.com/openactive/dataset-site-template"">""CSP compatible template"" documentation</a> for more information</p>
      <p></p>
    </td></tr></table>
  
    <div class=""outerscene"">
        <div id=""anchor""></div>
        <!-- Wrapper -->
        <div id=""wrapper"" typeof=""dcat:Dataset"" resource=""{{url}}"">
            {{#accessService}}
                <a class=""tab left"" href=""#""><div>Open Data</div></a>
                <a class=""tab right"" href=""#booking""><div><span class=""short"">Open</span> Booking <span class=""short"">API</span></div></a>
            {{/accessService}}
            <div class=""content"">
                <div class=""bar"">
                    {{#disambiguatingDescription}}
                    <p class=""warning"">{{.}}</p>
                    {{/disambiguatingDescription}}
                </div>
                <div class=""scene"">
                    <div class=""flip"">
                        <!-- Front -->
                        <section id=""main"" class=""front card"">
                            
                            <header>                    
                                <div>
                                    <a href=""{{publisher.url}}"" about=""{{publisher.url}}"" property=""foaf:homepage"">
                                        <span class=""avatar"" property=""foaf:name"" content=""{{publisher.name}}""><img class=""logo"" src=""{{publisher.logo.url}}"" alt="""" /></span>
                                    </a>
                                </div>

                                <h1>Open Data</h1>

                                <h2 property=""dct:title"">{{name}}</h2>

                                <p class=""description"">{{description}}, published using <a href='https://www.openactive.io/'>OpenActive</a> <a href='https://openactive.io/realtime-paged-data-exchange/1.0/'>RPDE 1.0</a> and <a href='{{schemaVersion}}'>Model 2.0</a>.</p>
                                <p class=""metadata"" property=""dct:description"">{{description}}.</p>
                                <p class=""metadata"" property=""dct:created"" content='{{datePublished}}' datatype='xsd:dateTime'></p>
                                {{#keywords}}
                                <p class=""metadata"" property=""dcat:keyword"">{{.}}</p>
                                {{/keywords}}
                                <a class=""metadata"" href=""http://purl.org/linked-data/sdmx/2009/code#freq-N"" property=""dct:accrualPeriodicity"">Every minute</a>
                                <ul class=""icons"">
                                    <li><a href=""{{documentation}}"" class=""fa-info"">Documentation</a><br /><span>Documentation</span></li>
                                    <li><a href=""{{discussionUrl}}"" class=""fa-comments"">Discussion</a><br /><span>Discussion</span></li>
                                    {{#bookingService.hasCredential}}
                                    <li><a href=""{{.}}"" class=""fa-certificate"">Certificate</a><br /><span>Certificate</span></li>
                                    {{/bookingService.hasCredential}}
                                </ul> 
                            </header>

                            <ul class=""download"">
                                {{#distribution}}
                                <li>
                                    <a property='dcat:distribution' typeof='dcat:Distribution' href='{{contentUrl}}'>
                                        <i class=""fa fa-cloud-download""></i>
                                        <span property=""dct:title"">{{name}}</span>
                                        <span class=""metadata"" content='{{encodingFormat}}' property='dcat:mediaType'>OpenActive RPDE v1.0 Endpoints conforming to Modelling Specification 2.0.</span>
                                    </a>
                                </li>
                                {{/distribution}}
                            </ul>

                            <footer>
                                <div class=""license"">
                                    <span property=""dct:license"" resource=""{{license}}"">
                                        This data is owned by <a property=""dct:publisher"" href=""{{publisher.url}}"">{{publisher.legalName}}</a> and is licensed under the
                                        <a href=""{{license}}""><span property=""dct:title"">Creative Commons Attribution Licence (CC-BY v4.0)</span></a>
                                        for anyone to access, use and share;
                                    </span>
                                    <span property=""dct:rights"" resource=""#rights"" typeof=""odrs:RightsStatement"">
                                        <span class=""metadata"" property=""rdfs:label"">Rights Statement</span>
                                        <a class=""metadata"" href=""{{license}}"" property=""odrs:dataLicense"">Creative Commons Attribution Licence (CC-BY v4.0)</a>
                                        <a class=""metadata"" href=""{{license}}"" property=""odrs:contentLicense"">Creative Commons Attribution Licence (CC-BY v4.0)</a>
                                        using attribution
                                        ""<a href=""{{url}}"" property=""odrs:attributionURL""><span property=""odrs:attributionText"">{{publisher.name}}</span></a>"".
                                    </span>
                                </div>
                                <span class=""avatar""><a href=""https://www.openactive.io/""><div class=""logo-sm openactive-logo"" alt=""OpenActive""></div></a></span>
                            </footer>
                        </section>

                        <!-- Back -->
                        <section id=""access"" class=""back card"">
                            <header>
                                <div>
                                    <a href=""{{publisher.url}}"">
                                        <span class=""avatar""><img class=""logo"" src=""{{publisher.logo.url}}"" alt="""" /></span>
                                    </a>
                                </div>

                                <h1>Open Booking API</h1>

                                <h2>{{name}}</h2>

                                <p class=""description"">{{accessService.description}}, conforming to <a href='https://www.openactive.io/'>OpenActive</a> <a href='https://openactive.io/open-booking-api/EditorsDraft/1.0CR3/'>Open Booking 1.0 CR3</a>.</p>
                                <ul class=""icons"">
                                    <li><a href=""{{accessService.landingPage}}"" class=""fa-key"">Access</a><br /><span>Access</span></li>
                                    <li><a href=""{{accessService.documentation}}"" class=""fa-info"">Documentation</a><br /><span>Documentation</span></li>
                                    <li><a href=""{{discussionUrl}}"" class=""fa-comments"">Discussion</a><br /><span>Discussion</span></li>
                                    <li><a href=""{{bookingService.hasCredential}}"" class=""fa-certificate"">Certificate</a><br /><span>Certificate</span></li>
                                </ul> 
                            </header>
                            
                            <div class=""baseurls"">
                                <div class=""baseurl"">
                                    <label for=""txtEndpointUrl"">Base URI</label>
                                    <input id=""txtEndpointUrl"" type=""text"" class=""code"" value=""{{accessService.endpointUrl}}"" disabled>
                                </div>
                                
                                {{#accessService.authenticationAuthority}}
                                <div class=""baseurl"">
                                    <label for=""txtAuthenticationAuthority"">Authentication Authority</label>
                                    <input id=""txtAuthenticationAuthority"" type=""text"" class=""code"" value=""{{.}}"" disabled>
                                </div>
                                {{/accessService.authenticationAuthority}}
                            </div>

                            <footer>
                                {{#accessService.termsOfService}}
                                <div class=""license"">
                                    Use of this API is governed by specific <a href=""{{.}}"">Terms of Service</a>.
                                </div>
                                {{/accessService.termsOfService}}
                                <span class=""avatar""><a href=""https://www.openactive.io/""><div class=""logo-sm openactive-logo"" alt=""OpenActive""></div></a></span>
                            </footer>
                        </section>
                    </div>
                </div>
            </div>

            <!-- Footer -->
            <footer id=""footer"">
                <ul class=""copyright"">
                    <li>{{#bookingService.name}}Platform: {{/bookingService.name}}{{#bookingService.url}}<a href=""{{.}}"">{{/bookingService.url}}{{bookingService.name}}{{#bookingService.softwareVersion}} {{.}}{{/bookingService.softwareVersion}}{{#bookingService.url}}</a>{{/bookingService.url}}{{#bookingService.name}}. {{/bookingService.name}}Design: <a href=""http://html5up.net"">HTML5 UP</a>.</li>
                </ul>
            </footer>
        </div>
    </div>
</body>
</html>

";
    }
}
