using Sitecore.Base.Helpers;
using Sitecore.Base.Site.Models.Base.Menu;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;

namespace Sitecore.Base.Site.Models.Base.Navigation
{


    public class Navigation : DefaultRenderingModel
    {
        public List<NavigationItem> NavigationList = new List<NavigationItem>();


        public Navigation()
            : base("")
        {
        }


        public override void Initialize()
        {



            Item item = ContextItem;
            foreach (Item navigationItem in ContextItem.Children)
            {
                AddNavigationlItem(navigationItem, "");
            }



        }

        private void AddNavigationlItem(Item navigationItem, string active)
        {
            NavigationList.Add(new NavigationItem()
            {
                Item = navigationItem,
                Active = active,
                Title = navigationItem.Fields["Navigation Title"].Value,
                Url = LinkManager.GetItemUrl(navigationItem)
            });
        }


    }
}