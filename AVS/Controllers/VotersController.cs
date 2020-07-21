using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AVS.Models;
using Microsoft.AspNetCore.Mvc;

namespace AVS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotersController : ControllerBase
    {
        // GET api/values
        [HttpGet("FindAll")]
        public async Task<IActionResult> FindAll()
        {
            AVSContext avsDBContext = new AVSContext();
            var voterList = avsDBContext.TblVoter.ToList();
            return Ok(voterList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> voterById(int id)
        {
            try
            {
                AVSContext avsDBContext = new AVSContext();
                var v = avsDBContext.TblVoter.Where(x => x.Id == id);
                if (v == null)
                    return NotFound("Voter doesn't exist!");
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
        public async Task<IActionResult> Create([FromBody] TblVoter voter)
        {
            if (voter.Age < 18)
                return BadRequest("Voter is not eligible to vote !");
            else
            {
                AVSContext avsDBContext = new AVSContext();
                avsDBContext.TblVoter.Add(voter);
                avsDBContext.SaveChanges();
                return Ok(voter);
            }
        }
    }
}
