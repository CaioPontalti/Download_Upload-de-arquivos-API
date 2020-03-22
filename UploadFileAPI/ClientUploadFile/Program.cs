using AspNetCoreMultipleUploadAPI.ConsoleApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;

namespace ClientUploadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sleep for 3 seconds.");
            Thread.Sleep(3000);
            try
            {
                var fileInfos = new List<FileInfo>() {
                    new FileInfo(@"C:\Temp\Evidência.docx"),
                    new FileInfo(@"C:\Temp\.gitignore")
                };
                var uploadRestClientModel = new UploadRestClientModel();
                var result = uploadRestClientModel.Upload(fileInfos).Result;
                var fileResults = result.Content.ReadAsAsync<List<FileResult>>().Result;
                Console.WriteLine("Status: " + result.StatusCode);
                foreach (var fileResult in fileResults)
                {
                    Console.WriteLine("File name: " + fileResult.Name);
                    Console.WriteLine("File size: " + fileResult.Length);
                    Console.WriteLine("====================");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}
