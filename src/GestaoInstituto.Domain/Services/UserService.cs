using System.Security.Cryptography;
using System.Text;

namespace GestaoInstituto.Domain.Services
{
    public class UserService
    {
        public static string PasswordEncryption(string passText)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(passText));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
                strBuilder.Append(result[i].ToString("x2"));

            return strBuilder.ToString();
        }
    }
}
