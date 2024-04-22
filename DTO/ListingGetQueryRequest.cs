namespace real_estate_asp.DTO
{
    public class ListingGetQueryRequest
    {
        public string? SearchTerm { get; set; }
        public string? Sort { get; set; }
        public string? Order { get; set; }
        public int? Limit { get; set; }
        public int? StartIndex { get; set; }
        public bool[]? FurnishedValues { get; set; }
        public bool[]? ParkingValues { get; set; }

        public override string ToString()
        {
            return $"ListingGetQueryRequest{{searchTerm='{SearchTerm}', sort='{Sort}', order='{Order}', limit={Limit}, startIndex={StartIndex}}}";
        }
    }
}
