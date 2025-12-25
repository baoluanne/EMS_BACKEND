using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;

namespace EMS.Application.Services.MinioServices;

public class MinioService : IMinioService
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;

    public MinioService(IConfiguration configuration)
    {
        (_s3Client, _bucketName) = CreateClient(configuration);
    }

    private static (IAmazonS3 client, string bucket) CreateClient(IConfiguration config)
    {
        var section = config.GetSection("MinIO");
        var bucket = section["BucketName"]!;

        var client = new AmazonS3Client(
            section["AccessKey"],
            section["SecretKey"],
            new AmazonS3Config
            {
                ServiceURL = section["ServiceURL"],
                ForcePathStyle = true
            });

        var buckets = client.ListBucketsAsync().Result;
        bool exists = buckets.Buckets.Any(b => b.BucketName == bucket);

        if (!exists)
        {
            client.PutBucketAsync(bucket).Wait();
        }

        return (client, bucket);
    }

    public async Task UploadFileAsync(string key, Stream inputStream, string contentType)
    {
        var putRequest = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = key,
            InputStream = inputStream,
            ContentType = contentType
        };

        await _s3Client.PutObjectAsync(putRequest);
    }

    public async Task<Stream> GetFileAsync(string key)
    {
        var response = await _s3Client.GetObjectAsync(_bucketName, key);
        return response.ResponseStream;
    }

    public string GeneratePresignedUrl(string key, TimeSpan validFor)
    {
        return _s3Client.GetPreSignedURL(new GetPreSignedUrlRequest
        {
            BucketName = _bucketName,
            Key = key,
            Expires = DateTime.UtcNow.Add(validFor)
        });
    }
}