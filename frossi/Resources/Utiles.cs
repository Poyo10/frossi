using System.Security.Cryptography;
using System.Text;

namespace frossi.Resources
{
    public class Utiles
    {
        public static string Encriptar(string tTxt)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 sha256 = SHA256.Create()) { 
            
                Encoding enc = Encoding.UTF8;

                byte[] result = sha256.ComputeHash(enc.GetBytes(tTxt));


                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }

            }

            return sb.ToString();

        }
    }
}
