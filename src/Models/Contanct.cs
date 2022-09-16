using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace src.Models
{
    public class Contact
    {
        /* ID INT PRIMARY KEY NOT NULL,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100) */

        [Required]
        [JsonPropertyName("id")]
        [Key]
        public int ContactId { get; set; }
        [MaxLength(50)]
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }
        [JsonPropertyName("lastName")]
        [MaxLength(50)]

        public string? LastName { get; set; }
        [MaxLength(100)]
        [Required]
        [JsonPropertyName("email")]
        public string? Email { get; set; }

    }
}