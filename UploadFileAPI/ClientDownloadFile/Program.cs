using System;
using System.IO;
using System.Threading;

namespace ClientDownloadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sleep for 3 seconds.");
            Thread.Sleep(3000);
            try
            {
                int id = 1;
                var uploadRestClientModel = new DownloadRestClientModel();
                var result = uploadRestClientModel.Download(id).Result;

                byte[] ret = Convert.FromBase64String(result);
                FileInfo fil;
                if (id==1)
                    fil = new FileInfo(@"C:\Temp\Novo\capitao.mp4");
                else
                    fil = new FileInfo(@"C:\Temp\Novo\velozes.mp4");

                using (Stream sw = fil.OpenWrite())
                {
                    sw.Write(ret, 0, ret.Length);
                    sw.Close();
                }

                Console.WriteLine("File size: " + result.Length);
                Console.WriteLine("====================");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               
            }

            Console.ReadLine();

        }
    }
}
