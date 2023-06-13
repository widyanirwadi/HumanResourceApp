using Dapper;
using HumanResourceApp.Context;
using HumanResourceApp.Contracts;
using HumanResourceApp.Models;
using System.Data;

namespace HumanResourceApp.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DbContext _dbContext;
        public DepartmentRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Department>> GetDepartmentByKey(int departmentID)
        {
            using (IDbConnection connection = _dbContext.CreateConnection())
            {
                const string storedProcedure = "dbo.GetDepartmentByKey";
                return await connection.QueryAsync<Department>(storedProcedure,
                new
                {
                    departmentID
                },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
