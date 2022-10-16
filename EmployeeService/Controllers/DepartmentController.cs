using EmployeeService.Models.Dto;
using EmployeeService.Services;
using EmployeeService.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        #region Services 

        private readonly IDepartmentRepository _departmentRepository;

        #endregion

        #region Constructors

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        #endregion

        #region Public Methods

        [HttpGet("departments/all")]
        public ActionResult<IList<DepartmentDto>> GetAllDepartments()
        {
            return Ok(_departmentRepository.GetAll().Select(dp =>
                new DepartmentDto
                {
                    DepartmentId = dp.Id,
                    FirstName = dp.Description
                }
                ).ToList());
        }

        [HttpDelete("departments/delete")]
        public ActionResult<bool> DeleteDepartmente([FromQuery] Guid id)
        {
            return Ok(_departmentRepository.Delete(id));
        }

        #endregion

    }
}
