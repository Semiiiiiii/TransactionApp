using Microsoft.AspNetCore.Mvc;
using TransactionsManagementApp.DataAccess.Entities;
using TransactionsManagementApp.DataAccess.Interface;
using static Dapper.SqlMapper;

namespace TransactionsManagementApp.Controllers
{
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsRepository _TransactionsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TransactionsController> _logger;
        public TransactionsController(IUnitOfWork unitOfWork, ILogger<TransactionsController> logger, ITransactionsRepository TransactionsRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _TransactionsRepository = TransactionsRepository;
        }
        [HttpGet("GetTransactionsById")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _unitOfWork.Transactions.GetByIdAsync(id);
            if (data == null)
            {
                return Ok();
            }

            return Ok(data);
        }

        [HttpGet("GetAllTransactions")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _unitOfWork.Transactions.GetAllAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("AddTransactions")]
        public async Task<IActionResult> Add(Transactions entity)
        {
            try
            {
                if (entity != null)
                {
                    var data = await _unitOfWork.Transactions.AddAsync(entity);
                    return Ok(data);
                }

                return BadRequest("Entity cannot be null.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("DeleteTransactions")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _unitOfWork.Transactions.DeleteAsync(id);
                if (data == 0)
                {
                    return NotFound($"Transaction with ID {id} not found and the deletion can not be done !!");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }


        [HttpPut("UpdateTransactions")]
        public async Task<IActionResult> Update(Transactions entity)
        {
            try
            {
                if (entity != null)
                {
                    var data = await _unitOfWork.Transactions.UpdateAsync(entity);
                    return Ok(data);

                }
                return BadRequest("Entity cannot be null.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetTransactionSummary")]
        public async Task<IActionResult> GetSummary([FromQuery] string customerName)
        {
            try
            {
              
                var summary = await _unitOfWork.Transactions.GetTransactionSummaryAsync(customerName);

                if (summary == null)
                {
                    return NotFound("No transactions found for the provided customer name.");
                }

                return Ok(summary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
