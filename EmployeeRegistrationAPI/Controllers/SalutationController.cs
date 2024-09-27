using EmployeeRegistrationAPI.Models;
using EmployeeRegistrationAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalutationController : ControllerBase
    {
        private readonly ISalutationService _salutationService;
        private readonly ILogger<SalutationController> _logger;
        public SalutationController(ISalutationService _salutationService, ILogger<SalutationController> _logger)
        {
            this._salutationService = _salutationService;
            this._logger = _logger;
            
        }
        [HttpGet]
        [Route("All", Name = "GetSalutation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SalutationDTO>> GetSalutationAsync()
        {
            _logger.LogInformation("GetSalutation method started");
            var response = await _salutationService.GetAllAsync();
            return Ok(response);
           

        }

        [HttpGet]
        [Route("{id:int}", Name = "GetSalutationById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<SalutationDTO>> GetSalutationByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }
            var response = await _salutationService.GetByIdAsync(id);
            return Ok(response);

            
        }

        [HttpPost("CreateSalutation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<SalutationDTO>> CreateSalutationAsync([FromBody] SalutationDTO model)
        {
            try
            {
                await _salutationService.CreateAsync(model);
                return Ok();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<bool>> DeleteSalutationAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var response = await _salutationService.DeleteAsync(id);
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
        public async Task<ActionResult<SalutationDTO>> UpdateSalutationAsync([FromBody] SalutationDTO model)
        {
            if (model == null || model.SalutationId <= 0)
                return BadRequest();
            await _salutationService.UpdateAsync(model);
            return Ok();

            
        }
    }
}
