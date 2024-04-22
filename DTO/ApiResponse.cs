using real_estate_asp.Models;

namespace real_estate_asp.DTO
{
    public class ApiResponse
    {
        public bool? Success { get; }
        public User? User { get; }
        public List<Listing>? Listings { get; }
        public string? Message { get; }

        public ApiResponse(bool? success, User? user, List<Listing>? listings, string? message)
        {
            Success = success;
            User = user;
            Listings = listings;
            Message = message;
        }
    }
}
