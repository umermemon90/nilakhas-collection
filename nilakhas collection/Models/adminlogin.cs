using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nilakhas_collection.Models
{
    public class adminlogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int loginid { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [Column(TypeName = "nvarchar(100)")]
        
        public string username { get; set; }= string.Empty;

        //password
        PasswordHasher<adminlogin> passwordHasher = new PasswordHasher<adminlogin>();
        [Required(ErrorMessage = "password is required.")]
        [Column(TypeName = "nvarchar(255)")]
        public string password { get; set; }= string.Empty;


        [Required(ErrorMessage = "remeber me is required.")]

        public bool rememberMe { get; set; }


        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; } = DateTime.Now;




    }
}
