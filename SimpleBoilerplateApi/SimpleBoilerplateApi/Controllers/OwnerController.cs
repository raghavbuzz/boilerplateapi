using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SimpleBoilerplateApi.Controllers
{
    // Do not use default rout. Always create your own => X [Route("api/[controller]")] X
    [Route("api/owner")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private IRepositoryWrapper _repoWrapper;
        private IMapper _mapper;
        public OwnerController(ILoggerManager logger, IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _logger = logger;
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }

        /// <summary>
        /// [Sync] Gets all the Owners
        /// </summary>        
        [HttpGet("v1")]
        public IActionResult GetAllOwners()
        {
            try
            {
                // We could have called FindAll Directly, but we needed a sorted list (custom call related to owners)
                // var owners = _repoWrapper.Owner.FindAll();

                var owners = _repoWrapper.Owner.GetAllOwners();
                _logger.LogInfo($"Returned all owners from database.");

                var ownerResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);

                int num = Convert.ToInt32("a");

                return Ok(ownerResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// [Sync] Gets Owners by Id
        /// </summary>
        [HttpGet("v1/{id}", Name ="OwnerById")]
        public IActionResult GetOwnerById(long id)
        {
            try
            {
                var owner = _repoWrapper.Owner.GetOwnerById(id);

                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");

                    var ownerResult = _mapper.Map<OwnerDto>(owner);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// [Sync] Gets Owners with Account detail by Id
        /// </summary>
        [HttpGet("v1/{id}/account")]
        public IActionResult GetOwnerWithDetails(long id)
        {
            try
            {
                var owner = _repoWrapper.Owner.GetOwnerWithDetails(id);

                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with details for id: {id}");

                    var ownerResult = _mapper.Map<OwnerDto>(owner);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// [Sync] Creates new Owners
        /// </summary>
        [HttpPost("v1")]
        public IActionResult CreateOwner([FromBody]OwnerForCreationDto ownerDto)
        {
            try
            {
                if (ownerDto == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var ownerEntity = _mapper.Map<Owner>(ownerDto);

                _repoWrapper.Owner.CreateOwner(ownerEntity);
                _repoWrapper.Save();

                var createdOwner = _mapper.Map<OwnerDto>(ownerEntity);

                return CreatedAtRoute("OwnerById", new { id = createdOwner.Id }, createdOwner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// [Sync] Updates an existing Owners by Id
        /// </summary>
        [HttpPut("v1/{id}")]
        public IActionResult UpdateOwner(long id, [FromBody]OwnerForUpdateDto ownerDto)
        {
            try
            {
                if (ownerDto == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var ownerEntity = _repoWrapper.Owner.GetOwnerById(id);
                if (ownerEntity == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(ownerDto, ownerEntity);

                _repoWrapper.Owner.UpdateOwner(ownerEntity);
                _repoWrapper.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// [Sync] Deletes Owners by Id
        /// </summary>
        [HttpDelete("v1/{id}")]
        public IActionResult DeleteOwner(long id)
        {
            try
            {
                var owner = _repoWrapper.Owner.GetOwnerById(id);
                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                if (_repoWrapper.Account.AccountsByOwner(id).Any())
                {
                    _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                    return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
                }

                _repoWrapper.Owner.DeleteOwner(owner);
                _repoWrapper.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// [Async] Gets all the Owners
        /// </summary>     
        [HttpGet("v2")]
        public async Task<IActionResult> GetAllOwnersAsync()
        {
            try
            {
                var owners = await _repoWrapper.Owner.GetAllOwnersAsync();
                _logger.LogInfo($"Returned all owners from database.");

                var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
                return Ok(ownersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// [Async] Gets Owners by Id
        /// </summary>
        [HttpGet("v2/{id}", Name = "OwnerByIdAsync")]
        public async Task<IActionResult> GetOwnerByIdAsync(long id)
        {
            try
            {
                var owner = await _repoWrapper.Owner.GetOwnerByIdAsync(id);
                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");

                    var ownerResult = _mapper.Map<OwnerDto>(owner);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// [Async] Gets Owners with Account detail by Id
        /// </summary>
        [HttpGet("v2/{id}/account")]
        public async Task<IActionResult> GetOwnerWithDetailsAsync(long id)
        {
            try
            {
                var owner = await _repoWrapper.Owner.GetOwnerWithDetailsAsync(id);
                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with details for id: {id}");

                    var ownerResult = _mapper.Map<OwnerDto>(owner);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// [Async] Creates new Owners
        /// </summary>
        [HttpPost("v2")]
        public async Task<IActionResult> CreateOwnerAsync([FromBody]OwnerForCreationDto ownerDto)
        {
            try
            {
                if (ownerDto == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var ownerEntity = _mapper.Map<Owner>(ownerDto);

                _repoWrapper.Owner.CreateOwner(ownerEntity);
                await _repoWrapper.SaveAsync();

                var createdOwner = _mapper.Map<OwnerDto>(ownerEntity);

                return CreatedAtRoute("OwnerByIdAsync", new { id = createdOwner.Id }, createdOwner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// [Async] Updates an existing Owners by Id
        /// </summary>
        [HttpPut("v2/{id}")]
        public async Task<IActionResult> UpdateOwnerAsync(long id, [FromBody]OwnerForUpdateDto ownerDto)
        {
            try
            {
                if (ownerDto == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var ownerEntity = await _repoWrapper.Owner.GetOwnerByIdAsync(id);
                if (ownerEntity == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(ownerDto, ownerEntity);

                _repoWrapper.Owner.UpdateOwner(ownerEntity);
                await _repoWrapper.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// [Async] Deletes Owners by Id
        /// </summary>
        [HttpDelete("v2/{id}")]
        public async Task<IActionResult> DeleteOwnerAsync(long id)
        {
            try
            {
                var owner = await _repoWrapper.Owner.GetOwnerByIdAsync(id);
                if (owner == null)
                {
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                if (_repoWrapper.Account.AccountsByOwner(id).Any())
                {
                    _logger.LogError($"Cannot delete owner with id: {id}. It has related accounts. Delete those accounts first");
                    return BadRequest("Cannot delete owner. It has related accounts. Delete those accounts first");
                }

                _repoWrapper.Owner.DeleteOwner(owner);
                await _repoWrapper.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteOwner action: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }
    }
}