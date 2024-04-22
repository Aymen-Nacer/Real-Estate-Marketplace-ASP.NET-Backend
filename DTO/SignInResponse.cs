using real_estate_asp.Models;

namespace real_estate_asp.DTO
{
    public class SignInResponse
    {
        public bool? Success { get; init; }
        public string? Message { get; init; }
        public User? User { get; init; }
        public string? Cookie { get; init; }

        public SignInResponse(bool? success, string? message, User? user, string? cookie)
        {
            Success = success;
            Message = message;
            User = user;
            Cookie = cookie;
        }
    }
}
