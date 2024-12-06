using Microsoft.AspNetCore.Mvc;
using System;
using TransactionsManagementApp.DataAccess.Entities;
using TransactionsManagementApp.DataAccess.Interface;
using TransactionsManagementApp.Model;
using static Dapper.SqlMapper;

namespace TransactionsManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTypeController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StatusTypeController> _logger;
        public StatusTypeController(IUnitOfWork unitOfWork, ILogger<StatusTypeController> logger, IStatusRepository statusRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _statusRepository = statusRepository;
        }

        [HttpGet("GetStatusById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.Status.GetByIdAsync(id);
            if (data == null)
            {
                return Ok();
            }

            return Ok(data);
        }

        [HttpGet("GetAllStatus")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _unitOfWork.Status.GetAllAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("AddStatus")]
        public async Task<IActionResult> Add(Status entity)
        {
            try
            {
                if (entity != null)
                {
                    var data = await _unitOfWork.Status.AddAsync(entity);
                    return Ok(data);
                }

                return BadRequest("Entity cannot be null.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("DeleteStatus")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _unitOfWork.Status.DeleteAsync(id);
                if (data == 0)
                {
                    return NotFound($"Status with ID {id} not found and the deletion can not be done !!");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }


        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> Update(Status entity)
        {
            try
            {
                if (entity != null)
                {
                    var data = await _unitOfWork.Status.UpdateAsync(entity);
                    return Ok(data);

                }
                return BadRequest("Entity cannot be null.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
