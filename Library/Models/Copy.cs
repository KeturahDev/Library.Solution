using System.Collections.Generic;

namespace Library.Models
{
  public class Copy
  {
    public int CopyId {get;set;}
    public bool Available {get; set;} = true;
    public int BookId {get;set;}
    public virtual Book Book { get; set;}
  }
}