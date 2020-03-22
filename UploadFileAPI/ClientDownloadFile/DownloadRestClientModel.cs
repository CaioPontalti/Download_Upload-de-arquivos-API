using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientDownloadFile
{
    public class DownloadRestClientModel
    {
        //private string BASE_URL = "https://localhost:44344/api/file/";

        public async Task<string> Download(int id)
        {
            try 
            {
                string result = string.Empty;
                var httpClient = new HttpClient();
                if (id == 1)
                    result = await httpClient.GetStringAsync($"https://localhost:44344/api/file/download?id={id}");
                else
                    result = await httpClient.GetStringAsync($"https://localhost:44344/api/file/download?id={id}");

                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
