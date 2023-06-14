using HumanResourceApp.Models;

namespace HumanResourceApp.Contracts
{
    public interface IDepartmentRepository
    {
        public Task<IEnumerable<Department>> GetDepartmentByKey(int departmentID);
    }
}
