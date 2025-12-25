namespace EMS.Domain.Models
{
    public class MinioSettings
    {
        public required string ServiceURL { get; set; }
        public required string AccessKey { get; set; }
        public required string SecretKey { get; set; }
        public bool UseSsl { get; set; } = false;
        public string BucketName { get; set; } = "default-bucket";
    }
}
