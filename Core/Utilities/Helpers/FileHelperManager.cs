using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers.GuidHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    
    public static class FileHeplerManager 
    {
        private static string CreateGuid()
        {
            return Guid.NewGuid().ToString();
        }
        public static byte[] ConvertIFormFileToByteArray(IFormFile file)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                return ms.ToArray();
            }
        }


    }
}
