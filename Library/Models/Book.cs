using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      this.Authors = new HashSet<BookAuthor>();
      this.Copies = new HashSet<Copy>();
    }
    public int BookId {get;set;}
    public string Title {get;set;}
    public virtual ICollection<BookAuthor> Authors { get; }
    public virtual ICollection<Copy> Copies { get; }
  }
}