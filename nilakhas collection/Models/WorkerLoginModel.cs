using System.ComponentModel.DataAnnotations;

namespace nilakhas_collection.Models
{
    public class WorkerLoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string workername { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
