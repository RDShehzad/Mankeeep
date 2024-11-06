using System.ComponentModel.DataAnnotations;

namespace Mankeep.Models
{
	public class customers
	{
		
			[Key]
			public int customer_id { get; set; }

			public string customer_reference_number { get; set; }

			public string customer_name { get; set; }

			public int customer_phone { get; set; }

			public string customer_address { get; set; }

			public string customer_description { get; set; }

			public DateTime customer_date { get; set; }

			public decimal Balance { get; set; }

			public int office_id { get; set; }

			public DateTime created_at { get; set; } = DateTime.UtcNow;
			public int created_by { get; set; }

			public DateTime? updated_at { get; set; }
			public int updated_by { get; set; }

			public DateTime? deleted_at { get; set; }
			public int deleted_by { get; set; }




		
	}
}
