using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS.Models
{
    public class VotingDTO
    {
        public int VID { get; set; }
        public int CID { get; set; }
        public bool IsValid { get; set; }
    }
}
