using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment1
{
  

    public class DirWalker
    {
        public void walk(String path, List<Customer> validCustomers)
        {

            string[] list = Directory.GetDirectories(path);


            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    //walk(dirpath);
                    Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {

                    Console.WriteLine("File:" + filepath);
            }


            try
            {
                foreach (string file in Directory.EnumerateFiles(path, "*.csv", SearchOption.AllDirectories))
                {
                    string logPath = "../../../../../ProgAssign1/logs/logs1.txt";
                    using (StreamWriter sw = File.AppendText(logPath))
                    {
                        sw.WriteLine($"{file}");
                        sw.Close();
                    }
                    SimpleCSVParser.Process(file, validCustomers);  // 传递 validCustomers 以存储有效记录








                   










                    Console.WriteLine($"Processing file: {file}");
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Error traversing directory: {ex.Message}");
            }

        }


//        public static void Main(String[] args)
//        {
//            DirWalker fw = new DirWalker();
//           fw.walk(@"/");
//        }

    }
}
