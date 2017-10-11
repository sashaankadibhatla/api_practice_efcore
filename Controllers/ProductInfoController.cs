using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GroupData;
using GroupData.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using groupservice;

namespace ProductInfo.Controllers
{
    [Route("api/[controller]")]
    public class ProductInfoController : Controller,IProductInfoService
    {
        private readonly GroupContext _context;

       public ProductInfoController(GroupContext context)
        {
            _context = context;

        }

                   [HttpGet]
            public async Task<List<Product_Info>> GetAllAsync()
            {
                return await _context.Product_Info.ToListAsync();
            }
                    [HttpGet("{id}", Name = "Getinfo")]
       public async Task<List<Product_Info>> GetByIdAsync(int id)
       {
            Product_Info objectProductInfo = await _context.Product_Info.FindAsync(id);
            List<Product_Info> product = new List<Product_Info>();
           try
           {
                product.Add(objectProductInfo);
           }catch(Exception ex){
               throw new Exception(ex.Message);
           }
           return product;
       }

        [HttpPost]
        public async Task CreateAsync([FromBody] Product_Info item)
        {
            try
            {
                _context.Product_Info.Add(item);
                await _context.SaveChangesAsync();
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }    
        }

        [HttpPut("{id}",Name="GetInfo")]
        public async Task UpdateAsync(int id, [FromBody] Product_Info item)
        {
            var result = _context.Product_Info.FirstOrDefault(t => t.Id == id);
            result.Id=item.Id;
            result.name=item.name;
            try
            {
                _context.Product_Info.Update(result);
                await _context.SaveChangesAsync();
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }    
        }


        [HttpDelete("{id}",Name="GetInfo")]
        public async Task DeleteAsync(int id)
        {
            var result = _context.Product_Info.FirstOrDefault(t => t.Id == id);
            try
            {
                _context.Product_Info.Remove(result);
                await _context.SaveChangesAsync();
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }    
        }   
    }
}  