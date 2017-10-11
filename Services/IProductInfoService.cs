using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroupData.Models;

namespace groupservice{

    public interface IProductInfoService{
        Task CreateAsync (Product_Info product);
        Task<List<Product_Info>> GetByIdAsync(int id);

        Task<List<Product_Info>> GetAllAsync();
        Task UpdateAsync(int id,Product_Info product);

        Task DeleteAsync(int id);

     }
}