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
    public class CandidateController : ControllerBase
    {
        // GET api/values
        [HttpGet("FindAll")]
        public async Task<IActionResult> FindAll()
        {
            AVSContext avsDBContext = new AVSContext();
            var candidateList = avsDBContext.TblCandidate.ToList();
            return Ok(candidateList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CandidateById(int id)
        {
            try
            {
                AVSContext avsDBContext = new AVSContext();
                var v = avsDBContext.TblCandidate.Where(x => x.Id == id);
                if (v == null)
                    return NotFound("Candidate doesn't exist!");
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
        public async Task<IActionResult> Create([FromBody] TblCandidate candidate)
        {
            try
            {   
                AVSContext avsDBContext = new AVSContext();
                var category= avsDBContext.TblCategory.Where(x => x.Id == candidate.CategoryId).FirstOrDefault();
                if (category == null)
                    return NotFound("Category not found!");
                else
                {
                    avsDBContext.TblCandidate.Add(candidate);
                    avsDBContext.SaveChanges();
                    return Ok(candidate);
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Invalid input data!");
            }

        }
    }
}
