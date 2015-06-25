using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Helpers;

namespace Sitecore.Base.Helpers
{
    public static class ScHelper
    {
        public static Item GetItem(string itemId)
        {
            return Context.Database.GetItem(new ID(itemId));
        }

        public static string GetItemUrl(this SitecoreHelper html, string itemId)
        {
            Item link = Context.Database.GetItem(new ID(itemId));
            return LinkManager.GetItemUrl(link);

        }

        public static Item GetCurrentSiteFolder()
        {
            return Context.Database.GetItem(Context.Site.RootPath);
        }

        public static Item GetCurrentSiteHome()
        {
            return Context.Database.GetItem(GetCurrentSiteFolder().Paths.FullPath + "/" + Context.Site.StartItem);
        }

        public static Item GetItemLink(Item item, string fieldName)
        {
            return Context.Database.GetItem(item.Fields[fieldName].Value);
        }
    }
}