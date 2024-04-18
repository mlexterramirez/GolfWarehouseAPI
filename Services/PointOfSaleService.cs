
using System;
using System.Threading.Tasks;
using GolfWarehouse.API;
using GolfWarehouse.Models;
using GolfWarehouseAPI.DTOs;
using GolfWarehouseAPI.Interfaces;

namespace GolfWarehouseAPI.Services
{
    public class PointOfSaleService : IPointOfSaleService
    {
        private readonly AppDbContext _dbContext;

        public PointOfSaleService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateTransaction(PointOfSaleTransactionDto transactionDto)
        {
            try
            {
                if (transactionDto != null)
                {
                    // Map DTO to Entity and save to the database
                    var transaction = new PointOfSaleTransaction
                    {
                        // Map DTO properties to entity properties
                        DocId = transactionDto.DocId,
                        ItemNo = transactionDto.ItemNo,
                        Price = transactionDto.Price,
                        // Map more properties as needed
                    };

                    _dbContext.PointOfSaleTransactions.Add(transaction);
                    await _dbContext.SaveChangesAsync();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error creating point-of-sale transaction: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> CreateTransaction(long docId, decimal price)
        {
            try
            {
                // Create a new point-of-sale transaction with the provided docId and price
                var transaction = new PointOfSaleTransaction
                {
                    DocId = docId,
                    Price = price,
                    // Set other properties as needed
                };

                _dbContext.PointOfSaleTransactions.Add(transaction);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error creating point-of-sale transaction: {ex.Message}");
                return false;
            }
        }
    }
}
