using System.Numerics;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nilakhas_collection.Models
{
    public class neworderformki
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderid { get; set; }

        public string ordernumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "customername is required.")]
        [Column(TypeName = "nvarchar(100)")]
        public string customername { get; set; } = string.Empty;

        [Required(ErrorMessage = "phonenumber is required.")]
        [Column(TypeName = "nvarchar(100)")]
        public string phonenumber { get; set; } = string.Empty;

        public DateTime bookingdate { get; set; }

        public DateTime diliverydate { get; set; }


        public string orderstatus { get; set; } = string.Empty;
        public int quantity { get; set; }

        public int total { get; set; } 

        public int advanced { get; set; }
        public int duepayment { get; set; }
        public int lenght { get; set; }
        public int chest { get; set; }
        public int waist { get; set; }
        public int bottom { get; set; }
        public int shoulder { get; set; }
        public int seelves { get; set; }
        public int shalwar { get; set; }
        public int shalwar_bottom { get; set; }

        [Required(ErrorMessage = "pakage is required.")]
        [Column(TypeName = "nvarchar(100)")]
        public string stitchingpackage { get; set; } = string.Empty;

        public string instruction { get; set; } = string.Empty;








    }
}
