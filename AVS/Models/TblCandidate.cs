using System;
using System.Collections.Generic;

namespace AVS.Models
{
    public partial class TblCandidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public TblCategory Category { get; set; }
    }
}
