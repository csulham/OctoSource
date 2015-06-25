using Sitecore.Base.Helpers;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System.Collections.Generic;

namespace Sitecore.Base.Site.Models.Base.Carousel
{


    public class CarouselRenderingModel : DefaultRenderingModel
    {
        public List<CarouselItem> CarouselList = new List<CarouselItem>();


        public CarouselRenderingModel(string carouselPath)
            : base(carouselPath)
        {

        }

        public override void Initialize()
        {


            string active = "active";
            foreach (Item carouselItem in ContextItem.Children)
            {
                AddCarouselItem(carouselItem, active);
                active = "";
            }
        }

        private void AddCarouselItem(Item carouselItem, string active)
        {
            CarouselList.Add(new CarouselItem()
            {
                Item = carouselItem,
                Active = active
                
                
            });
        }

     
    }
}