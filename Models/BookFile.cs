namespace Models
{
  public class BookFile
  {
    public string? FileName { get; set; } = null!;
    
    public string? FileExtension { get; set; } = null!;
    
    public string? FullFileName { get; set; } = null!;

    public byte[]? Bytes { get; set; } = null!;

    public long SizeInKb => Bytes?.Length / 1024 ?? 0;
  }
}