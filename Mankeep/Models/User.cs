using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mankeep.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }
		
		public string Password { get; set; }

		public string Email { get; set; }

		
		[Column("active_status")]
		public bool ActiveStatus { get; set; }

		public DateTime? created_at { get; set; }

		public DateTime? updated_at { get; set; }

		
	}
}
