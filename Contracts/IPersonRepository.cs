using HumanResourceApp.Models;

namespace HumanResourceApp.Contracts
{
    public interface IPersonRepository
    {
        public Task<IEnumerable<Person>> GetPersonByKey(int businessEntityID);
        public Task<IEnumerable<PersonPhone>> GetPersonPhoneByKey(int businessEntityID);
    }
}
