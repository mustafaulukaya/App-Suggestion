using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzman_Sistem.Model
{
    public class Rated
    {

        public string DeviceID { get; set; }

        public long SimilarityID { get; set; }

        public virtual Similarity Similarity { get; set; }

    }
}
