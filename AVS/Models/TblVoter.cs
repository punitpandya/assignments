using System;
using System.Collections.Generic;

namespace AVS.Models
{
    public partial class TblVoter
    {
        public TblVoter()
        {
            TblVoterDetail = new HashSet<TblVoterDetail>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public ICollection<TblVoterDetail> TblVoterDetail { get; set; }
    }
}
