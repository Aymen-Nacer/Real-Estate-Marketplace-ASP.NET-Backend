using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace real_estate_asp.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? Avatar { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public User()
        {
            Username = "default_username";
            Email = "default_email@example.com";
            Password = "default_password";
            Avatar =
                "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public User(string? username, string? email, string? password)
        {
            Username = username;
            Email = email;
            Password = password;
            Avatar =
                "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public User(string? username, string? email, string? password, string? avatar)
        {
            Username = username;
            Email = email;
            Password = password;
            Avatar = avatar;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public override string ToString() =>
            $"User{{Id={Id}, Username='{Username}', Email='{Email}', Password='{Password}', Avatar='{Avatar}', CreatedAt={CreatedAt}, UpdatedAt={UpdatedAt}}}";
    }
}
