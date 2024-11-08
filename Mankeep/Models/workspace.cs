
using System.ComponentModel.DataAnnotations;

namespace Mankeep.Models
{
    public class workspace
    {
        [Key]

        public int workspace_id { get; set; }

        public string workspace_name { get; set; }

        public string workspace_description { get; set; }

        public DateTime workspace_date { get; set; }

        public int office_id { get; set; }
        public DateTime created_at { get; set; }
        public int created_by { get; set; }
        public DateTime? updated_at { get; set; }
        public int? updated_by { get; set; }
    }
}
