using EmployeeRegistrationAPI.Models;
using EmployeeRegistrationAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRegistrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;
        private readonly ILogger<GenderController> _logger;
        public GenderController(IGenderService _genderService, ILogger<GenderController> _logger)
        {
            this._genderService = _genderService;
            this._logger = _logger;
            
        }
        [HttpGet]
        [Route("All", Name = "GetGender")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGenderASync()
        {
            _logger.LogInformation("GetGender method started");

           
            var response = await _genderService.GetAllAsync();
            return Ok(response);


        }

        [HttpGet]
        [Route("{id:int}", Name = "GetGenderById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<GenderDTO>> GetGenderByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }
            var response = await _genderService.GetByIdAsync(id);
            return Ok(response);

            
        }

        [HttpPost("CreateGender")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<GenderDTO>> CreateGenderAsync([FromBody] GenderDTO model)
        {
            try
            {
                await _genderService.CreateAsync(model);
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
        public async Task<ActionResult<bool>> DeleteGenderAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var response = await _genderService.DeleteAsync(id);
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
        public async Task<ActionResult<GenderDTO>> UpdateGenderAsync([FromBody] GenderDTO model)
        {
            if (model == null || model.GenderId <= 0)
                return BadRequest();
            await _genderService.UpdateAsync(model);
            return Ok();


        }

    }
}
