using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test_11.Models;

namespace test_11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactPersonController : ControllerBase
    {
        private readonly ContactPersonContext _contactPersonContext;

        public ContactPersonController(ContactPersonContext contactPersonContext)
        {
            _contactPersonContext = contactPersonContext;
        }

        // GET: api/ContactPerson
        [HttpGet]
        public IEnumerable<ContactPerson> Get()
        {
            return _contactPersonContext.ContactPersons.ToList();
        }

        // GET: api/ContactPerson/5
        [HttpGet("{id}", Name = "Get")]
        public ContactPerson Get(int id)
        {
            var contactPerson = _contactPersonContext.ContactPersons.Find(id);

            return contactPerson;
        }

        // POST: api/ContactPerson
        [HttpPost]
        public IActionResult Post([FromBody] ContactPerson contactPerson)
        {
            _contactPersonContext.ContactPersons.Add(contactPerson);
            _contactPersonContext.SaveChanges();

            return CreatedAtAction("Get", new { id = contactPerson.Id }, contactPerson);
        }

        // PUT: api/ContactPerson/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ContactPerson contactPerson)
        {
            if (id != contactPerson.Id)
            {
                return BadRequest();
            }

            _contactPersonContext.Entry(contactPerson).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contactPersonContext.SaveChanges();

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contactPerson = _contactPersonContext.ContactPersons.Find(id);

            if (contactPerson == null)
            {
                return NotFound();
            }

            _contactPersonContext.ContactPersons.Remove(contactPerson);
            _contactPersonContext.SaveChanges();

            return NoContent();
        }
    }
}