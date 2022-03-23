using System.Text;
using System.Security.Cryptography;
using MedicalAPI.Model;

namespace MedicalAPI.Helper
{
    public class Helper
    {
        public static string GetConnectionString()
        {
            string con = "Data Source= mssqlssd1.zadns.co.za;Initial Catalog=mediappdb;User Id=nathi;Password=nathi123";
            return con;
        }
        public static string GetFileType(IFormFile formFile)
        {
            string sFileType = "";

            if (formFile != null) 
            {
                if (formFile.FileName.Contains(".doc") || formFile.FileName.Contains(".rtf"))
                {
                    
                }

                if (formFile.FileName.Contains(".pdf"))
                {
                    
                }

                if (formFile.FileName.Contains(".xls"))
                {
                    
                }

                if (formFile.FileName.Contains(".txt"))
                {
                    
                }

                if (formFile.FileName.Contains(".jpeg") || formFile.FileName.Contains(".jpg"))
                {
                    
                }

                if (formFile.FileName.Contains(".png") || formFile.FileName.Contains(".PNG"))
                {
                    sFileType = "png";
                }

            }

            return sFileType;
        }


        public static string EncryptWithMD5(string inValue)
        {
            var md5 = new MD5CryptoServiceProvider();

            var encoder = new UTF8Encoding();

            string encryptedString = "";

            if (inValue == "")
            { return encryptedString; }
            else
            {
                byte[] hashedBytes = md5.ComputeHash(encoder.GetBytes(inValue));
                encryptedString = Convert.ToBase64String(hashedBytes);
                return encryptedString;
            }
        }
    }
}
