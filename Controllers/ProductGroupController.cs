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
                [HttpGet("{id}", Name = "Getgroup")]
            public IActionResult GetById(int id)
            {
                var item = _context.Product_Group.FirstOrDefault(t => t.Id == id);
                if (item == null)
                {
                    return NotFound();
                }
                return new ObjectResult(item);
            }
            [HttpPost]
            public IActionResult Create([FromBody] Product_Group item)
            {
            if (item == null)
            {
            return BadRequest();
            }

            _context.Product_Group.Add(item);
             _context.SaveChanges();

            return CreatedAtRoute("Getgroup", new { id = item.Id }, item);
            } 
                    [HttpPut("{id}", Name= "Getgroup")]
                    public IActionResult Update(long id, [FromBody] Product_Group item)
                    {
                    if (item == null || item.Id != id)
                    {
                    return BadRequest();
                    }
                    var infos = _context.Product_Group.FirstOrDefault(t => t.Id == id);
                    if (infos == null)
                    {
                    return NotFound();
                    }
                    infos.Id=item.Id;
                    infos.Name = item.Name;
                    _context.Product_Group.Update(infos);
                    _context.SaveChanges();
                    return new NoContentResult();
                    }      
    }     
     }