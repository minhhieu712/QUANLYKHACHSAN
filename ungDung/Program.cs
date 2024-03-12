﻿using DataLayer;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using THUEPHONG;

namespace ungDung
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists("connectdb.dba"))
            {
                string conStr = "";
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.Open("connectdb.dba", FileMode.Open, FileAccess.Read);
                connect cp = (connect)bf.Deserialize(fs);
                string servername = Encryptor.Decrypt(cp.servername, "qwertyuiop", true);
                string username = Encryptor.Decrypt(cp.username, "qwertyuiop", true);
                string pass = Encryptor.Decrypt(cp.passwd, "qwertyuiop", true);
                string database = Encryptor.Decrypt(cp.database, "qwertyuiop", true);
                conStr += "Data Source=" + servername + ";Initial Catalog=HOTELS ; User ID=" + username + "; Password=" + pass + ";Integrated Security=True;";
                connoi = conStr;
                //myFunction._srv = servername;
                //myFunction._us = username;
                //myFunction._pw = passwd;
                //myFunction._db = database;
                SqlConnection con = new SqlConnection(conStr);
              
                try
                {
                    con.Open();
                 

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể kết nối CSDL" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fs.Close();
                }
                con.Close();
                fs.Close();
                Application.Run(new frmMain());

            }
            else {   
                Application.Run(new frmKetNoiDB());
            }
        }
        public static string connoi = "";
    }
}
