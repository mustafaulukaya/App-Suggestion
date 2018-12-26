using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzman_Sistem.Model
{
    public class Similarity
    {

        public long ID { get; set; }

        public long App1ID { get; set; }

        public long App2ID { get; set; }

        public long SimilarityScore { get; set; }

        public virtual App App1 { get; set; }

        public virtual App App2 { get; set; }
    }
}
