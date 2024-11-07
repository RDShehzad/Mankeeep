using Mankeep.DTO;
using Mankeep.DTO.Mankeep.DTO;
using Mankeep.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mankeep.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class AssetController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IConfiguration _configuration;
		public int userId;
		public int officeid;
		public AssetController(ApplicationDbContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
			userId = int.Parse(_configuration["AppSettings:UserId"]);
			officeid = int.Parse(_configuration["AppSettings:office_id"]);
		}

		[HttpPost("AddAsset")]
		public async Task<IActionResult> AddAsset([FromBody] AssetsDTO assetsdto)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var assets = new assets
			{
				assets_name = assetsdto.assets_name,
				purchase_date = assetsdto.purchase_date,
				purchase_price = assetsdto.purchase_price,
				assets_description = assetsdto.assets_description,
				asset_type = assetsdto.asset_type,
				disposal_date = assetsdto.disposal_date,
				disposal_reason = assetsdto.disposal_reason,
				assets_name_reference_number = assetsdto.assets_name_reference_number,
				office_id = officeid,
				created_at = DateTime.UtcNow,
				created_by = userId,




			};
			_context.assets.Add(assets);
			await _context.SaveChangesAsync();

			return Ok();
		}

		// GET: api/assets/GetAssets
		[HttpGet("GetAssets")]
		public async Task<IActionResult> GetAssets()
		{
			try
			{
				var assets = await _context.assets.ToListAsync();
				return Ok(assets);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


		[HttpGet("getAsset/{id}")]
		public async Task<IActionResult> GetCustomer(int id)
		{
			var assets = await _context.assets.FindAsync(id);

			if (assets == null)
			{
				return NotFound();
			}

			return Ok(assets);
		}

		// post: api/asstes/updateassets/{id}
		[HttpPost("updateAsset/{id}")]
		public async Task<IActionResult> updateAsset(int id, [FromBody] assets updatedassets)
		{
			if (id != updatedassets.asset_id)
			{
				return BadRequest("Assets ID mismatch.");
			}

			var assets = await _context.assets.FindAsync(id);
			if (assets == null)
			{
				return NotFound();
			}

			// Update Customer properties
			assets.asset_id = updatedassets.asset_id;
			assets.assets_name = updatedassets.assets_name;
			assets.assets_name_reference_number = updatedassets.assets_name_reference_number;
			assets.purchase_date = updatedassets.purchase_date;
			assets.asset_type = updatedassets.asset_type;
			assets.assets_description = updatedassets.assets_description;
			assets.disposal_date = updatedassets.disposal_date;
			assets.disposal_reason = updatedassets.disposal_reason;
			assets.updated_at = DateTime.UtcNow;
			assets.updated_by = userId;

			await _context.SaveChangesAsync();

			return Ok("Customer updated successfully.");
		}
	}
}
