﻿using AutoMapper;
using ContactList.DTO;
using ContactList.Entity;
using ContactList.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _contactService.Find();

            if(result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ContactReqUpdateDTO contactDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new
                    {
                        success = false,
                        data = ModelState.Values.SelectMany(e => e.Errors)
                    });

                var contact = _mapper.Map<Contact>(contactDTO);
                contact.Id = id;
                await _contactService.Update(contact);

                return Ok(new
                {
                    success = true,
                    data = string.Empty
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    data = ex.Message
                });
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _contactService.Delete(id);

                return Ok(new
                {
                    success = true,
                    data = string.Empty
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    data = ex.Message
                });
            }
        }
    }
}