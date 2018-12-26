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

namespace Uzman_Sistem.Model {
    public class DbContext {
        
        public static App GetApp(long ID)
        {
            return GetApps(op => op.ID == ID).FirstOrDefault();
        }

        public static List<App> GetApps(Expression<Func<App, bool>> expression = null)
        {
            using (SqlConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                var list = db.Query<App>("SELECT * FROM App", commandType: CommandType.Text).AsQueryable();

                if (expression != null)
                    list = list.Where(expression);

                return list.ToList();
            }
        }

        public static bool UpdateApp(App entity)
        {
            using (SqlConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                
                try
                {
                    db.Query<App>("INSERT INTO App(AppPackageName, Title, isFree, playstoreUrl, priceText, AppScore) VALUES(" + entity.AppPackageName + "," + entity.Title +"," + entity.isFree + "," + entity.playstoreUrl + "," + entity.priceText + "," + entity.AppScore+ ")", commandType: CommandType.Text);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }


        /******************************************************************/

        public static Similarity GetSimilarity(long ID)
        {
            return GetSimilarities(op => op.ID == ID).FirstOrDefault();
        }

        public static List<Similarity> GetSimilarities(Expression<Func<Similarity, bool>> expression = null)
        {
            using (SqlConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                var list = db.Query<Similarity>("SELECT * FROM Similarity", commandType: CommandType.Text).AsQueryable();

                if (expression != null)
                    list = list.Where(expression);

                return list.ToList();
            }
        }

        public static bool UpdateSimilarity(Similarity entity)
        {
            using (SqlConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                try
                {
                    db.Query<Similarity>("INSERT INTO Similarity(App1ID, App2ID, SimilarityScore) VALUES(" + entity.App1ID + "," + entity.App2ID + "," + entity.SimilarityScore + ")", commandType: CommandType.Text);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        /******************************************************************/
        public static Rated GetRate(string DeviceID)
        {
            return GetRates(op => op.DeviceID == DeviceID).FirstOrDefault();
        }

        public static List<Rated> GetRates(Expression<Func<Rated, bool>> expression = null)
        {
            using (SqlConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                var list = db.Query<Rated>("SELECT * FROM Rated", commandType: CommandType.Text).AsQueryable();

                if (expression != null)
                    list = list.Where(expression);

                return list.ToList();
            }
        }

        public static bool UpdateRate(Rated entity)
        {
            using (SqlConnection db = new SqlConnection(Helper.ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }

                try
                {
                    db.Query<Rated>("INSERT INTO Rated(DeviceID, SimilarityID) VALUES(" + entity.DeviceID + "," + entity.SimilarityID + ")", commandType: CommandType.Text);
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
    }
}
