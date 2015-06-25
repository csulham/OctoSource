using Sitecore.Mvc.Helpers;
using System;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Base.Helpers
{
    public static class SiteHelper
    {

        public static IDisposable PageMetaDataEditFrame(this HtmlHelper html, string dataSource = null, string buttons = null)
        {
            return html.EditFrame(dataSource, "/sitecore/content/Applications/WebEdit/Edit Frame Buttons/Page Meta Data");
        }
        public static IDisposable MenuEditFrame(this HtmlHelper html, string dataSource = null, string buttons = null)
        {
            return html.EditFrame(dataSource, "/sitecore/content/Applications/WebEdit/Edit Frame Buttons/Menu");
        }
        public static HtmlString GetSiteLogo(this SitecoreHelper html)
        {
            return html.Field("Site Logo",
                            ScHelper.GetCurrentSiteFolder(),
                            new { Parameters = new Collections.SafeDictionary<string> { { "CssClass", "logo" } } });
        }
        public static string GetTitle()
        {
            return Context.Item.Fields["Page Title"].Value;
        }
                public static string GetMetaDescription()
        {
            return Context.Item.Fields["Meta Description"].Value;
        }
        public static HtmlString GetSiteCopyright(this SitecoreHelper html)
        {
            return html.Field("Copyright",
                            ScHelper.GetCurrentSiteFolder());
        }

        public static HtmlString GetNavigationTitle(this SitecoreHelper html, string itemId)
        {
            return html.Field("Navigation Title", ScHelper.GetItem(itemId));

        }

    }
}
