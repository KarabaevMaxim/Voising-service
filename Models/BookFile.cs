using System;

namespace Models
{
  public class BookFile
  {
    public Guid Id { get; set; }

    public string FileName { get; set; } = null!;
    
    public string FileExtension { get; set; } = null!;
    
    public string FullFileName { get; set; } = null!;

    public byte[] Bytes { get; set; } = null!;
  }
}