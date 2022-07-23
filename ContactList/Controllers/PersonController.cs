using AutoMapper;
using ContactList.DTO;
using ContactList.Entity;
using ContactList.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ContactList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public PersonController(IPersonService personService, IContactService contactService, IMapper mapper)
        {
            _personService = personService;
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                var person = await _personService.Find(id);
                return Ok(new
                {
                    success = true,
                    data = _mapper.Map<PersonDTO>(person)
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonReqDTO personDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new
                    {
                        success = false,
                        data = ModelState.Values.SelectMany(e => e.Errors)
                    });

                var person = _mapper.Map<Person>(personDTO);
                await _personService.Insert(person);

                //return Created($"/{person.Id}", person);
                return Ok(new
                {
                    success = true,
                    data = _mapper.Map<PersonDTO>(person)
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

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] PersonReqDTO personDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(new
                    {
                        success = false,
                        data = ModelState.Values.SelectMany(e => e.Errors)
                    });

                var person = _mapper.Map<Person>(personDTO);
                person.Id = id;
                await _personService.Update(person);

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
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _personService.Delete(id);

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

        [HttpPost("{personId:guid}/contacts")]
        public async Task<IActionResult> CreateContact([FromRoute] Guid personId, [FromBody] ContactReqDTO contactDTO)
        {
            try
            {
                var contact = _mapper.Map<Contact>(contactDTO);
                contact.PersonId = personId;
                await _contactService.Insert(contact);
                return Ok(new { success = true, data = string.Empty });
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
