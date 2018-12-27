using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzman_Sistem.Model
{
    public class Similarity
    {

        public Similarity()
        {
            this.SimilarityScore = 1;
        }

        public long ID { get; set; }

        public long App1ID { get; set; }

        public long App2ID { get; set; }

        public long SimilarityScore { get; set; }

        public string toValues()
        {
            return string.Format("({0},{1},{2})", this.App1ID, this.App2ID, this.SimilarityScore);
        }
    }
}
