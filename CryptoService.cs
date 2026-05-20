using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SecureFileViewer
{
    public class CryptoService
    {
        private static readonly byte[] APPLICATION_SALT = Encoding.UTF8.GetBytes("MySecureVault_Salt_2024");
        private const int ITERATIONS = 100000;
        private const int KEY_SIZE = 32;
        private const int IV_SIZE = 16;

        public static byte[] Encrypt(byte[] plainData, string password)
        {
            using (var aes = Aes.Create())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (var deriveBytes = new Rfc2898DeriveBytes(password, APPLICATION_SALT, ITERATIONS, HashAlgorithmName.SHA256))
                {
                    aes.Key = deriveBytes.GetBytes(KEY_SIZE);
                    aes.IV = deriveBytes.GetBytes(IV_SIZE);
                }

                using (var memoryStream = new MemoryStream())
                {
                    // Tulis header
                    byte[] header = Encoding.UTF8.GetBytes("SECV1");
                    memoryStream.Write(header, 0, header.Length);

                    // Tulis IV
                    memoryStream.Write(aes.IV, 0, aes.IV.Length);

                    // Enkripsi data
                    using (var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainData, 0, plainData.Length);
                        cryptoStream.FlushFinalBlock();
                    }

                    return memoryStream.ToArray();
                }
            }
        }

        public static byte[] Decrypt(byte[] encryptedData, string password)
        {
            using (var memoryStream = new MemoryStream(encryptedData))
            {
                // Baca header
                byte[] header = new byte[5];
                memoryStream.Read(header, 0, 5);
                string headerStr = Encoding.UTF8.GetString(header);

                if (headerStr != "SECV1")
                    throw new CryptographicException("Invalid format");

                // Baca IV
                byte[] iv = new byte[IV_SIZE];
                memoryStream.Read(iv, 0, IV_SIZE);

                // Baca data terenkripsi
                byte[] cipherData = new byte[memoryStream.Length - memoryStream.Position];
                memoryStream.Read(cipherData, 0, cipherData.Length);

                using (var aes = Aes.Create())
                {
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    using (var deriveBytes = new Rfc2898DeriveBytes(password, APPLICATION_SALT, ITERATIONS, HashAlgorithmName.SHA256))
                    {
                        aes.Key = deriveBytes.GetBytes(KEY_SIZE);
                        aes.IV = iv;
                    }

                    using (var decryptStream = new MemoryStream())
                    using (var cryptoStream = new CryptoStream(decryptStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(cipherData, 0, cipherData.Length);
                        cryptoStream.FlushFinalBlock();
                        return decryptStream.ToArray();
                    }
                }
            }
        }
    }
}