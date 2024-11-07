using System.ComponentModel.DataAnnotations;

namespace Mankeep.Models
{
	public class assets
	{
		     [Key]
			public int asset_id { get; set; } 
			public string assets_name { get; set; }
		    public string assets_name_reference_number { get; set; }
		    public string assets_description { get; set; } 
			public DateTime purchase_date { get; set; } 
			public decimal purchase_price { get; set; } 
			public string asset_type { get; set; }
			public DateTime? disposal_date { get; set; } 
			public string disposal_reason { get; set; } 
			public int office_id { get; set; }
		    public DateTime created_at { get; set; }
		     public int created_by { get; set; }  
			public DateTime? updated_at { get; set; }
		     public int? updated_by { get; set; }
		    public DateTime? deleted_at { get; set; }
	      	public int? deleted_by { get; set; } 
			

	}
}
