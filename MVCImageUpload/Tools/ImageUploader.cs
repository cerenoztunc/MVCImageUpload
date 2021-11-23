using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MVCImageUpload.Tools
{
    public static class ImageUploader
    {
        //HttpPostedFileBase:MVC'de eğer post yönteminde bir dosya geliyorsa bu dosya HTTPPostedFileBase tipinde tutulur.
        public static string UploadImage(string serverPath, HttpPostedFileBase file)
        {
            if (file != null)
            {
                Guid uniqueName = Guid.NewGuid();

                string[] fileArray = file.FileName.Split('.');
                string extension = fileArray[fileArray.Length - 1].ToLower();
                string fileName = $"{uniqueName}.{extension}";

                if (extension == "jpg" || extension == "gif" || extension == "jpeg")
                {
                    if (File.Exists(HttpContext.Current.Server.MapPath(serverPath + fileName)))
                    {
                        return "1";
                    }
                    string filePath = HttpContext.Current.Server.MapPath(serverPath + fileName);
                    file.SaveAs(filePath);
                    return serverPath + fileName;
                }
                return "2";
            }
            return "3";
        }
    }
}