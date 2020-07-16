using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Core.Services
{
  public class FileStorageAdapter
  {
    /// <summary>
    /// Папка, для хранения файлов к отправке на сервер.
    /// </summary>
    private const string ArchiveFolder = "Files";

    private readonly string[] _supportedFormats = new[] {"epub", "fb2", "pdf", "txt"};

    public bool IsBookFile(string fileName)
    {
      var extension = Path.GetExtension(fileName);
      return _supportedFormats.Any(f => f.Equals(extension, StringComparison.OrdinalIgnoreCase));
    }
    
    /// <summary>
    /// Готовит файл книги к отправке на сервер.
    /// </summary>
    public async Task<BookFile?> PrepareBook(string fullFileName)
    {
      if (!File.Exists(fullFileName))
        return null;

      if (!IsBookFile(Path.GetFileName(fullFileName)))
        return null;
      
      var archiveName = Path.Combine(ArchiveFolder, $"{Path.GetFileNameWithoutExtension(fullFileName)}.zip");
      var bytes = await CompressToZip(fullFileName, archiveName);
      
      return new BookFile
      {
        FileName = Path.GetFileName(fullFileName),
        FileExtension = Path.GetExtension(fullFileName),
        FullFileName = fullFileName,
        Bytes = bytes
      };
    }

    /// <summary>
    /// Сжимает указанный файл и возвращает массив байт сжатого файла.
    /// </summary>
    private async Task<byte[]> CompressToZip(string sourceFile, string compressedFile)
    {
      await using var sourceStream = new FileStream(sourceFile, FileMode.Open);
      await using var targetStream = File.Create(compressedFile);
      await using var compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
      await sourceStream.CopyToAsync(compressionStream);
      return await GetBytesFromStream(compressionStream);
    }
    
    /// <summary>
    /// Распаковывает указанный сжатый файл и возвращает массив байт распакованного файла.
    /// </summary>
    private async Task<byte[]> DecompressFromZip(string compressedFile, string targetFile)
    {
      await using var sourceStream = new FileStream(compressedFile, FileMode.OpenOrCreate);
      await using var targetStream = File.Create(targetFile);
      await using var decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress);
      await decompressionStream.CopyToAsync(targetStream);
      return await GetBytesFromStream(decompressionStream);
    }
    
    public async Task<byte[]> GetBytesFromStream(Stream input)
    {
      await using var ms = new MemoryStream();
      await input.CopyToAsync(ms);
      return ms.ToArray();
    }
  }
}