using ESApplication.Responses;
using MediatR;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net.Http.Headers;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace ESApplication
{
    public class Utilities
    {

        private readonly IWebHostEnvironment _hostingEnvironment;
        public Utilities(IWebHostEnvironment hostingEnvironment)
        {           
            _hostingEnvironment = hostingEnvironment;
        }

        public static string GetImageSrcPath(IFormCollection formCollection, string foldername)
        {
            var imageSrcPath = Path.Combine("StaticFiles", "Resources", "Images");
            formCollection.Keys.ToList().ForEach(key =>
            {
                if (formCollection[key] != "") imageSrcPath = Path.Combine(imageSrcPath, formCollection[key]);

            });
            imageSrcPath = Path.Combine(imageSrcPath, foldername);
            return imageSrcPath;
        }

        public static List<string> UploadImages(IFormFileCollection Images, string ImagePath, IWebHostEnvironment _hostingEnvironment)
        {
            List<string> imageNames = new List<string>();

            try
            {
                foreach (var file in Images)
                {
                    string fullPath = Path.Combine(_hostingEnvironment.WebRootPath, ImagePath);
                    if (!Directory.Exists(fullPath))
                        Directory.CreateDirectory(fullPath);
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    fullPath = Path.Combine(fullPath, fileName);

                    var buffer = 1024 * 1024;
                    using var stream = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, buffer, useAsync: false);
                    file.CopyTo(stream);
                    stream.Flush();

                    if (System.IO.File.Exists(fullPath))
                    {
                        imageNames.Add(fileName);
                    }

                    

                }

                return imageNames;

            }
            catch (Exception ex)
            {
                return imageNames;

            }
        }            


        

    }
}