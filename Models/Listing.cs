using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace real_estate_asp.Models
{
    public class Listing
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public double? Price { get; set; }

        [Required]
        public int? Bathrooms { get; set; }

        [Required]
        public int? Bedrooms { get; set; }

        [Required]
        public bool? Furnished { get; set; }

        [Required]
        public bool? Parking { get; set; }

        [Required]
        public List<string>? ImageUrls { get; set; }

        [Required]
        public string? UserId { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public Listing()
        {
            Name = "Default Name";
            Description = "Default Description";
            Address = "123, Bouzereah 44521";
            Price = 0.0;
            Bathrooms = 0;
            Bedrooms = 0;
            Furnished = false;
            Parking = false;
            UserId = "4";
            ImageUrls = new List<string>
            {
                "https://i.imgur.com/n6B1Fuw.jpg",
                "https://i.imgur.com/n6B1Fuw.jpg"
            };
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public override string ToString() =>
            $"Listing{{Id={Id}, Name='{Name}', Description='{Description}', Address='{Address}', Price={Price}, Bathrooms={Bathrooms}, Bedrooms={Bedrooms}, Furnished={Furnished}, Parking={Parking}, ImageUrls={ImageUrls}, UserId='{UserId}', CreatedAt={CreatedAt}, UpdatedAt={UpdatedAt}}}";
    }
}
