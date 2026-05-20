using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SecureFileViewer
{
    public class AuthService
    {

        private static string GetConfigPath()
        {

            string appData = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                "SecureFileVault"
            );

            if (!Directory.Exists(appData))
                Directory.CreateDirectory(appData);

            File.SetAttributes(appData, FileAttributes.Hidden);

            return Path.Combine(appData, "auth.dat");
        }

        private static readonly byte[] SALT = Encoding.UTF8.GetBytes("SecureVault_Auth_Salt_2024_V2");
        private const int ITERATIONS = 100000;

        /// <summary>
        /// Cek apakah sudah ada password 
        /// </summary>
        public static bool IsFirstTime()
        {
            string configPath = GetConfigPath();
            return !File.Exists(configPath);
        }

        /// <summary>
        /// Membuat password baru 
        /// </summary>
        public static bool CreatePassword(string password)
        {
            try
            {
                string configPath = GetConfigPath();

                // Hash password untuk disimpan
                string hashedPassword = HashPassword(password);

                // Simpan ke file (bisa juga dienkripsi lagi)
                byte[] data = Encoding.UTF8.GetBytes(hashedPassword);
                File.WriteAllBytes(configPath, data);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CreatePassword Error: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Verifikasi password login
        /// </summary>
        public static bool VerifyPassword(string password)
        {
            try
            {
                string configPath = GetConfigPath();

                if (!File.Exists(configPath))
                    return false;

                byte[] data = File.ReadAllBytes(configPath);
                string storedHash = Encoding.UTF8.GetString(data);
                string inputHash = HashPassword(password);

                return storedHash == inputHash;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Hash password dengan PBKDF2
        /// </summary>
        private static string HashPassword(string password)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, SALT, ITERATIONS, HashAlgorithmName.SHA256))
            {
                byte[] hash = deriveBytes.GetBytes(32);
                return Convert.ToBase64String(hash);
            }
        }

        /// <summary>
        /// Ganti password 
        /// </summary>
        public static bool ChangePassword(string oldPassword, string newPassword)
        {
            if (VerifyPassword(oldPassword))
            {
                return CreatePassword(newPassword);
            }
            return false;
        }

        /// <summary>
        /// Hapus konfigurasi
        /// </summary>
        public static void ResetAuth()
        {
            try
            {
                string configPath = GetConfigPath();
                if (File.Exists(configPath))
                    File.Delete(configPath);
            }
            catch { }
        }
    }
}