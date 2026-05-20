using System;
using System.Collections.Generic;

namespace SecureFileViewer.Models
{
    [Serializable]
    public class StoredFile
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public DateTime UploadedAt { get; set; }
        public byte[] EncryptedData { get; set; }

        /// <summary>
        /// Override ToString() agar ListBox menampilkan nama file asli
        /// </summary>
        public override string ToString()
        {
            // Tampilkan nama file + ukuran
            return $"{Name} ({FormatFileSize(Size)})";
        }

        /// <summary>
        /// Format ukuran file agar mudah dibaca (B, KB, MB, GB)
        /// </summary>
        private string FormatFileSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }
    }

    [Serializable]
    public class StorageContainer
    {
        public List<StoredFile> Files { get; set; } = new List<StoredFile>();
        public DateTime LastModified { get; set; } = DateTime.Now;
    }
}