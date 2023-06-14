using Dapper;
using HumanResourceApp.Context;
using HumanResourceApp.Contracts;
using HumanResourceApp.Models;
using System.Data;

namespace HumanResourceApp.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DbContext _dbContext;

        public PersonRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Person>> GetPersonByKey (int businessEntityID)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                const string storedProcedure = "dbo.GetPersonByKey";
                return await connection.QueryAsync<Person>(storedProcedure, 
                    new 
                    { 
                        businessEntityID 
                    }, 
                        commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<PersonPhone>> GetPersonPhoneByKey (int businessEntityID)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                const string storedProcedure = "dbo.GetPersonPhoneByKey";
                return await connection.QueryAsync<PersonPhone>(storedProcedure,
                    new
                    {
                        businessEntityID
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
