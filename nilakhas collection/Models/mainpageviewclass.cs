namespace nilakhas_collection.Models
{
    public class mainpageviewclass
    {
        public int totalorders { get; set; }
        public int totalbilling { get; set; }

        public int pendingorders { get; set; }
        public int pendingbilling { get; set; }

        public List<neworderformki> orderlist { get; set; }


    }
}
