using System.ComponentModel.DataAnnotations;

namespace Mankeep.Models
{
	public class expense_category
	{
		[Key]
		public int expense_category_id { get; set; } 
		public string expense_category_name { get; set; } 
		public string expense_category_reference_number { get; set; }
		public DateTime expense_category_date { get; set; } 
		public string expense_category_description { get; set; } 
		public int office_id { get; set; }
		public DateTime? created_at { get; set; } 
		public int created_by { get; set; } 
		public DateTime? updated_at { get; set; } 
		public int? updated_by { get; set; } 
		public DateTime? deleted_at { get; set; } 
		public int? deleted_by { get; set; }

		public virtual ICollection<expenses> expenses { get; set; }
	}
}
