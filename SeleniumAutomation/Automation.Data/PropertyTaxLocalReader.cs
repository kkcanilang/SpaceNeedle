using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Automation.Data
{
    public class PropertyTaxLocalReader
    {
        public const string SERVER_NAME_KEY = "SERVERNAME";
        public const string DRIVER_KEY = "DRIVER";
        public const string USERNAME_KEY = "USERNAME";
        public const string PASSWORD_KEY = "PASSWORD";

        private static string ExecutingDirectory = Directory.GetCurrentDirectory();
        private static string FileName = "data.txt";

        public bool SaveData(string serverName, string driverFolder,string userName, string password)
        {
            try
            {
                string filePath = ExecutingDirectory + @"\" + FileName;

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, false))
                {
                    file.WriteLine(SERVER_NAME_KEY + ':' + serverName);
                    file.WriteLine(DRIVER_KEY + ':' + driverFolder);
                    file.WriteLine(USERNAME_KEY + ':' + userName);
                    file.WriteLine(PASSWORD_KEY + ':' + password);
                }
            }
            catch (Exception e) {
                return false;
            }

            return true;
        }

        public Dictionary<string,string> ReadData()
        {
            string filePath = ExecutingDirectory + @"\" + FileName;

            Dictionary<string, string> data = new Dictionary<string, string>();

            if (File.Exists(filePath))
                {
                    string[] lines = System.IO.File.ReadAllLines(filePath);

                    string currentLineRaw = string.Empty;
                    string[] keyValues = new string[0];
                    string key = string.Empty;
                    string value = string.Empty;

                    foreach (string line in lines)
                    {
                    keyValues = line.Split(new char[] {':'}, 2);
                        key = keyValues[0];
                        value = keyValues[1];
                        data.Add(key, value);
                    }
                }
            return data;

        }  
    }
}
