using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace DesafioVibe.Util
{
    public class MD5Helper
    {
        public string CreateMD5(string Senha)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return CreateHash(md5Hash, Senha);
            }
        }

        private string CreateHash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
