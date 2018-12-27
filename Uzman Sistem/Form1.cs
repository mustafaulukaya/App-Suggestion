﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using Uzman_Sistem.Model.JSON;
using Uzman_Sistem.Model;
using System.Threading;
using System.Diagnostics;

namespace Uzman_Sistem
{
    public partial class Form1 : Form
    {
        System.Diagnostics.Process APIProcess;
        DbContext dbContext;
        public Form1()
        {
            InitializeComponent();
            dbContext = new DbContext();
            start_API();
        }

        private string getDeviceId() {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo stratInfo = new System.Diagnostics.ProcessStartInfo();
            stratInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            stratInfo.FileName = "cmd.exe";
            stratInfo.Arguments = "/C adb devices";
            process.StartInfo = stratInfo;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
           
            process.WaitForExit();
            string temp = process.StandardOutput.ReadToEnd();

            string [] res = temp.Split('\r','\n');
             
            return res[2].Substring(0, res[2].Length - 7);
        }

        private void findPhone_button_Click(object sender, EventArgs e)
        {

            string deviceId = getDeviceId();


            fetchpackages();
            
            if (File.Exists("packages_name.txt"))
            {
                FileStream fs = new FileStream("packages_name.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                var line = sr.ReadLine();

                while (!string.IsNullOrEmpty(line))
                {
                
                    if (!isExistInDatabase(line))
                    {
                        

                        updateDatabase(line);

                    }
                    
                    line = sr.ReadLine();
                }

            }else{
                MessageBox.Show("packages.txt does not exist");
            }
            
            
        }

        private bool isExistInDatabase(string package_name)
        {
            return dbContext.GetApps(op => op.AppPackageName == package_name).Any();
        }

        private Model.App updateAppTable(Model.JSON.App app)
        {

            dbContext.UpdateApp(new Model.App
            {
                AppPackageName = app.appId,
                Title = app.title,
                isFree = app.free,
                playstoreUrl = app.playstoreUrl,
                priceText = app.priceText,
                AppScore = app.scoreText
            });

            Debug.WriteLine(app.appId);

            return dbContext.GetApps(op => op.AppPackageName == app.appId).FirstOrDefault();
            
        }

        private void updateDatabase(string app_name)
        {

            Model.JSON.App app = GetApp(app_name);
            
            if(app != null)
            {
                var table_app = updateAppTable(app);

                List<Model.JSON.SimilarApp> similarApps = GetSimilarApps(app_name);

                foreach (var _app in similarApps)
                {
                    if (!isExistInDatabase(_app.appID))
                    {
                        updateAppTable(new Model.JSON.App{

                                        appId = _app.appID,
                                        developer = _app.developer,
                                        free = _app.free,
                                        playstoreUrl = _app.playstoreUrl,
                                        priceText = _app.priceText,
                                        scoreText = _app.scoreText,
                                        title = _app.title
                                    });
                    }

                    var similarapp = dbContext.GetApps(op => op.AppPackageName == _app.appID).FirstOrDefault();

                    dbContext.UpdateSimilarity(new Similarity { App1ID = table_app.ID, App2ID = similarapp.ID });
                }
            }
        }


        private Model.JSON.App GetApp(string package_name)
        {

            Model.JSON.App app;

            var request = "http://localhost:3000/api/apps/" + package_name;

            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(request);

            try
            {
                HttpWebResponse resp = (HttpWebResponse)rq.GetResponse();
                using (Stream s = resp.GetResponseStream())
                {
                    // Read the result here
                    using (StreamReader reader = new StreamReader(s))
                    {
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        var response = reader.ReadToEnd();

                        app = (Model.JSON.App)js.Deserialize(response, typeof(Model.JSON.App));

                    }

                }

                return app;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        private List<Model.JSON.SimilarApp> GetSimilarApps(string package_name)
        {

            

            Result app;

            var request = "http://localhost:3000/api/apps/" + package_name + "/similar";

            HttpWebRequest rq = (HttpWebRequest)WebRequest.Create(request);

            HttpWebResponse resp = (HttpWebResponse)rq.GetResponse();
            using (Stream s = resp.GetResponseStream())
            {
                // Read the result here
                using (StreamReader reader = new StreamReader(s))
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var response = reader.ReadToEnd();

                    app = (Result)js.Deserialize(response, typeof(Result));

                }
            }
            
            
            return app.Results;
        }


        private void stop_API() {
            APIProcess.Dispose();
        }
        
        private void start_API()
        {
            APIProcess = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo stratInfo = new System.Diagnostics.ProcessStartInfo();
            stratInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "google-play-api-master";
            stratInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            stratInfo.FileName = "cmd.exe";
            stratInfo.Arguments = "/C npm start";
            APIProcess.StartInfo = stratInfo;
            APIProcess.Start();

            Thread.Sleep(2000);
        }


        private void fetchpackages()
        {
            //var directory = AppDomain.CurrentDomain.BaseDirectory;
            if (File.Exists("packages.txt")) {
                File.Delete("packages.txt");
            }
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo stratInfo = new System.Diagnostics.ProcessStartInfo();
            stratInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            stratInfo.FileName = "cmd.exe";
            stratInfo.Arguments = "/C adb shell pm list packages -f > packages.txt";
            process.StartInfo = stratInfo;
            process.Start();

            process.WaitForExit();

            while (!File.Exists("packages.txt"));

            FileStream fs = new System.IO.FileStream("packages.txt", System.IO.FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            if (File.Exists("packages2.txt"))
            {
                File.Delete("packages2.txt");
            }

            FileStream fs2 = new System.IO.FileStream("packages2.txt", System.IO.FileMode.CreateNew);
            StreamWriter sw = new StreamWriter(fs2);

            var text = sr.ReadLine();

            while (!string.IsNullOrEmpty(text))
            {
                if(text.IndexOf("package:/system") == -1)
                {
                    sw.WriteLine(text);
                }
                text = sr.ReadLine();
                text = sr.ReadLine();
            }

            sr.Close();
            fs.Close();
            sw.Close();
            fs.Close();

            File.Delete("packages.txt");
            File.Move("packages2.txt", "packages.txt");


            if (File.Exists("packages_name.txt"))
            {
                File.Delete("packages_name.txt");
            }

            fs = new System.IO.FileStream("packages.txt", System.IO.FileMode.Open);
            sr = new StreamReader(fs);
            fs2 = new System.IO.FileStream("packages_name.txt", System.IO.FileMode.CreateNew);
            sw = new StreamWriter(fs2);


            text = sr.ReadLine();

            while (!string.IsNullOrEmpty(text))
            {

                var index = text.IndexOf("=") + 1;
                text = text.Substring(index);
                sw.WriteLine(text);
                text = sr.ReadLine();
            }

            sr.Close();
            fs.Close();
            sw.Close();
            fs.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            stop_API();
        }
    }
}
