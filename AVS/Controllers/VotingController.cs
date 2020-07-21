using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AVS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace AVS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotingController : ControllerBase
    {
        // POST api/values
        [HttpPost("DoVote")]
        public async Task<IActionResult> DoVote([FromBody] List<TblVoterDetail> votes)
        {
            List<VotingDTO> lstErrors = new List<VotingDTO>();
            using (AVSContext avsDBContext = new AVSContext())
            {
                using (IDbContextTransaction transaction = avsDBContext.Database.BeginTransaction())
                {   
                    try
                    {
                        foreach (TblVoterDetail vote in votes)
                        {
                            var existingVoter = avsDBContext.TblVoter.Where(x => x.Id == vote.Vid).FirstOrDefault();
                            var existingCandidate = avsDBContext.TblCandidate.Where(x => x.Id == vote.Cid).FirstOrDefault();
                            if (existingVoter==null || existingCandidate == null)
                                lstErrors.Add(new VotingDTO { CID = vote.Cid, IsValid = false, VID = vote.Vid });

                            var voteExists = avsDBContext.TblVoterDetail.Where(x => x.Vid == vote.Vid && x.Cid == vote.Cid);
                            if (voteExists != null)
                            {
                                avsDBContext.TblVoterDetail.Add(vote);
                                avsDBContext.SaveChanges();
                            }
                        }
                        if (lstErrors.Count > 0)
                        {
                            transaction.Rollback();
                            return Content("Invalid voting!");
                        }
                        else
                        {
                            transaction.Commit();
                        }
                        return Ok("Successfully Voted!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return BadRequest("Issue with the Voting!");
                    }
                }
            }
        }
    }
}
