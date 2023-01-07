using CsvHelper;
using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdPartLibrary
{
    public class Address
    {
        public static string AddressFilePath = @"E:\\New folder\\ThirdPartLibrary\\ThirdPartLibrary\\Utility\\Address.csv";
        public static string ImportFilePath = @"E:\\New folder\\ThirdPartLibrary\\ThirdPartLibrary\\Utility\\Import.csv";
        public static void ThirdParty()
        {
            using(var reader = new StreamReader(AddressFilePath))
            using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressModel>().ToList();
                Console.WriteLine("Read data from csvFile");
                foreach(AddressModel address in records)
                {
                    Console.WriteLine("\n" + address.FirstName);
                    Console.WriteLine("\n" + address.LastName);
                    Console.WriteLine("\n" + address.MobileNumber);
                    Console.WriteLine("\n" + address.Address);
                }
                using(var writer = new StreamWriter(ImportFilePath)) 
                    using(var csvImport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvImport.WriteRecords(records);
                }


            }

            
        }
            
    }
}
