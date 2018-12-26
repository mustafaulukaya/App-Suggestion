using System;
using System.Collections.Generic;
using System.Configuration;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Uzman_Sistem.Model {
    public class DbContext {
        public static List<App> GetAll() {
            using (SqlConnection db = new SqlConnection(Helper.ConnectionString)) {
                if (db.State == ConnectionState.Closed) {
                    db.Open();
                }
                //var res = db.Query<User>("SELECT * FROM users", commandType: CommandType.Text).ToList();
                return null;
            }
            return null;
        }


    }
}
