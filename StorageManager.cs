using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using SecureFileViewer.Models;
using System.Text;

namespace SecureFileViewer
{
    public class StorageManager
    {
        private readonly string _storagePath;
        private string _currentPassword;
        private StorageContainer _container;

        public StorageManager(string storageFilePath)
        {
            _storagePath = storageFilePath;
        }

        public bool Exists => File.Exists(_storagePath);
        public int FileCount => _container?.Files.Count ?? 0;

        public List<StoredFile> GetFiles() => _container?.Files ?? new List<StoredFile>();

        public bool Load(string password)
        {
            try
            {
                if (!File.Exists(_storagePath))
                {
                    _container = new StorageContainer();
                    _currentPassword = password;
                    return true;
                }

                byte[] encryptedData = File.ReadAllBytes(_storagePath);
                byte[] jsonData = CryptoService.Decrypt(encryptedData, password);
                string json = Encoding.UTF8.GetString(jsonData);
                _container = JsonSerializer.Deserialize<StorageContainer>(json);
                _currentPassword = password;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(_container);
            byte[] jsonData = Encoding.UTF8.GetBytes(json);
            byte[] encryptedData = CryptoService.Encrypt(jsonData, _currentPassword);
            File.WriteAllBytes(_storagePath, encryptedData);
        }

        public void AddFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            string extension = Path.GetExtension(filePath).ToLower();

            byte[] fileData = File.ReadAllBytes(filePath);
            byte[] encryptedData = CryptoService.Encrypt(fileData, _currentPassword);

            var file = new StoredFile
            {
                Name = fileName,
                Extension = extension,
                Size = fileData.Length,
                UploadedAt = DateTime.Now,
                EncryptedData = encryptedData
            };

            _container.Files.Add(file);
            Save();
        }

        public byte[] GetFileData(string fileId, string password)
        {
            var file = _container.Files.FirstOrDefault(f => f.Id == fileId);
            if (file == null) throw new Exception("File not found");
            return CryptoService.Decrypt(file.EncryptedData, password);
        }

        public void DeleteFile(string fileId)
        {
            var file = _container.Files.FirstOrDefault(f => f.Id == fileId);
            if (file != null)
            {
                _container.Files.Remove(file);
                Save();
            }
        }

        public bool TestFilePassword(string fileId, string password)
        {
            try
            {
                var file = _container.Files.FirstOrDefault(f => f.Id == fileId);
                if (file == null) return false;
                CryptoService.Decrypt(file.EncryptedData, password);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Purge()
        {
            if (File.Exists(_storagePath))
                File.Delete(_storagePath);
            _container = null;
        }
    }
}