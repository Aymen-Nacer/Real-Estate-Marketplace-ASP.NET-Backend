using System;
using Microsoft.AspNetCore.Mvc;
using real_estate_asp.DTO;
using real_estate_asp.Models;
using real_estate_asp.Services;

namespace real_estate_asp.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateUser(long id, [FromBody] UserUpdateRequest request)
        {
            try
            {
                var updatedUser = _userService.UpdateUser(id, request);
                return Ok(new ApiResponse(true, updatedUser, null, "User updated successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ApiResponse(false, null, null, "Error updating user"));
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(long id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok(new ApiResponse(true, null, null, "User deleted successfully"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ApiResponse(false, null, null, "Error deleting user"));
            }
        }

        [HttpGet("listings/{id}")]
        public IActionResult GetUserListings(long id)
        {
            try
            {
                var userlistings = _userService.GetUserListings(id);
                return Ok(
                    new ApiResponse(true, null, userlistings, "User listings fetched successfully")
                );
            }
            catch (Exception)
            {
                return StatusCode(
                    500,
                    new ApiResponse(false, null, null, "Error fetching user listings")
                );
            }
        }
    }
}
