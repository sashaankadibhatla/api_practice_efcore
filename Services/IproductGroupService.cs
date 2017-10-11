using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GroupData.Models;

namespace groupservice{

    public interface IProductGroupService{
        Task CreateAsync (Product_Group product);
        Task<List<Product_Group>> GetByIdAsync(int id);

        Task<List<Product_Group>> GetAllAsync();
        Task UpdateAsync(int id,Product_Group product);

        Task DeleteAsync(int id);

     }
}