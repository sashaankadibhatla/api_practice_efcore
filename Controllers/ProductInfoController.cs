using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using GroupData;
using GroupData.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProductInfo.Controllers
{
    [Route("api/[controller]")]
    public class ProductInfoController : Controller
    {
        private readonly GroupContext _context;

       public ProductInfoController(GroupContext context)
        {
            _context = context;

        }

                   [HttpGet]
            public async Task<List<Product_Info>> GetAll()
            {
                return await _context.Product_Info.ToListAsync();
            }

            public IActionResult GetById(int id)
            {
                var item = _context.Product_Info.FirstOrDefault(t => t.Id == id);
                if (item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }      
   }
}