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
    public class ProductGroupController : Controller
    {
        private readonly GroupContext _context;

       public ProductGroupController(GroupContext context)
        {
            _context = context;

        }

                   [HttpGet]
            public async Task<List<Product_Group>> GetAll()
            {
                return await _context.Product_Group.ToListAsync();
            }

            public IActionResult GetById(int id)
            {
                var item = _context.Product_Group.FirstOrDefault(t => t.Id == id);
                if (item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }      
   }
}