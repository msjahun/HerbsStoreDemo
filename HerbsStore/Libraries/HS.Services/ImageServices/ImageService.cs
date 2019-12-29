
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace HerbsStore.Libraries.HS.Services.ImageServices
{
    public class ImageService : IImageService
    {

      

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHostingEnvironment _environment;


        public ImageService(IHttpContextAccessor httpContextAccessor,
            IHostingEnvironment IHostingEnvironment

           )
        {

            _httpContextAccessor = httpContextAccessor;
            _environment = IHostingEnvironment;



        }


        public string UploadProductImage()
        {
            var imagePath = UploadImage("Files/Images/Products/");
            if (imagePath == null || imagePath.Length <= 0) return null;
            //map the image to room and catalogImage in the database
            //insert it in CatalogImage, get id then
            //insert foreignkeys in RoomCatalog image

            return "/" + imagePath;

        }





     



        private string UploadImage(string _storageFolder)
        {
            var newFileName = string.Empty;

            if (_httpContextAccessor.HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = _httpContextAccessor.HttpContext.Request.Form.Files;
                var storageFolder = _storageFolder;

                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        //Getting FileName
                        fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var FileExtension = Path.GetExtension(fileName);

                        // concating  FileName + FileExtension
                        newFileName = myUniqueFileName + FileExtension;

                        // Combines two strings into a path.
                        fileName = Path.Combine(_environment.WebRootPath, storageFolder) + $@"\{newFileName}";

                        // if you want to store path of folder in database
                        PathDB = storageFolder + newFileName;

                        using (FileStream fs = System.IO.File.Create(fileName))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                      

                    }
                }

                return PathDB;
            }

            return null;
        }



        public string ImageSplitter(string imageUrl, string imagePostfix)
        {
            //tring imageUrl = "21adea7b-b106-4943-9e7b-771643c336ca.jpg";
            //imagePostfix = _p6

            string[] split = imageUrl.Split(new char[] { '.' }, 2);
            split[1] = split[1].TrimStart();

            string FullImageUrl = imageUrl;
            string SubImageUrl = split[0] + imagePostfix + "." + split[1];
            return SubImageUrl;
        }

        public List<string> ImageSplitterList(List<string> imageUrls, string imagePostfix)
        {
            //tring imageUrl = "21adea7b-b106-4943-9e7b-771643c336ca.jpg";
            //imagePostfix = _p6
            var convertedStrings = new List<string>();
            foreach (var imageUrl in imageUrls)
            {
                if (imageUrl.ToLower().IndexOf('.') != -1)
                {//checks if the image contains . as in if it has .jpg not njust a string or /

                    string[] split = imageUrl.Split(new char[] { '.' }, 2);
                    split[1] = split[1].TrimStart();

                    string FullImageUrl = imageUrl;
                    string SubImageUrl = split[0] + imagePostfix + "." + split[1];
                    convertedStrings.Add(SubImageUrl);
                }
            }

            return convertedStrings;
        }

  






    }


    public class ImageDimension
    {
        public int Height { get; set; }
        public int Width { get; set; }

    }
}
