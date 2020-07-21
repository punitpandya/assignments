using System;
using System.Collections.Generic;

namespace AVS.Models
{
    public partial class TblVoterDetail
    {
        public int Id { get; set; }
        public int Vid { get; set; }
        public int Cid { get; set; }

        public TblVoter C { get; set; }
    }
}
