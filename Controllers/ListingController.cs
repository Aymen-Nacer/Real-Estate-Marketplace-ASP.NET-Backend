using Microsoft.AspNetCore.Mvc;
using real_estate_asp.DTO;
using real_estate_asp.Models;
using real_estate_asp.Services;

namespace real_estate_asp.Controllers
{
    [ApiController]
    [Route("api/listings")]
    public class ListingController : ControllerBase
    {
        private readonly ListingService _listingService;

        public ListingController(ListingService listingService)
        {
            _listingService = listingService;
        }

        [HttpPost("create")]
        public IActionResult CreateListing([FromBody] ListingCreateRequest request)
        {
            Listing createdListing;
            try
            {
                createdListing = _listingService.CreateListing(request);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ApiResponse(false, null, null, "Error creating listing")
                );
            }

            return Ok(
                new ApiResponse(
                    true,
                    null,
                    new List<Listing> { createdListing },
                    "Listing created successfully"
                )
            );
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteListing(long id)
        {
            try
            {
                _listingService.DeleteListing(id);
                return Ok(new ApiResponse(true, null, null, "Listing deleted successfully"));
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ApiResponse(false, null, null, "Error deleting listing")
                );
            }
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateListing(long id, [FromBody] ListingUpdateRequest request)
        {
            try
            {
                var updatedListing = _listingService.UpdateListing(id, request);
                return Ok(
                    new ApiResponse(
                        true,
                        null,
                        new List<Listing> { updatedListing },
                        "Listing updated successfully"
                    )
                );
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ApiResponse(false, null, null, "Error updating listing")
                );
            }
        }

        [HttpGet("get/{id}")]
        public IActionResult GetListing(long id)
        {
            try
            {
                Listing listing = _listingService.GetListing(id);
                if (listing == null)
                {
                    throw new Exception("Listing not found");
                }
                return Ok(
                    new ApiResponse(
                        true,
                        null,
                        new List<Listing> { listing },
                        "Listing retrieved successfully"
                    )
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new ApiResponse(false, null, null, ex.Message)
                );
            }
        }

        [HttpGet("search")]
        public IActionResult SearchAndFilterListings([FromBody] ListingGetQueryRequest request)
        {
            try
            {
                var listings = _listingService.SearchAndFilterListings(request);
                return Ok(listings);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving listings: {ex.Message}");
            }
        }
    }
}
