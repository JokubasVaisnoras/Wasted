using System;

namespace wasted_app.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Expiration { get; set; }
    }
}