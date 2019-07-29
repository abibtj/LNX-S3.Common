using System.ComponentModel.DataAnnotations;

namespace S3.Common.Types
{
    public class Address
    {
        [Required]
        public string Line1 { get; set; }
        public string Line2 { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }
        public string Postcode { get; set; }
    }
}
