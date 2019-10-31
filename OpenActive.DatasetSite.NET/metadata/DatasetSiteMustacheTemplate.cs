
namespace OpenActive.DatasetSite.NET
{
    public static class DatasetSiteMustacheTemplate
    {
        public const string Content = @"
<!DOCTYPE HTML>
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
              foaf: http://xmlns.com/foaf/0.1/""
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
    <link href=""https://fonts.googleapis.com/css?family=Source+Sans+Pro:300"" rel=""stylesheet"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.6.3/css/font-awesome.min.css"" crossorigin=""anonymous"">
    <style>
        /*
            Identity by HTML5 UP
            html5up.net | @ajlkn
            Free for personal and commercial use under the CCA 3.0 license (html5up.net/license)
        */

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

            body.is-loading *, body.is-loading *:before, body.is-loading *:after {
                -moz-animation: none !important;
                -webkit-animation: none !important;
                -ms-animation: none !important;
                animation: none !important;
                -moz-transition: none !important;
                -webkit-transition: none !important;
                -ms-transition: none !important;
                transition: none !important;
            }

            html {
                height: 100%;
            }

            body {
                height: 100%;
                background-color: #ffffff;
                background-repeat: repeat,          no-repeat,          no-repeat;
                background-size: 100px 100px, cover,                cover;
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
                    opacity: 0;
                    z-index: 1;
                    background-color: #ffffff;
                    background-image: url(data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAMgAAADIAgMAAADQNkYNAAAADFBMVEWfu8x9lq5idJBIUWs5ew2TAAAABHRSTlMVFRUVlNGiUwAAC4RJREFUaN7t2WmMc1MYB/D/WdqeztzOnM7UXtx2imJwZ6YYDE6nRfGK2hJrUktCrLUvsZxZUBS1REgsfb2IxDbWkBCn06IY1BJLELVEfEDGEsQWtb+cji++zrfJ/NLb25zzPOd5zgPJ5W67E0S/zq04r3nRjzjDIY1DB9h81jsnkFVu1XZMTtUi4x/AqBdbXPO+Pkhj/OW4uw41qjBIn7UdKvGOUHB/0DwYgFMn9Ww03Mejg2uWL0hOS0JsR/SkNN1jam/v5HHn+L00MHDkipBclDuNDjEOKZTtIPPkmFA/9b6qNghodLNh/lASDygJeGtfO0k926FWGhYC0VHyXoIyEln5ItXXqj6AZTDlR9F2cOlBBXYcGNzwlNiTWH8GJ6/F9eJVzgZTL0uR5MR2CDewC198ugEEPO2SzSLewIwCKpikQGHLedtR3ouxck15BTWMxcOpC4p0bU1AegtihWdyXfyZL0vbe7SBEW8WtP9RqEoRC140la7Jdro2coztqHp9ZMc1EHo8T310bkV0QtaJOk7Xw8xQBs+xHc6lHi727Trry5mh9oVZti9IYFoL+K6e4i4XQduBfDgpjmcyd/F+VxrW/JBqrmgFuPxwLI7DSNuxbki1Dwz1GSXMMAGgRaH30nm99QZ8sBnYk3u2gyotgMouD2BibQDOdA4lHlDiIhFfRRSyXdwtYW52nQ8kVKBehJP0z/HKFOmRoSnGdcbJ2I4pP90aM/Fs9OwvoSgGa/V10JoNLd46HCMGONV2+Ik3onxi08wVrsOdz5CDareJ4+CY+TipDHPbcW7yMm/q0Ul8gct1SLnNqwIbnKslNF8sPq1SMWY7HNLYbb1Whm677zVUVTaBEw/8I25tBzCv+TdbO82e6MCRL5UCPSeo/XfwAiJ9cwwc525rO9RuQR1GAp4hTQny9WyxeDdKjgoGKwvyTSlsB4cUH6HhLBXNtoOjGfKDbqzi5Lk6ndndKbfG4/2Rh8jjaqD4FZG2461Xs9u6yVpzpdETalQASMvRcBu6oRVNN8K2Q4JghJdOH/8RE1d4SWSxKSBel/1MOwQ+Yjs0ZS5DJGHyA1/xd/SqQPxiii/QdAHCVXM321G8cy48obZujrixtZuAjO+pDn6ympoQ9RdnJIewHVenwRrM1QAPs9gGEE6OIxFNr39TahKkt4v/FkoDQ4OqsavuGmq2w8Ho368w0KrSZ6EAc8Q+QpiA8JEu/vCrrNerNyLV6zwSBgdzd9YSl37TgnbH662DbUd2b9nTw3Hr1mG3VBq6gUUI3O0C1EOd5QLteDevhMTuUOxQ90SpJ9RQgeXFaCL9zC0uh0smoiO2w/1iz7Rk/rePL/JVcy2nVUD8KOpG7/aSqUrzBTZtOwDAOCzpsIse03v9iC3FOFnFVO7PFGE7moB7xVFOnkN/FBWGOSF3Q10ify2f7TBV4oIwx8zWHV5qtEbC1R66HhoDsdc+XMSX47ZjHtoLYSzHCC7cP7a9y/I+A1LLRwbr60kgajvGBQlUT8vSHoI0d8DEh2JhI3mowtNp7rFVF9qOCPe8of7tHSURm7/V7DmpexMEYOSSrDuEqGs7xELst5Q4/SaZOBL+EJXldZ+JQsxetee0CjBpO+QaQ6i+khlK9YmZp7bASZLfOGGyBKOBeUGja6xrOyDuWzEv1zzdzax85VLjPOhMpPcIHomwhMIo+47YjqSJ/PGsK6fXkKEc+AY9cLHmHlxq6SZGbf/1NzWyX+ANt6Fnj3QBdckW5NifdWvxj99sO1S7lLjKZFF75O0oSX6aYqm1IW5AKbC50xNKjI7Zju9i+/z674l9W/4vsHt9gSvJ3HNdHavts5Ls6wnbYST+I4THuzgmvePcdc3AJOdJtQ13Bogz4ky7tLfAvyhj7ZSwHd8JDRd0egrJy7O5eFx8rJ6CEn1pU4ZnXiG245qiqzDzOWQiijEnEJLF7Lgsrjh45MdbheK+Lo6hA9VSm17iNnRxEFxYCHINYGGN8PMYO3k+x6XZIRIeWPxtz9uOyGaesZO9CzkXTEg2SG1H57Sm/vcFa9Bt0O00tx3akyBAs7/NEX/iIbiiz/t6zXtOM08h4t7eN247qhRLLDpe00i3bYcfgOsxPMfw/r2FwQvQO92HY0xrAEiEj9f9toNXprCytvHEd7p4x2u+zIMo/rNisR1p1gZzr0ackBaNTYs7TR5hVFz/jBcdRu+g7bjcS+VcvX4Ru+ElDFWY9IKb+SZqjfbI/dsA2N129I35lqqQgtU50cXRCb2UPp+6fInQtB2/Rge4M0YHHa/bAWg7HoWaQSPstOPVZ4DZFbMAG/1+tcrYduiGNr6gF+GP17qVGbaj833r9kLjQy/vrC17OyeKKgFaFnfRv72P7egkQGe9E+43A1fU1Vha45KK0KfMmb8SpO0wufIk/qtRsD3jZNjfu8Sue21Hg+CPszp0ipMTu44CXFzdWvO+T/5op2zv7PXj/siL3ROg7UD0tb/j3D77bMcz2IPME5WBM+dBCO2k0IMnFQ8mimF4JzzSxTtdhLN60rK6DMsxGAOnSq/rmOIchvfi/Xoq6JoRnhkXd44YxGxHClgjP/uJDqm1gIBP5fd2jlfAqYJiYGWGJG1Hp6tZ/X3srsd2U0n4G28CZOOUebmfsA/jnqcIZsnTX0tz+Wu32Q76LAp2Ifp3lWc7Ol1c6LcSSq3XIJv0e2EoZ2px+q8uz3ZAJvS/i0lj4MbhtZCkP3VxoaLZ/+oRbAdXctHLzIHVAT162kcreYyID4hpz6AY2BWe7ZDmmJCZKqR2IBjCHAcoYnrLzXvw2llyb3f94S4+67tp8p+nabSI+MAuWwYRddSQZzvg8WzEW/rVbMfa7qX6UbftL4eIC5pes4nFAoDRoEtduT7itiM7pnWpML2ZFwFXCUGqC4Fe0EZLfSfk1Q6TtkPudvSpS/QtAwTBQBePgB/spbhGkB/ispoG0ExoodVp+P3htouSv/ivs3HsIeISNqO555FVtiMDEvv34UiOqqYFoTQTLxPbUUA8A+gS6grV3q+hrt6NrF7j2w43rYGc69YVCgGc+Sy02SV5qq5uJFkHWsZ2OA6UoKy8o++uw7q18bb/Wtdk/qvusR2dP5ifU9Pvl3HA5dFw4R9dge34Eor8fkElGhWOref/VdDYjl87Re0gfw1Rey4MnkLL0UujYrVO0nZ0okLEICN0ryWixvbmKuSK+x+j9i/TncT+amsX8qwkNA5KykkoXbEdqPbO2/0Hnmd/rJ/t6HzsnxcCGwpXrPZY2xEb+Xa1y0NHvLvHiiBVN8IrrZ/gOPVl21G5wan92UFJqpiD6BSwYW63QI8RutHFIScQBk+Fn2tVBl/O4+2n4OY357V6zfEi/kedEdtB0hMJnXbY/enwVmixlPakOGBy8FZsjUOB6Bq2o5Or/nNVbMfGDKigjoCrEHglXJufo+4IEhtnvExBxUjUdoSEMv/ViNuOTj+Wj4na3ScblHaPPJpAcQTl1fo12yE/tS9efIcCs5Bu2Oc4XbxTxzIADJyZ4YDxCex9ZH5B/1Xn2o5OBkaEK/A1iqASSv8rA9uOMLwDf703XqrEsB2tTzmhacM8U3w5wDNTAf7Uqg2fc2eh8sFtqU/bju+a5cCSRXXGKNtR6zP/uj8F5AEGQhFKZN508c4aVb3wHtF2MphFG0h5QhYCvCeK8m+XKbbjcaYm5mJPFc3aNO0CGPNlTzHOO8WrCff6nuJZ28Fquh/CgRnVZvy46/l7hrZn9Lp/nQ+2o7Ndf72ZXjLJ2A5HBeEcJTPYfnw/3eU60naAif6l7gY8yC6O6jPoKftAZJDimDEyb3B/Su5EeeKP5sB20N2jgOPfSOoyijovDRt2QKnLQqB6qxaxfXn+sjx/WZ6/LM9flucvy/OX5fnL8vxlef6yPH9Znr8sz1+W5y/L85f/M3/5BZ+/aGtuVoTFAAAAAElFTkSuQmCC), linear-gradient(60deg, rgba(255, 165, 150, 0.5) 5%, rgba(0, 228, 255, 0.35));
                    background-repeat: repeat, no-repeat;
                    background-size: 100px 100px, cover;
                    background-position: top left, center center;
                    -moz-transition: opacity 1.75s ease-out;
                    -webkit-transition: opacity 1.75s ease-out;
                    -ms-transition: opacity 1.75s ease-out;
                    transition: opacity 1.75s ease-out;
                }

                body.is-loading:after {
                    opacity: 1;
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
                color: #0082f3;
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
                font-size: 0.9em;
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
                    margin-top: -1.5em;
                }

                    ul.icons li {
                        display: inline-block;
                        padding: 0.675em 0.5em;
                        text-align: center;
                        line-height: 1.5em;
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
                                font-size: 0.7em;
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

        /* Main */

            #main {
                position: relative;
                max-width: 100%;
                min-width: 27em;
                padding: 4.5em 3em 3em 3em ;
                background: #ffffff;
                border-radius: 4px;
                cursor: default;
                opacity: 0.95;
                text-align: center;
                -moz-transform-origin: 50% 50%;
                -webkit-transform-origin: 50% 50%;
                -ms-transform-origin: 50% 50%;
                transform-origin: 50% 50%;
                -moz-transform: rotateX(0deg);
                -webkit-transform: rotateX(0deg);
                -ms-transform: rotateX(0deg);
                transform: rotateX(0deg);
                -moz-transition: opacity 1s ease, -moz-transform 1s ease;
                -webkit-transition: opacity 1s ease, -webkit-transform 1s ease;
                -ms-transition: opacity 1s ease, -ms-transform 1s ease;
                transition: opacity 1s ease, transform 1s ease;
            }

                #main .avatar {
                    position: relative;
                    display: block;
                    margin-bottom: 1.5em;
                }

                    #main .avatar img {
                        display: block;
                        margin: 0 auto;
                        box-shadow: 0 0 0 1.5em #ffffff;
                        background-color: white;
                    }

                    #main .avatar:before {
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

                    #main {
                        min-width: 0;
                        width: 100%;
                        padding: 4em 2em 2.5em 2em ;
                    }

                        #main .avatar:before {
                            left: -2em;
                            width: calc(100% + 4em);
                        }

                }

                body.is-loading #main {
                    opacity: 0;
                    -moz-transform: rotateX(15deg);
                    -webkit-transform: rotateX(15deg);
                    -ms-transform: rotateX(15deg);
                    transform: rotateX(15deg);
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
                    font-size: 0.7em;
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
                perspective: 1000px;
                position: relative;
                min-height: 100%;
                padding: 1.5em;
                z-index: 2;
            }

                #wrapper > * {
                    z-index: 1;
                }

                #wrapper:before {
                    content: '';
                    display: block;
                }

                @media screen and (max-width: 360px) {

                    #wrapper {
                        padding: 0.75em;
                    }

                }

                body.is-ie #wrapper {
                    height: 100%;
                }



        .metadata {
            display: none;
        }

        .license, .description {
            font-size: 0.8em;
            max-width: 400px;
            display: inline-block;
        }

        .warning {
            font-size: 0.8em;
            max-width: 400px;
            display: inline-block;
            font-weight: bolder;
            color: red;
            margin-top: -50px;
            font-family: sans-serif;
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
    <style>
        body {
            background-image: url(data:image/png;base64,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), linear-gradient(60deg, rgba(255, 165, 150, 0.5) 5%, rgba(0, 228, 255, 0.35)), url(""{{{backgroundImage.url}}}"");
        }
    </style>

    <!-- JSON-LD conforming to Google Structured Data specification. -->
    <script type=""application/ld+json"">
{{{json}}}
    </script>
</head>
<body class=""is-loading"">

    <!-- Wrapper -->
    <div id=""wrapper"" typeof=""dcat:Dataset"" resource=""{{url}}"">

        <!-- Main -->
        <section id=""main"">
            <header>
                <div>
                    <a href=""{{publisher.url}}"" about=""{{publisher.url}}"" property=""foaf:homepage"">
                        <span class=""avatar"" property=""foaf:name"" content=""{{publisher.name}}""><img class=""logo"" src=""{{publisher.logo.url}}"" alt="""" /></span>
                    </a>
                </div>

                <h1>Open Data</h1>

                <h2 property=""dct:title"">{{name}}</h2>

                <p class=""description"">{{description}}, published using <a href='https://www.openactive.io/'>OpenActive</a> <a href='https://www.openactive.io/realtime-paged-data-exchange/1.0/'>RPDE 1.0</a> and <a href='{{schemaVersion}}'>Model 2.0</a>.</p>
                <p class=""metadata"" property=""dct:description"">{{description}}.</p>
                <p class=""metadata"" property=""dct:created"" content='{{datePublished}}' datatype='xsd:dateTime'></p>
                {{#keywords}}
                <p class=""metadata"" property=""dcat:keyword"">{{.}}</p>
                {{/keywords}}
                <a class=""metadata"" href=""http://purl.org/linked-data/sdmx/2009/code#freq-N"" property=""dct:accrualPeriodicity"">Every minute</a>
                <ul class=""icons"">
                    <li><a href=""{{documentation}}"" class=""fa-info"">Documentation</a><br /><span>Documentation</span></li>
                    <li><a href=""{{discussionUrl}}"" class=""fa-comments"">Discussion</a><br /><span>Discussion</span></li>
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
                <p></p>
                <span class=""avatar""><a href=""https://www.openactive.io/""><img src=""https://www.openactive.io/assets/openactive-logo-small.png"" width=""100"" alt=""OpenActive"" /></a></span>
            </footer>
        </section>

        <!-- Footer -->
        <footer id=""footer"">
            <ul class=""copyright"">
                <li>{{#bookingService}}Platform: <a href=""{{url}}"">{{name}} {{softwareVersion}}</a>. {{/bookingService}}Design: <a href=""http://html5up.net"">HTML5 UP</a>.</li>
            </ul>
        </footer>

    </div>

    <!-- Scripts -->
    <script>if ('addEventListener' in window) { window.addEventListener('load', function () { document.body.className = document.body.className.replace(/\bis-loading\b/, ''); }); document.body.className += (navigator.userAgent.match(/(MSIE|rv:11\.0)/) ? ' is-ie' : ''); }</script>
</body>
</html>

";
    }
}
