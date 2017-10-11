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
    public class ProductGroupController : Controller,IProductGroupService
    {
        private readonly GroupContext _context;

       public ProductGroupController(GroupContext context)
        {
            _context = context;

        }

                   [HttpGet]
            public async Task<List<Product_Group>> GetAllAsync()
            {
                return await _context.Product_Group.ToListAsync();
            }
                [HttpGet("{id}", Name = "Getgroup")]
       public async Task<List<Product_Group>> GetByIdAsync(int id)
       {
            Product_Group objectProductInfo = await _context.Product_Group.FindAsync(id);
            List<Product_Group> product = new List<Product_Group>();
           try
           {
                product.Add(objectProductInfo);
           }catch(Exception ex){
               throw new Exception(ex.Message);
           }
           return product;
       }

        [HttpPost]
        public async Task CreateAsync([FromBody] Product_Group item)
        {
            try
            {
                _context.Product_Group.Add(item);
                await _context.SaveChangesAsync();
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }    
        }

        [HttpPut("{id}",Name="Getgroup")]
        public async Task UpdateAsync(int id, [FromBody] Product_Group item)
        {
            var result = _context.Product_Group.FirstOrDefault(t => t.Id == id);
            result.Id=item.Id;
            result.Name=item.Name;
            try
            {
                _context.Product_Group.Update(result);
                await _context.SaveChangesAsync();
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }    
        }


        [HttpDelete("{id}",Name="Getgroup")]
        public async Task DeleteAsync(int id)
        {
            var result = _context.Product_Group.FirstOrDefault(t => t.Id == id);
            try
            {
                _context.Product_Group.Remove(result);
                await _context.SaveChangesAsync();
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }    
        }     
    }     
     }