using Microsoft.EntityFrameworkCore;
using real_estate_asp.Data;
using real_estate_asp.DTO;
using real_estate_asp.Models;

namespace real_estate_asp.Services
{
    public class ListingService
    {
        private readonly ApplicationDbContext _context;

        public ListingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Listing CreateListing(ListingCreateRequest request)
        {
            var listing = new Listing
            {
                Name = request.Name ?? "Default Name",
                Description = request.Description ?? "Default Description",
                Address = request.Address ?? "Default Address",
                Bedrooms = request.Bedrooms ?? 0,
                Bathrooms = request.Bathrooms ?? 0,
                Price = request.Price ?? 0.0,
                Parking = request.Parking ?? false,
                Furnished = request.Furnished ?? false,
                UserId = request.UserId ?? "3",
                ImageUrls = request.ImageUrls ?? new List<string>()
            };

            _context.Listings.Add(listing);
            _context.SaveChanges();

            return listing;
        }

        public void DeleteListing(long id)
        {
            var listing =
                _context.Listings.Find(id)
                ?? throw new Exception($"Listing with ID {id} not found.");
            _context.Listings.Remove(listing);
            _context.SaveChanges();
        }

        public Listing UpdateListing(long id, ListingUpdateRequest request)
        {
            var listing =
                _context.Listings.Find(id)
                ?? throw new Exception($"Listing with ID {id} not found.");

            // Update only the properties that are provided in the request
            listing.Name = request.Name ?? listing.Name;
            listing.Description = request.Description ?? listing.Description;
            listing.Address = request.Address ?? listing.Address;
            listing.Bedrooms = request.Bedrooms ?? listing.Bedrooms;
            listing.Bathrooms = request.Bathrooms ?? listing.Bathrooms;
            listing.Price = request.Price ?? listing.Price;
            listing.Parking = request.Parking ?? listing.Parking;
            listing.Furnished = request.Furnished ?? listing.Furnished;
            listing.ImageUrls = request.Urls ?? listing.ImageUrls;

            _context.SaveChanges();

            return listing;
        }

        public Listing GetListing(long id)
        {
            var listing =
                _context.Listings.Find(id)
                ?? throw new Exception($"Listing with ID {id} not found.");
            return listing;
        }

        public Listing[] SearchAndFilterListings(ListingGetQueryRequest request)
        {
            var searchTerm = (request.SearchTerm ?? "").ToLower();
            var sort = (request.Sort ?? "created_at").ToLower();
            var order = (request.Order ?? "desc").ToLower();
            var limit = request.Limit ?? 10;
            var startIndex = request.StartIndex ?? 0;
            var furnishedValues = request.FurnishedValues ?? [true, false];
            var parkingValues = request.ParkingValues ?? [true, false];

            var filteredListings = _context
                .Listings.Where(listing =>
                    listing.Name != null && listing.Name.ToLower().Contains(searchTerm)
                )
                .Where(listing =>
                    listing.Furnished.HasValue && furnishedValues.Contains(listing.Furnished.Value)
                )
                .Where(listing =>
                    listing.Parking.HasValue && parkingValues.Contains(listing.Parking.Value)
                );

            if (sort == "price")
            {
                filteredListings =
                    order == "asc"
                        ? filteredListings.OrderBy(listing => listing.Price)
                        : filteredListings.OrderByDescending(listing => listing.Price);
            }
            else if (sort == "created_at")
            {
                filteredListings =
                    order == "asc"
                        ? filteredListings.OrderBy(listing => listing.CreatedAt)
                        : filteredListings.OrderByDescending(listing => listing.CreatedAt);
            }

            return filteredListings.Skip(startIndex).Take(limit).ToArray();
        }
    }
}
