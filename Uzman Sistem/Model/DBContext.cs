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

                    var sql = "INSERT INTO app (apppackagename, title, isfree, playstoreurl, pricetext, appscore) VALUES" + entity.toValues();

                    db.Query<App>(sql , commandType: CommandType.Text);
                    return true;
                } catch (Exception e) {
                    return false;
                }
            }
        }


        public Similarity GetSimilarity(long ID) {
            return GetSimilarities(op => op.ID == ID).FirstOrDefault();
        }

        public List<Similarity> GetSimilarities(Expression<Func<Similarity, bool>> expression = null) {
            using (NpgsqlConnection db = new NpgsqlConnection(Helper.ConnectionString)) {
                if (db.State == ConnectionState.Closed) {
                    db.Open();
                }
                var list = db.Query<Similarity>("SELECT * FROM similarity", commandType: CommandType.Text).AsQueryable();

                if (expression != null)
                    list = list.Where(expression);

                return list.ToList();
            }
        }

        public bool UpdateSimilarity(Similarity entity) {
            using (NpgsqlConnection db = new NpgsqlConnection(Helper.ConnectionString)) {
                if (db.State == ConnectionState.Closed) {
                    db.Open();
                }

                try
                {
                    if (GetSimilarities(op => op.App2ID == entity.App2ID).Any())
                    {
                        db.Query<Similarity>("UPDATE similarity SET similarityscore = (similarityscore + 1) WHERE app1id = " + entity.App1ID + " AND app2id = " + entity.App2ID, commandType: CommandType.Text);
                    }
                    else
                    {
                        db.Query<Similarity>("INSERT INTO similarity(app1id, app2id, similarityscore) VALUES" + entity.toValues(), commandType: CommandType.Text);
                    }

                    return true;
                } catch (Exception e) {
                    return false;
                }
            }
        }

        /******************************************************************/
        public Rated GetRate(string DeviceID) {
            return GetRates(op => op.DeviceID == DeviceID).FirstOrDefault();
        }

        public List<Rated> GetRates(Expression<Func<Rated, bool>> expression = null) {
            using (NpgsqlConnection db = new NpgsqlConnection(Helper.ConnectionString)) {
                if (db.State == ConnectionState.Closed) {
                    db.Open();
                }
                var list = db.Query<Rated>("SELECT * FROM rated", commandType: CommandType.Text).AsQueryable();

                if (expression != null)
                    list = list.Where(expression);

                return list.ToList();
            }
        }

        public bool UpdateRate(Rated entity) {
            using (NpgsqlConnection db = new NpgsqlConnection(Helper.ConnectionString)) {
                if (db.State == ConnectionState.Closed) {
                    db.Open();
                }

                try {
                    db.Query<Rated>("INSERT INTO rated(deviceid, similarityid) VALUES"+ entity.toValues(), commandType: CommandType.Text);
                    return true;
                } catch (Exception e) {
                    return false;
                }
            }
        }
    }
}