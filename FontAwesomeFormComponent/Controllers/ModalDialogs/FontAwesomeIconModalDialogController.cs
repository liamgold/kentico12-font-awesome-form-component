using CMS.EventLog;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace NetC.FontAwesomeFormComponent.Kentico.MVC
{
    public class FontAwesomeIconModalDialogController : Controller
    {
        private IEnumerable<FontAwesomeIconSelectorListItem> _icons;

        public ActionResult Index()
        {
            var model = new FontAwesomeIconModalDialogViewModel
            {
                Icons = GetIcons(),
            };

            return View("ModalDialogs/FontAwesomeIconModalDialog/_FontAwesomeIconModalDialog", model);
        }

        private IEnumerable<FontAwesomeIconSelectorListItem> GetIcons()
        {
            if (_icons == null)
            {
                var iconList = new List<FontAwesomeIconSelectorListItem>();

                // Download json directly from FontAwesome's GitHub repository.
                var json = DownloadFontAwesomeIconJson();
                var data = JObject.Parse(json);

                // Check we have valid data, and there are actual icons returned.
                if (data == null || !data.HasValues)
                {
                    return iconList;
                }

                foreach (JProperty icon in data.Children())
                {
                    // Check we have valid data, and the icon has child properties.
                    if (icon == null || !icon.HasValues)
                    {
                        continue;
                    }

                    var properties = icon.Children();

                    // Retrieve icon label and available styles for the icon.
                    var iconLabel = GetLabelName(properties.Values("label"));
                    var iconStyles = GetIconStyles(properties.Values("free"));

                    // Iterate over the free styles available for icon.
                    foreach (var style in iconStyles)
                    {
                        var faIcon = new FontAwesomeIconSelectorListItem(iconLabel, icon.Name, style);
                        iconList.Add(faIcon);
                    }
                }
                _icons = iconList;
            }

            return _icons;
        }

        private string DownloadFontAwesomeIconJson()
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    return webClient.DownloadString("https://raw.githubusercontent.com/FortAwesome/Font-Awesome/master/metadata/icons.json");
                }
                catch (Exception ex)
                {
                    EventLogProvider.LogException("FontAwesomeIconSelectorComponent", "Icons", ex);
                }
            }

            return string.Empty;
        }

        private string[] GetIconStyles(IJEnumerable<JToken> styleList)
        {
            foreach (JArray jArray in styleList)
            {
                return jArray.ToObject<string[]>();
            }

            return new string[0];
        }

        private string GetLabelName(IJEnumerable<JToken> tokenList)
        {
            foreach (JValue jValue in tokenList)
            {
                return jValue.ToString();
            }

            return string.Empty;
        }
    }
}