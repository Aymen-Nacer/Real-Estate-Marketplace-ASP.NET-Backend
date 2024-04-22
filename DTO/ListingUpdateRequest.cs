namespace real_estate_asp.DTO
{
    public class ListingUpdateRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public double? Price { get; set; }
        public bool? Parking { get; set; }
        public bool? Furnished { get; set; }
        public List<string>? Urls { get; set; }
    }
}
