using System;

namespace Models.Domain
{
  /// <summary>
  /// Модель главы книги.
  /// </summary>
  public class Chapter
  {
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Content { get; set; }
    
    public Guid BookId { get; set; }
    
    public Book Book { get; set; }
  }
}