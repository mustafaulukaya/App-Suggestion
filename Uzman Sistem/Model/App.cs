using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzman_Sistem.Model
{
    public class App
    {
        public App()
        {
            SimilarApps = new List<App>();
        }

        public long ID { get; set; }
        
        public string AppPackageName { get; set; }

        public string Title { get; set; }

        public bool isFree { get; set; }

        public string playstoreUrl { get; set; }

        public string priceText { get; set; }

        public string AppScore { get; set; }

        public virtual ICollection<App> SimilarApps { get; set; }

    }
}
