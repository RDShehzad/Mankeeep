namespace Mankeep.DTO
{
	public class AssetsDTO
	{
		public string assets_name { get; set; }
		public string assets_name_reference_number { get; set; }
		public string assets_description { get; set; }
		public DateTime purchase_date { get; set; }
		public decimal purchase_price { get; set; }
		public string asset_type { get; set; }
		public DateTime? disposal_date { get; set; }
		public string disposal_reason { get; set; }
	}
}
