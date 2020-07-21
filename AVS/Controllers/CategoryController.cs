using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AVS.Models;
using Microsoft.AspNetCore.Mvc;

namespace AVS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // GET api/values
        [HttpGet("FindAll")]
        public async Task<IActionResult> FindAll()
        {
            AVSContext avsDBContext = new AVSContext();
            var categoryList = avsDBContext.TblCategory.ToList();
            return Ok(categoryList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CategoryById(int id)
        {
            try
            {
                AVSContext avsDBContext = new AVSContext();
                var v = avsDBContext.TblCategory.Where(x => x.Id == id);
                if (v == null)
                    return NotFound("Category doesn't exist!");
                else
                    return Ok(v);
            }
            catch (Exception ex)
            {
                return BadRequest("Input data is not correct");
            }
        }
        // POST api/values
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] TblCategory category)
        {
            try
            {
                AVSContext avsDBContext = new AVSContext();                 
                avsDBContext.TblCategory.Add(category);
                avsDBContext.SaveChanges();
                return Ok(category);
            }
            catch(Exception ex)
            {
                return BadRequest("Invalid input data!");
            }

        }
    }
}
