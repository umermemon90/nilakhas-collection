using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nilakhas_collection.Models
{
    public class workerssignup
    {
        [Key]
        public int workerid { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string workername { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string phonenumber { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string address { get; set; } = string.Empty;

        // Nayi property dropdown ke liye
        [Required(ErrorMessage = "Please select worker role/work type.")]
        [Column(TypeName = "nvarchar(100)")]
        public string workrole { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Column(TypeName = "nvarchar(max)")]
        public string password { get; set; }

        [NotMapped]
        public IFormFile workerimage { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string workerimagename { get; set; }
    }
}