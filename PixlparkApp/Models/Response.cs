using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PixlparkApp.Models
{
    public class Order
    {
        [JsonProperty("Title")]
        [Display(Name = "Наименование")]
        public string Title { get; set; }

        [Display(Name = "URL отслеживания")]
        [JsonProperty("TrackingUrl")]
        public string TrackingUrl { get; set; }

        [Display(Name = "Номер отслеживания")]
        [JsonProperty("TrackingNumber")]
        public long? TrackingNumber { get; set; }

        [Display(Name = "Статус")]
        [JsonProperty("Status")]
        public string Status { get; set; }

        [Display(Name = "Адрес доставки")]
        [JsonProperty("DeliveryAddress")]
        public DeliveryAddress DeliveryAddress { get; set; }

        [Display(Name = "Доставка")]
        [JsonProperty("Shipping")]
        public Shipping Shipping { get; set; }

        [Display(Name = "Итоговая цена")]
        [JsonProperty("TotalPrice")]
        public double TotalPrice { get; set; }
    }

    public class DeliveryAddress
    {
        [Display(Name = "Адрес1")]
        [JsonProperty("AddressLine1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Город")]
        [JsonProperty("City")]
        public string City { get; set; }

        [Display(Name = "Страна")]
        [JsonProperty("Country")]
        public string Country { get; set; }

        [Display(Name = "Получатель")]
        [JsonProperty("FullName")]
        public string FullName { get; set; }
    }

    public class Shipping
    {
        [Display(Name = "Наименование")]
        [JsonProperty("Title")]
        public string Title { get; set; }

        [Display(Name = "Тип доставки")]
        [JsonProperty("ShippingType")]
        [DefaultValue("-")]
        public string ShippingType { get; set; }
    }
    public class Response
    {
        [JsonProperty("Result")]
        public List<Order> Orders { get; set; }
        [JsonProperty("ResponseCode")]
        public short ResponseCode { get; set; }
    }


}