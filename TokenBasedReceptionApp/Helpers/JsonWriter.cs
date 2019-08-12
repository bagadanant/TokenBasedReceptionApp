using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TokenBasedReceptionApp.Helpers
{
    public class JsonWriter
    {

        public static string GetDataFilePath()
        {
            string folderPath = @"c:\TBR_Data";
            var directoryInfo = System.IO.Directory.CreateDirectory(folderPath);

            string fileName = string.Format("TBR_Data_{0}.", DateTime.Now.ToShortDateString());
            string pathString = System.IO.Path.Combine(folderPath, fileName);

            if (!System.IO.File.Exists(pathString))
            {
                System.IO.File.Create(pathString);
            }
            return pathString;
        }

        public static void WriteToFile(string jsondata)
        {
            System.IO.File.WriteAllText(GetDataFilePath(), jsondata);

            using (StreamWriter file = File.CreateText(@"D:\TBR_Data.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, jsondata);
            }
        }
    }
}