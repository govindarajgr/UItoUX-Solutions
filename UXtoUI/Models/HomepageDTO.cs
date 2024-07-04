namespace UItoUX.Models
{
    public class BrandDTO
    {
        public long BrandId { get; set; }
        public string? BrandName { get; set; }
        public string? BrandLogo { get; set; }

    }

    public class ProductDTO
    {
        public long BrandId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductType { get; set; }
        public string? ModelName { get; set; }
        public string? ImageName { get; set; }
        public decimal Price { get; set; }
        public decimal OrginalPrice { get; set; }
        public int ProductRating { get; set; }
        public int Rating { get; set; }

    }

    public class SlideDTO
    {
        public long SlideId { get; set; }
        public long BrandId { get; set; }
        public string? Header { get; set; }
        public string? Description { get; set; }
        public string? ImageName { get; set; }
        public string? Notes { get; set; }

    }
    public class BannerDTO
    {
        public long BannerId { get; set; }
        public string? BannerDescription { get; set; }
        public string? BannerNotes { get; set; }
        public string? ImageName { get; set; }

    }

    public class HomepageDTO
    {
        public List<BrandDTO> Brands { get; set; }
        public List<ProductDTO> Products { get; set; }
        public List<SlideDTO> Slides { get; set; }
        public List<BannerDTO> Banners { get; set; }

    }
}
