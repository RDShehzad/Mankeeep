using System.ComponentModel.DataAnnotations;

namespace Mankeep.Models
{
	public class expenses
	{
		

		[Key]
		public int expense_id { get; set; }

		public int expense_category_id { get; set; }

		[Required]
		[StringLength(50)]
		public string expense_reference_number { get; set; }

		[Required]
		[StringLength(100)]
		public string expense_name { get; set; }

		[StringLength(250)]
		public string expense_description { get; set; }

		public DateTime expense_date { get; set; }

		public int office_id { get; set; }

		public DateTime created_at { get; set; }

		public int created_by { get; set; }

		public DateTime? updated_at { get; set; }

		public int? updated_by { get; set; } 

		public DateTime? deleted_at { get; set; }

		public int? deleted_by { get; set; }

		public virtual expense_category expense_category { get; set; }
	}

}
