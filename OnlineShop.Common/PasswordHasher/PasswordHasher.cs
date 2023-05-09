using System.Security.Cryptography;
using System.Text;

namespace OnlineShop.Common.PasswordHasher
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert the password string to byte array
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Compute hash value of the password bytes
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convert the hash bytes to string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2")); // Use "X2" to get uppercase hexadecimal representation
                }

                return sb.ToString();
            }
        }
    }
}
