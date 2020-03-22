using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UploadFileAPI.Models;

namespace AspNetCoreMultipleUploadAPI.WebApi.Controllers
{
    [Route("api/file")]
    public class FileController : Controller
    {

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            try
            {
                var result = new List<FileUploadResult>();
                foreach (var file in files)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), @"C:\Users\PDA-Caio\Documents", file.FileName);
                    if (!System.IO.File.Exists(path))
                    {
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                            result.Add(new FileUploadResult() { Name = file.FileName, Length = file.Length });
                        }
                    }
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        [Route("download")]
        public async Task<object> Download(int id)
        {
            try
            {
                if (id == 1)
                {
                    using (var client = new HttpClient())
                    {
                        using (var result = client.GetByteArrayAsync("https://r4---sn-bg07dnlk.googlevideo.com/videoplayback?expire=1584859650&ei=orV2XpDPLOmohwa24JHAAQ&ip=2604%3A180%3A2%3A3b5%3Ac536%3A1c84%3Abc0a%3Abe13&id=o-AE8Avb9PPBJUGp3T6NZmoxfSTgGr_ED8nRmmeuucP1zG&itag=22&source=youtube&requiressl=yes&vprv=1&mime=video%2Fmp4&ratebypass=yes&dur=160.264&lmt=1507267710071790&fvip=4&c=WEB&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cvprv%2Cmime%2Cratebypass%2Cdur%2Clmt&sig=ADKhkGMwRQIgQcFJ0AyltcuHyXBymFCd4G_-KPxw1v-JOqZMVCm29bUCIQCs3kMXK-mm-snGmspACmDU1Y7i8I5U0cXo-h51F7fvUA%3D%3D&redirect_counter=1&cm2rm=sn-5ua6y7z&req_id=93b4a4cca868a3ee&cms_redirect=yes&mh=LQ&mip=2804:14c:58:92a0:b97f:d8a0:27ef:a03e&mm=34&mn=sn-bg07dnlk&ms=ltu&mt=1584837982&mv=m&mvi=3&pl=44&lsparams=mh,mip,mm,mn,ms,mv,mvi,pl&lsig=ALrAebAwRQIgdMROVJ_DGl8-N8wndJ42nAQfYbkHf7Dv4XFbWrbEDIECIQCweAQycE6c66LpuKZosmQZjGUp4RTsOpVk0iYRHIObZg%3D%3D"))
                        {
                            String base64 = Convert.ToBase64String(result.Result);

                            return await Task.FromResult(base64);
                        }
                    }
                }
                else
                {
                    using (var client = new HttpClient())
                    {
                        using (var result = client.GetByteArrayAsync("https://r2---sn-bg07dnzl.googlevideo.com/videoplayback?expire=1584869552&ei=UNx2XvG1L8OxhwaDoJ6YBg&ip=2604%3A180%3A2%3A3b5%3Ac536%3A1c84%3Abc0a%3Abe13&id=o-ANpnHHv7u0J_Pqohw1Unvu05GB5zAf9MnW3VIJb6RSnZ&itag=22&source=youtube&requiressl=yes&vprv=1&mime=video%2Fmp4&ratebypass=yes&dur=235.403&lmt=1581129026591689&fvip=2&c=WEB&txp=5535432&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cvprv%2Cmime%2Cratebypass%2Cdur%2Clmt&sig=ADKhkGMwRQIhAN9mxuGKXPaU0cdojX9PVgc7DAHbwkD7F45kmBJH2euqAiBehQHyVukIm8W49iTCJqkpEX8fame-ItE26ihUNgVZsA%3D%3D&redirect_counter=1&cm2rm=sn-5uary7l&req_id=2a75c1500068a3ee&cms_redirect=yes&mh=jd&mip=2804:14c:58:92a0:2053:702c:7108:f36e&mm=34&mn=sn-bg07dnzl&ms=ltu&mt=1584847888&mv=m&mvi=1&pl=44&lsparams=mh,mip,mm,mn,ms,mv,mvi,pl&lsig=ALrAebAwRQIhAO-F6TNv3EuLSrcbQlof42XAg5m5Al4p0ZEIkqYijUl3AiBwb87CMIK7VtlcXfpJ-aJLICrDsHeqexXg86346lpo9w%3D%3D"))
                        {
                            String base64 = Convert.ToBase64String(result.Result);

                            return await Task.FromResult(base64);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}