using System;

namespace wasted_app.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Expiration { get; set; }
        public string Type { get; set; }
    }
}