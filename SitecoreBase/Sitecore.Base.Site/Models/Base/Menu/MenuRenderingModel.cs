using Sitecore.Base.Helpers;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;

namespace Sitecore.Base.Site.Models.Base.Menu
{


    public class MenuRenderingModel : DefaultRenderingModel
    {
        public List<MenuItem> MenuList = new List<MenuItem>();


        public MenuRenderingModel(string menuPath)
            : base(menuPath)
        {
        }


        public override void Initialize()
        {

            var mainNavigationRootItem = ((MultilistField)ContextItem.Fields["Menu Pages"]);
            foreach (string menuItemId in mainNavigationRootItem.Items)
            {

                AddMenuItem(menuItemId);
            }
        }

        private void AddMenuItem(string menuItemId)
        {
            Item menuItem = Context.Database.GetItem(menuItemId);
            MenuList.Add(new MenuItem()
            {
                Title = menuItem.Fields["Navigation Title"].Value,
                Url = LinkManager.GetItemUrl(menuItem)
            });
        }

     
    }
}