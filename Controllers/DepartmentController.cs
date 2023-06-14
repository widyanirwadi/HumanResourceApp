using HumanResourceApp.Contracts;
using HumanResourceApp.Models;
using HumanResourceApp.Context;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HumanResourceApp.Controllers
{
    [ApiController]
    [Route("Department")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _DepartmentRepository;

        private readonly DbContext _dbContext;

        public DepartmentController(IDepartmentRepository DepartmentRepository, DbContext dbContext)
        {
            _DepartmentRepository = DepartmentRepository;
            _dbContext = dbContext;
        }

        [HttpGet("GetDepartmentByKey")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Department>))]
        public async Task<IActionResult> GetDepartmentByKey(int departmentID)
        {
            IEnumerable<Department> departments = await _DepartmentRepository.GetDepartmentByKey(departmentID);
            return Ok(departments);
        }

    }
}
