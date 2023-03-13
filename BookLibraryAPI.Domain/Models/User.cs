using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BookLibraryAPI.Domain.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public List<Review> UserReviews { get; set; }
    }
}
