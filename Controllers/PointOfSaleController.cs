using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using GolfWarehouseAPI.DTOs;
using GolfWarehouseAPI.Interfaces;

namespace GolfWarehouseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PointOfSaleController : ControllerBase
    {
        private readonly ILogger<PointOfSaleController> _logger;
        private readonly IPointOfSaleService _pointOfSaleService;

        public PointOfSaleController(ILogger<PointOfSaleController> logger, IPointOfSaleService pointOfSaleService)
        {
            _logger = logger;
            _pointOfSaleService = pointOfSaleService;
        }

        [HttpPost("transaction")]
        public async Task<IActionResult> CreatePointOfSaleTransaction(PointOfSaleTransactionDto transactionDto)
        {
            // Assuming you have 'docId' and 'price' properties in your DTO
            bool result = await _pointOfSaleService.CreateTransaction(transactionDto.DocId, transactionDto.Price);

            if (result)
            {
                return Ok("Point of sale transaction created successfully.");
            }
            else
            {
                return BadRequest("Failed to create point of sale transaction.");
            }
        }
    }
}
