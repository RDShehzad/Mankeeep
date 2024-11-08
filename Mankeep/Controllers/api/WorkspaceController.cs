using Microsoft.AspNetCore.Mvc;
using Mankeep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mankeep.DTO;

namespace Mankeep.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkspaceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public int userId;
        public int officeid;

        public WorkspaceController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            userId = int.Parse(_configuration["AppSettings:UserId"]);
            officeid = int.Parse(_configuration["AppSettings:office_id"]);
        }

        // GET: api/Workspace/getAll
        [HttpGet("getAll")] 
        public async Task<IActionResult> GetAllWorkspaces()
        {

            try
            {
                        var workspaceNames = await _context.workspace.Select(w => w.workspace_name)
                         .ToListAsync();

                        return Ok(workspaceNames);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

            // POST: api/Workspace/add
            [HttpPost("AddWorkspace")]
        public async Task<IActionResult> AddWorkspace([FromBody] WorkspaceDTO workspacedto)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var workspace = new workspace
                {
                    workspace_name = workspacedto.workspace_name,
                    workspace_description = "new",
                    workspace_date = DateTime.Now,
                    office_id = officeid,
                    created_at = DateTime.UtcNow,
                    created_by = userId
                };

                _context.workspace.Add(workspace);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex) { 
            return BadRequest(ex.Message);
            }
        }
    }   
}
