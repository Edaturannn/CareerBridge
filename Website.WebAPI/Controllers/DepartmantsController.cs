using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website.Business.Abstract;
using Website.DataAccess.Concrete;
using Website.Dtos.Concrete.ContactDtos;
using Website.Entities.Concrete;
namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class DepartmantsController : Controller
    {
        private readonly Context _context;
        public DepartmantsController(Context context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Departmant departmant)
        {
            _context.Departmants.Add(departmant);
            await _context.SaveChangesAsync();
            return Ok("Başarılı Bir Şekilde Eklendi...");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var values = await _context.Departmants.FindAsync(id);
            _context.Departmants.Remove(values);
            await _context.SaveChangesAsync();
            return Ok("Başarılı Bir Şekilde Silindi...");
        }
        [HttpGet("GetListAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var values = await _context.Departmants.ToListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var values = await _context.Departmants.FindAsync(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Departmant departmant)
        {
            var values = await _context.Departmants.FindAsync(departmant.DepartmantId);
            if (values == null)
            {
                return NotFound("Departman bulunamadı.");
            }

            // Güncellenecek alanları burada set et
            values.DepartmantName = departmant.DepartmantName;
      
            // varsa diğer alanları da aynı şekilde yaz

            await _context.SaveChangesAsync();

            return Ok("Başarılı bir şekilde güncellendi.");
        }
    }
}

