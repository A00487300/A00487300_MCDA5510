using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment1
{
    // 修改: 添加日期字段
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Date { get; set; }  // 修改: 添加日期字段
    }



    public class Exceptions
    {

        static void Main()
        {
            //test_e.teste();
            //test1.test();


            var startTime = DateTime.Now;
            string directoryPath = "../../../../../Sample Data";  // 替换为你实际的CSV文件目录路径
            List<Customer> validCustomers = new List<Customer>();
            try
            {
                DirWalker walker = new DirWalker();  // 实例化 DirWalker
                walker.walk(directoryPath, validCustomers);  // 调用实例方法

                string outputPath = "../../../../../ProgAssign1/Output/results.csv";  // 设置输出文件路径
                OutputWriter.WriteResults(outputPath, validCustomers);  // 调用WriteResults方法

                var executionTime = DateTime.Now - startTime;
                Logger.Log($"Total Execution Time: {executionTime.TotalSeconds} seconds");
                Logger.Log($"Total Valid Rows: {validCustomers.Count}");
            }
            catch (Exception ex)
            {
                Logger.Log($"An unexpected error occurred: {ex.Message}");
            }
        }


        static StreamWriter OpenStream(string path)
        {
            if (path is null)
            {
                Console.WriteLine("You did not supply a file path.");
                return null;
            }

            try
            {
                var fs = new FileStream(path, FileMode.CreateNew);
                return new StreamWriter(fs);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive specified in 'path' is invalid.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("'path' exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create this file.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                Console.WriteLine("There is a sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                Console.WriteLine("The file already exists.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
            return null;
        }

    }

    public class save
    {
        public static void save1()
        {
            //var sw = OpenStream(@".\sampleFile.csv");
            //if (sw is null)
            //    return;
            //sw.WriteLine("This is the first line.");
            //sw.WriteLine("This is the second line.");
            //sw.Close();

            var startTime = DateTime.Now;
            //string directoryPath = "../../../../../Sample Data";  // 替换为你实际的CSV文件目录路径
            List<Customer> validCustomers = new List<Customer>();

            try
            {
                DirWalker walker = new DirWalker();  // 实例化 DirWalker
                //walker.walk(directoryPath);  // 调用实例方法

                string outputPath = "../../../../../ProgAssign1/Output/results.csv";  // 设置输出文件路径
                OutputWriter.WriteResults(outputPath, validCustomers);  // 调用WriteResults方法

                var executionTime = DateTime.Now - startTime;
                Logger.Log($"Total Execution Time: {executionTime.TotalSeconds} seconds");
                Logger.Log($"Total Valid Rows: {validCustomers.Count}");
            }
            catch (Exception ex)
            {
                Logger.Log($"An unexpected error occurred: {ex.Message}");
            }
        }
    }

    public class test1
    {
        public static void test()
        {
            string logPath = "../../../../../ProgAssign1/logs/log.txt";
            using (StreamWriter sw = File.AppendText(logPath))
            {
                sw.WriteLine($"hahaha");
                sw.Close();
            }

        }
    }

    public class test_e
    {
        public static void teste() {
            List<Customer> validCustomers = new List<Customer>();
            var lines = File.ReadAllLines("../../../../../Sample Data/2017/11/20/CustomerData4.csv");
            foreach (var line in lines.Skip(1)) // 跳过标题行
            {

                var columns = line.Split(',');
                // 创建 Customer 对象并添加到 validCustomers 列表
                // 检查数据是否完整，如果不完整则跳过

                var customer = new Customer
                {
                    FirstName = columns[0],
                    LastName = columns[1],
                    StreetNumber = columns[2],
                    Street = columns[3],
                    City = columns[4],
                    Province = columns[5],
                    Country = columns[6],
                    PostalCode = columns[7],
                    PhoneNumber = columns[8],
                    EmailAddress = columns[9],
                    //Date = DateTime.TryParse(columns[10], out DateTime date) ? date : DateTime.MinValue

                };
                using (StreamWriter sw = File.AppendText("../../../../../ProgAssign1/logs/logs.txt"))
                {
                    //sw.WriteLine($"{line}");
                    sw.WriteLine($"{columns[0]}");
                    sw.WriteLine($"{columns[1]}");
                    sw.WriteLine($"{columns[2]}");
                    sw.WriteLine($"{columns[3]}");
                    sw.WriteLine($"{columns[4]}");
                    sw.WriteLine($"{columns[5]}");
                    sw.WriteLine($"{columns[6]}");
                    sw.WriteLine($"{columns[7]}");
                    sw.WriteLine($"{columns[8]}");
                    sw.WriteLine($"{columns[9]}");
                    sw.Close();
                }
                
                 string outputPath = "../../../../../ProgAssign1/Output/results.csv";  // 设置输出文件路径
                 validCustomers.Add(customer);
                 OutputWriter.WriteResults(outputPath, validCustomers);  // 调用WriteResults方法
                
            }
        }
    }

    public class Logger
    {
        public static void Log(string message)
        {
            string logPath = "../../../../../ProgAssign1/logs/log.txt";  // 修改: 确保日志文件路径正确
            try
            {
                using (StreamWriter sw = File.AppendText(logPath))
                {
                    sw.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)  // 修改: 捕获日志写入错误
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");  // 修改: 如果日志写入失败，输出到控制台
            }
        }

    }

    // 修改: 新增类，用于将结果输出到文件中
    public class OutputWriter
    {
        public static void WriteResults(string outputPath, List<Customer> customers)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));  // 确保输出文件夹存在

            using (StreamWriter sw = new StreamWriter(outputPath))
            {
                sw.WriteLine("FirstName,LastName,StreetNumber,Street,City,Province,Country,PostalCode,PhoneNumber,EmailAddress,Date");

                foreach (var customer in customers)
                {
                    sw.WriteLine($"{customer.FirstName},{customer.LastName},{customer.StreetNumber},{customer.Street},{customer.City},{customer.Province},{customer.Country},{customer.PostalCode},{customer.PhoneNumber},{customer.EmailAddress}, {customer.Date}");
                }
            }

            Logger.Log($"Results written to {outputPath}");
        }
    }




}
