using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Website.Business.Abstract;
using Website.Dtos.Concrete.AccountDtos;
using Website.Dtos.Concrete.ContactDtos;
using Website.Entities.Concrete;
namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactsController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody]CreateContactDto createContactDto)
        {
            var mapper = _mapper.Map<Contact>(createContactDto);
            await _contactService.TAddAsync(mapper);
            return Ok("Başarılı Bir Şekilde Eklendi...");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _contactService.TDeleteAsync(id);
            return Ok("Başarılı Bir Şekilde Silindi...");
        }
        [HttpGet("GetListAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var values = await _contactService.TGetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var values = await _contactService.TGetByIdAsync(id);
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateContactDto updateContactDto)
        {
            var mapper = _mapper.Map<Contact>(updateContactDto);
            await _contactService.TUpdateAsync(mapper);
            return Ok("Başarılı Bir Şekilde Eklendi...");
        }
    }
}

