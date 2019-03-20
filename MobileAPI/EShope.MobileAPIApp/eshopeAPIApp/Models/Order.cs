﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace EShope.MobileAPIApp.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class Order
    {
        /// <summary>
        /// Initializes a new instance of the Order class.
        /// </summary>
        public Order() { }

        /// <summary>
        /// Initializes a new instance of the Order class.
        /// </summary>
        public Order(string id = default(string), Guid? userId = default(Guid?), DateTime? checkoutDateTime = default(DateTime?), IList<OrderItem> orderItems = default(IList<OrderItem>))
        {
            Id = id;
            UserId = userId;
            CheckoutDateTime = checkoutDateTime;
            OrderItems = orderItems;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "userId")]
        public Guid? UserId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "checkoutDateTime")]
        public DateTime? CheckoutDateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "orderItems")]
        public IList<OrderItem> OrderItems { get; set; }

    }
}