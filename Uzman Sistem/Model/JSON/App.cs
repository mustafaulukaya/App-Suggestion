using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzman_Sistem.Model.JSON
{
    class App
    {
        public string title { get; set; }

        public string appId { get; set; }

        public bool free { get; set; }

        public string playstoreUrl { get; set; }

        public string priceText { get; set; }

        public string scoreText { get; set; }

        public Developer developer { get; set; }
    }
}
