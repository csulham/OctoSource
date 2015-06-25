
using Sitecore.Data.Items;

namespace Sitecore.Base.Site.Models.Base.Navigation
{
    public class NavigationItem
    {
        public Item Item { get; set; }
        public string Active { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }

    }
}