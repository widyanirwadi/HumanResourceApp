using HumanResourceApp.Context;
using HumanResourceApp.Contracts;
using HumanResourceApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourcesApp.Controllers
{
    [ApiController]
    [Route("Person")]
    public class PersonController : Controller
    {
        private readonly IPersonRepository _PersonRepository;
        private readonly DbContext _dbContext;

        public PersonController (IPersonRepository personRepository, DbContext dbContext)
        {
            _PersonRepository = personRepository;
            _dbContext = dbContext;
        }

        [HttpGet("GetPersonByKey")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Person>))]
        public async Task<IActionResult> GetPersonByKey (int businessEntityID)
        {
            IEnumerable<Person> persons = await _PersonRepository.GetPersonByKey(businessEntityID);
            return Ok(persons);
        }

        [HttpGet("GetPersonPhoneByKey")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PersonPhone>))]
        public async Task<IActionResult> GetPersonPhoneByKey (int businessEntityID)
        {
            IEnumerable<PersonPhone> personPhone = await _PersonRepository.GetPersonPhoneByKey(businessEntityID);
            return Ok(personPhone);
        }

        [HttpGet("GetPersonAndPhoneByKey")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Person>))]
        public async Task<IActionResult> GetPersonAndPhoneByKey(int businessEntityID)
        {
            var results = new List<Person>();
            IEnumerable<Person> persons = await _PersonRepository.GetPersonByKey(businessEntityID);
            var personPhoneNumber = new List<PersonPhone>();
            foreach (var phoneNumber in persons)
            {
                personPhoneNumber = (List<PersonPhone>)await _PersonRepository.GetPersonPhoneByKey(phoneNumber.BusinessEntityID);
                phoneNumber.PersonPhones = personPhoneNumber;
                results.Add(phoneNumber);
            }
            return Ok(results);
        }

    }
}
