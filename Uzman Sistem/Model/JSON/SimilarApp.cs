using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzman_Sistem.Model.JSON
{
    class SimilarApp
    {
        public string url { get; set; }

        public string appID { get; set; }

        public string title { get; set; }

        public string summary { get; set; }

        public Developer developer { get; set; }

        public string developerId { get; set; }

        public string icon { get; set; }

        public int score { get; set; }

        public string scoreText { get; set; }

        public string priceText { get; set; }

        public bool free { get; set; }

        public string playstoreUrl { get; set; }

        public string permissions { get; set; }

        public string similar { get; set; }

        public string reviews { get; set; }
        
    }
}
