namespace Mankeep.DTO
{
    public class AddBookDTO
    {
        public string book_name { get; set; }
        public string book_reference_number { get; set; }
        public string book_description { get; set; }
        public DateTime book_date { get; set; }
        public decimal book_amount { get; set; }
    }
}
