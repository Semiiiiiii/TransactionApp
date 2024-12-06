using Microsoft.AspNetCore.Mvc;
using TransactionsManagementApp.DataAccess.Entities;
using TransactionsManagementApp.DataAccess.Interface;

namespace TransactionsManagementApp.Controllers
{
    public class TransactionTypeController : ControllerBase
    {
        private readonly ITransactionTypeRepository _TransactionTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TransactionTypeController> _logger;
        public TransactionTypeController(IUnitOfWork unitOfWork, ILogger<TransactionTypeController> logger, ITransactionTypeRepository TransactionTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _TransactionTypeRepository = TransactionTypeRepository;
        }


        [HttpGet("GetTransactionTypeById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.TransactionType.GetByIdAsync(id);
            if (data == null)
            {
                return Ok();
            }

            return Ok(data);
        }

        [HttpGet("GetAllTransactionType")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _unitOfWork.TransactionType.GetAllAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("AddTransactionType")]
        public async Task<IActionResult> Add(TransactionType entity)
        {
            try
            {
                if (entity != null)
                {
                    var data = await _unitOfWork.TransactionType.AddAsync(entity);
                    return Ok(data);
                }

                return BadRequest("Entity cannot be null.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("DeleteTransactionType")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _unitOfWork.TransactionType.DeleteAsync(id);
                if (data == 0)
                {
                    return NotFound($"TransactionType with ID {id} not found and the deletion can not be done !!");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }


        [HttpPut("UpdateTransactionType")]
        public async Task<IActionResult> Update(TransactionType entity)
        {
            try
            {
                if (entity != null)
                {
                    var data = await _unitOfWork.TransactionType.UpdateAsync(entity);
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
