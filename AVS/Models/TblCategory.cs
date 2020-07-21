using System;
using System.Collections.Generic;

namespace AVS.Models
{
    public partial class TblCategory
    {
        public TblCategory()
        {
            TblCandidate = new HashSet<TblCandidate>();
        }

        public int Id { get; set; }
        public string Category { get; set; }

        public ICollection<TblCandidate> TblCandidate { get; set; }
    }
}
