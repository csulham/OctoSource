using Sitecore.Base.Helpers;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;

namespace Sitecore.Base.Site.Models.Base
{
   

    public class DefaultRenderingModel : IRenderingModel
    {


        protected string DefaultItemPaht;
        public Item ContextItem = null;
        public DefaultRenderingModel(string defaultItemPaht)
        {
            DefaultItemPaht = defaultItemPaht;
        }


        public virtual void Initialize()
        {

        }

        protected void SetDefault()
        {
            if (string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
                RenderingContext.Current.Rendering.DataSource = !string.IsNullOrEmpty(DefaultItemPaht)? ScHelper.GetCurrentSiteFolder().Fields[DefaultItemPaht].Value : Sitecore.Context.Item.Paths.FullPath;
        }

        public void Initialize(Rendering rendering)
        {
            SetDefault();

            ContextItem = rendering.Item;
            Initialize();
        }
    }
}