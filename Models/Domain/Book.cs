using System;
using System.Collections.Generic;

namespace Models.Domain
{
  public class Book
  {
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public IReadOnlyList<Chapter> Chapters { get; set; }
  }
}