using Microsoft.AspNetCore.Identity;

namespace Gift_Site.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }  // User's full name
        public string Address { get; set; }  // Shipping address
        public string ProfilePicture { get; set; }  // Path to profile picture
        public DateTime DateOfBirth { get; set; }  // Date of birth
        public bool IsVerified { get; set; }  // Whether the user's email is verified
        public string Role { get; set; }  // User role (Admin, Customer, etc.)
    }


}
