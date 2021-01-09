using System;

namespace Sweepi.ProductServiceAPI.DTOs
{
    public class ProductUpdate
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool Favourite { get; set; } = false;
        public DateTime? Expiration { get; set; }
    }
}
