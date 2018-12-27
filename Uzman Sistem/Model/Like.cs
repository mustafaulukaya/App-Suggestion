using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uzman_Sistem.Model {
    //Kullanıcıya verilen önerinin, kullanıcının beğenip 
    //beğenmediği bilgisi için oluşturulan sınıf
    public class Like {
        public string deviceid { get; set; }

        public long appid { get; set; }

        public bool liked { get; set; }

        public string toValues() {
            return string.Format("('{0}',{1},{2})",deviceid,appid,this.liked );
        }
    }
}
