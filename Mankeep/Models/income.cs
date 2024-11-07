using System.ComponentModel.DataAnnotations;

namespace Mankeep.Models
{
    public class income
    {
             [Key]
            public int income_id { get; set; }
            public decimal income_amount { get; set; } 
            public DateTime income_date { get; set; } 
            public string income_reference_number { get; set; } 
            public string income_description { get; set; } 
            public string income_reason { get; set; } 
            public int office_id { get; set; } 
            public DateTime created_at { get; set; }
            public int created_by { get; set; }
            public DateTime? updated_at { get; set; }
            public int? updated_by { get; set; } 
            public DateTime? deleted_at { get; set; } 
            public int? deleted_by { get; set; } 

     

}
}
