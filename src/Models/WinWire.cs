using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace src.Models
{
    public class WinWire
    {

        /* Id INT PRIMARY KEY NOT NULL,
            Title VARCHAR(50),
            DateCreated DATETIME2,
            Discription VARCHAR(500),
            IsApproved BIT,
            DisApproveReason VARCHAR(500),
            IsDeleted BIT,
            CreatedBy VARCHAR(50),
            ApproverContactId INT,
            ContactId INT FOREIGN KEY REFERENCES Contact(ID) */

        public string GetExampleJson ()
        {
           var json = @"{
                ""id"": 1,
                ""title"": ""string"",
                ""dateCreated"": ""2021-05-01T00:00:00"",
                ""discription"": ""string"",
                ""isApproved"": true,
                ""disApproveReason"": ""string"",
                ""isDeleted"": true,
                ""createdBy"": ""string"",
                ""approverContactId"": 1,
                ""contactId"": 1
            }";
            return json;
        }




        [JsonPropertyName("id")]
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("dateCreated")]
        public DateTime DateCreated { get; set; }
        [MaxLength(500)]
        [JsonPropertyName("discription")]
        public string? Discription { get; set; }
        [JsonPropertyName("isApproved")]
        public bool IsApproved { get; set; }
        [MaxLength(500)]
        [JsonPropertyName("disApproveReason")]
        public string? DisApproveReason { get; set; }
        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }
        [MaxLength(50)]
        [JsonPropertyName("createdBy")]
        public string? CreatedBy { get; set; }
        [JsonPropertyName("approverContactId")]
        public int ApproverContactId { get; set; }
        [ForeignKey("ContactId")]
        [Column(Order = 1)]
        [JsonPropertyName("contactId")]
        public int ContactId { get; set; }



    }

    public class WinWireDto{
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime DateCreated { get; set; }
        public string? Discription { get; set; }
        public bool IsApproved { get; set; }
        public string? DisApproveReason { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreatedBy { get; set; }
        public int ApproverContactId { get; set; }
        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}