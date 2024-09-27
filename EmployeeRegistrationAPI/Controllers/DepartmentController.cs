using EmployeeRegistrationAPI.Models;
using EmployeeRegistrationAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;
        public DepartmentController(IDepartmentService _departmentService, ILogger<DepartmentController> _logger)
        {
            this._logger = _logger;
            this._departmentService = _departmentService;
        }
        [HttpGet]
        [Route("All", Name = "GetDepartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DepartmentDTO>> GetDepartmentAsync()
        {
            _logger.LogInformation("GetDepartment method started");

            var response = await _departmentService.GetAllAsync();
            return Ok(response);

           
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetDepartmentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DepartmentDTO>> GetDepartmentByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }
            var response = await _departmentService.GetByIdAsync(id);
            return Ok(response);

           
        }

        [HttpPost("CreateDepartment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DepartmentDTO>> CreateDepartmentAsync([FromBody] DepartmentDTO model)
        {


            await _departmentService.CreateAsync(model);
            return Ok();
            
        }



        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<bool>> DeleteDepartmentAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var response = await _departmentService.DeleteAsync(id);
            return Ok(response);

            
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<DepartmentDTO>> UpdateDepartmentAsync([FromBody] DepartmentDTO model)
        {
            if (model == null || model.DepartmentId <= 0)
                return BadRequest();
            await _departmentService.UpdateAsync(model);
            return Ok();
           
        }
    }
}
