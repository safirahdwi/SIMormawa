using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Minio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ormawa.Services
{
    public class FileService : IFileService
    {
        private readonly IConfiguration _configuration;
        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> UploadDokumen(string namaBerkas, IFormFile file)
        {
            if (string.IsNullOrEmpty(namaBerkas))
            {
                throw new Exception($"Tipe File not found");
            }

            if (file.Length == 0)
            {
                throw new Exception($"File not found");
            }

            var client = new MinioClient(_configuration["Minio:Host"], _configuration["Minio:AccessKey"], _configuration["Minio:SecretKey"]).WithSSL();

            var bucketName = _configuration["Minio:Bucket"];
            var fileExtName = file.FileName.Split('.').LastOrDefault(); // .ext
            string[] allowedDocs = new string[] { "pdf", "jpg", "jpeg", "png", "rar", "zip", "doc", "docx", "xls", "xlsx" };
            if (!allowedDocs.Contains(fileExtName))
            {
                throw new Exception("Allowed pdf, jpg, jpeg, png, rar, zip, doc, docx, xls, xlsx");
            }

            var objectName = namaBerkas + "_" + Guid.NewGuid().ToString() + "." + fileExtName; // guid.ext
            var contentType = file.ContentType;
            var streamLength = file.Length;

            var metadata = new Dictionary<string, string>
            {
                ["OriginalFilename"] = file.FileName,
            };

            await client.PutObjectAsync(bucketName, objectName, file.OpenReadStream(), streamLength, contentType, metadata);

            var publicUrl = $"{_configuration["Minio:Host"]}/{_configuration["Minio:Bucket"]}/{objectName}";

            return publicUrl;
        }
    }
}
