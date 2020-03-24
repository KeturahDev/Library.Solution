namespace Library.Models
{
  public class Copy
  {
    public Copy()
    {
      this.Books = new Hashset<Book>();
    }
    public int CopyId {get;set;}
    public int BookId {get;set;}
    public ICollection <Book> Books { get; }
  }
}