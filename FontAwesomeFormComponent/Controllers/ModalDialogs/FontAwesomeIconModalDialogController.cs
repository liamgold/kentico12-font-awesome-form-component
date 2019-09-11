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

                    // Convert to a .NET model.
                    var iconModel = icon.Value.ToObject<FontAwesomeIcon>();

                    // Iterate over the free styles available for icon.
                    foreach (var style in iconModel.Styles)
                    {
                        var faIcon = new FontAwesomeIconSelectorListItem(iconModel.Label, icon.Name, style);
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
    }
}
