using System.ComponentModel.DataAnnotations;

namespace Mankeep.DTO
{
	public class ExpenseDTO
	{
		

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

	}

	public class ExpenseCategoryDTO
	{
		
		public string expense_category_name { get; set; }
		public string expense_category_reference_number { get; set; }
		public DateTime expense_category_date { get; set; }
		public string expense_category_description { get; set; }
		
	}
}
