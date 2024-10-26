using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualBasic.FileIO;

namespace Assignment1
{
    public class SimpleCSVParser
    {


 //       public static void Main(String[] args)
 //       {
 //           SimpleCSVParser parser = new SimpleCSVParser();
 //           parser.parse(@"/Users/dpenny/Projects/Assignment1/Assignment1/sampleFile.csv");
 //       }


        public void parse(String fileName)
        {
            try { 
            using (TextFieldParser parser = new TextFieldParser(fileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                    foreach (string field in fields)
                    {
                        Console.WriteLine(field);
                    }
                }
            }
        
        }catch(IOException ioe){
                Console.WriteLine(ioe.StackTrace);
         }

    }
        public static void Process(string csvFilePath, List<Customer> validCustomers)
        {
            try
            {
                var lines = File.ReadAllLines(csvFilePath);
                foreach (var line in lines.Skip(1)) // 跳过标题行
                {
                    var columns = line.Split(',');
                    // 创建 Customer 对象并添加到 validCustomers 列表
                    var date1 = csvFilePath.Split('/');
                    string date_fin = $"{date1[6]}/{date1[7]}/{date1[8]}";
                    //string logPath = "../../../../../ProgAssign1/logs/logs.txt";
                    //using (StreamWriter sw = File.AppendText(logPath))
                    //{
                    //    sw.WriteLine($"{date_fin}");
                    //    sw.Close();
                    //}

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
                        Date = date_fin
                       
                        //Date = DateTime.TryParse(columns[10], out DateTime date) ? date : DateTime.MinValue

                };
                    validCustomers.Add(customer);  // 将有效记录添加到列表中
                    Logger.Log($"Added valid customer: {customer.FirstName} {customer.LastName}");
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Error processing file {csvFilePath}: {ex.Message}");
            }
        }


    }
}
