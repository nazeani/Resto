using Business.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class Helper
    {
        public static string SaveFile(string filePath,string folder,IFormFile file )
        {
            if (file.ContentType != "image/jpeg" && file.ContentType != "image/png") throw new ImageContextExceptions("Seklin uzantisi jpeg/jpg/png olmalidir!");
            if (file.Length > 2000000) throw new ImageLengthException("Sekil max 2mb olmalidir!");
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string path = filePath + $@"\{folder}\" + fileName;
            using (FileStream fileStream = new FileStream(path,FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileName;
        }
        public static void DeleteFile(string filePath, string folder, string fileName)
        {
            string path = filePath + $@"\{folder}\" + fileName;
            if(!File.Exists(path)) throw new Exceptions.FileNotFoundException("Fayl Tapilmadi!");
            File.Delete(path);

        }
    }
}
