using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BusinessLayer.Extensions
{
    public static class IFormFileExtension
    {
        public static async Task<string> UploadFileToAsync(this IFormFile formFile,params string[] folderNames)
        {
            var fileName = Path.GetFileName(formFile.FileName);
            fileName=Guid.NewGuid().ToString()+fileName;
            var fileDirectory = String.Empty;
            foreach (var folderName in folderNames)
            {
                fileDirectory = Path.Combine(fileDirectory,folderName);
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads",fileDirectory, fileName);
            var dbPath = Path.Combine("uploads",fileDirectory, fileName);

            // Create the directory if it doesn't exist
            var directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }
            return dbPath;
        }
        public static async Task DeleteFileAsync(string imagePath)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagePath);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }
    }
}
