using System.Threading.Tasks;
using GolfWarehouseAPI.DTOs;

namespace GolfWarehouseAPI.Interfaces
{
    public interface IPointOfSaleService
    {
        Task<bool> CreateTransaction(long docId, decimal price);

    }
}
