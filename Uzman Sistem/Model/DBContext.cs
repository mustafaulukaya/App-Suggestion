using System;
using System.Collections.Generic;
using System.Configuration;
using Dapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;
using Npgsql;

namespace Uzman_Sistem.Model {
    //Veri tabanı işlemleri bu sınıf üzerinden gerçekleştirilir.
    public class DbContext {

        public App GetApp(long ID) {
            return GetApps(op => op.ID == ID).FirstOrDefault();
        }

        public List<App> GetApps(Expression<Func<App, bool>> expression = null) {
            using (NpgsqlConnection db = new NpgsqlConnection(Helper.ConnectionString)) {
                if (db.State == ConnectionState.Closed) {
                    db.Open();
                }
                var list = db.Query<App>("SELECT * FROM app", commandType: CommandType.Text).AsQueryable();

                if (expression != null)
                    list = list.Where(expression);

                return list.ToList();
            }
        }

        public bool UpdateApp(App entity) {
            using (NpgsqlConnection db = new NpgsqlConnection(Helper.ConnectionString)) {
                if (db.State == ConnectionState.Closed) {
                    db.Open();
                }

                try {

                    var sql = "INSERT INTO app (apppackagename, title, isfree, playstoreurl, pricetext, appscore, similarcount) VALUES" + entity.toValues();

                    db.Query<App>(sql, commandType: CommandType.Text);
                    return true;
                } catch (Exception e) {
                    return false;
                }
            }
        }

        public bool IncrementSimilarCount(string packageName) {
            using (NpgsqlConnection db = new NpgsqlConnection(Helper.ConnectionString)) {
                if (db.State == ConnectionState.Closed) {
                    db.Open();
                }

                try {
                    var entity = GetApps(op => op.AppPackageName == packageName).FirstOrDefault();
                    var sql = "UPDATE app SET similarcount=similarcount+1 WHERE id=" + entity.ID;

                    db.Query<App>(sql, commandType: CommandType.Text);
                    return true;
                } catch (Exception e) {
                    return false;
                }
            }
        }


        /******************************************************************/
        public Like GetLike(string DeviceID) {
            return GetLikes(op => op.deviceid == DeviceID).FirstOrDefault();
        }

        public List<Like> GetLikes(Expression<Func<Like, bool>> expression = null) {
            using (NpgsqlConnection db = new NpgsqlConnection(Helper.ConnectionString)) {
                if (db.State == ConnectionState.Closed) {
                    db.Open();
                }
                var list = db.Query<Like>("SELECT * FROM like", commandType: CommandType.Text).AsQueryable();

                if (expression != null)
                    list = list.Where(expression);

                return list.ToList();
            }
        }

        public bool UpdateLike(Like entity) {
            using (NpgsqlConnection db = new NpgsqlConnection(Helper.ConnectionString)) {
                if (db.State == ConnectionState.Closed) {
                    db.Open();
                }

                try {
                    db.Query<Like>("INSERT INTO rated(deviceid, appid, liked) VALUES"+ entity.toValues(), commandType: CommandType.Text);
                    return true;
                } catch (Exception e) {
                    return false;
                }
            }
        }

    }
}