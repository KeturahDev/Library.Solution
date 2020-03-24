using System.Collections.Generic;

namespace Library.Models
{
  public class Copy
  {
    public Copy()
    {
      this.Books = new HashSet<Book>();
    }
    public int CopyId {get;set;}
    public int BookId {get;set;}
    public ICollection <Book> Books { get; }
  }
}