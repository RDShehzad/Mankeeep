using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mankeep.Models
{
	public class supplier
	{
		[Key]
		public int supplier_id { get; set; }

		public string supplier_reference_number { get; set; }

		public string supplier_name { get; set; }

		public string supplier_phone { get; set; }

		public string supplier_address { get; set; }

		public string supplier_description { get; set; }

		public DateTime supplier_date { get; set; }

		public float Balance { get; set; }

		public int office_id { get; set; }

		public DateTime? created_at { get; set; }

		public int created_by { get; set; }

		public DateTime? updated_at { get; set; }

		public int? updated_by { get; set; }

		public DateTime? deleted_at { get; set; }

		public int? deleted_by { get; set; }

		
	}
}
