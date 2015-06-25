using Sitecore.Base.Helpers;
using Sitecore.Base.Site.Models.Base.Menu;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;

namespace Sitecore.Base.Site.Models.Base.BreadCrumb
{


    public class BreadCrumb : DefaultRenderingModel
    {
        public List<BreadCrumbItem> MenuList = new List<BreadCrumbItem>();


        public BreadCrumb()
            : base("")
        {
        }


        public override void Initialize()
        {



            AddCarouselItem(ContextItem, "active");
            Item item = ContextItem;
            while (item.ParentID != ScHelper.GetCurrentSiteHome().ID)
            {
                AddCarouselItem(item.Parent, "");
                item = item.Parent;
            }
            AddCarouselItem(ScHelper.GetCurrentSiteHome(), "");
            MenuList.Reverse();


        }

        private void AddCarouselItem(Item carouselItem, string active)
        {
            MenuList.Add(new BreadCrumbItem()
            {
                Item = carouselItem,
                Active = active,
                Title = carouselItem.Fields["Navigation Title"].Value,
                Url = LinkManager.GetItemUrl(carouselItem)
            });
        }


    }
}