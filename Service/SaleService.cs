using Sales_Management.Interface;
using Sales_Management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales_Management.Service
{
    public class SaleService : ISaleService
    {
        private readonly IRepository<string, Sale> _saleRepository;
        public SaleService(IRepository<string, Sale> saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<Sale> CreateSale(Sale sale, string userId, bool isAdmin)
        {
            return await _saleRepository.Add(sale);
        }

        public async Task<Sale?> DeleteSale(string id, string userId, bool isAdmin)
        {
            return await _saleRepository.Delete(id);
        }

        public async Task<Sale?> GetSaleById(string id, string userId, bool isAdmin)
        {
            return await _saleRepository.Get(id);
        }

        public async Task<List<Sale>?> GetSalesByUser(string userId, bool isAdmin)
        {
            return await _saleRepository.GetAll();
        }

        public async Task<Sale?> UpdateSale(Sale sale, string userId, bool isAdmin)
        {
            return await _saleRepository.Update(sale);
        }
    }
}
