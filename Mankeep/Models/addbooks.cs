using System.ComponentModel.DataAnnotations;

namespace Mankeep.Models
{
    public class addbooks
    {
        [Key]
        public int book_id { get; set; }
        public string book_name { get; set; }
        public string book_reference_number { get; set; }
        public string book_description { get; set; }
        public DateTime book_date { get; set; }
        public decimal book_amount { get; set; }
        public int office_id { get; set; }
        public DateTime created_at { get; set; }
        public int created_by { get; set; }
        public DateTime? updated_at { get; set; }
        public int? updated_by { get; set; }
        public DateTime? deleted_at { get; set; }
        public int? deleted_by { get; set; }
    }
}
