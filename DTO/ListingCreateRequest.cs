namespace real_estate_asp.DTO
{
    public class ListingCreateRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public double? Price { get; set; }
        public bool? Parking { get; set; }
        public bool? Furnished { get; set; }
        public string? UserId { get; set; }

        public List<string>? ImageUrls { get; set; }

        public override string ToString()
        {
            return $"ListingCreateRequest{{name='{Name}', description='{Description}', address='{Address}', bedrooms={Bedrooms}, bathrooms={Bathrooms}, price={Price}, parking={Parking}, furnished={Furnished}, userId='{UserId}'}}";
        }
    }
}
