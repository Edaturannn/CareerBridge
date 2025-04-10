using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website.DataAccess.Concrete;
using Website.Entities.Concrete;
namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class ClassesController : Controller
    {
        private readonly Context _context;
        public ClassesController(Context context)
        {
            _context = context;
        }
        
        [HttpGet("GetListAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var values = await _context.Classes.ToListAsync();
            return Ok(values);
        }
    }
}

