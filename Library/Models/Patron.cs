using System.Collections.Generic;

namespace Library.Models
{
  public class Patron
  {
    public Patron()
    {
      this.Checkouts = new Hashset<Checkout>();
    }
    public int PatronId {get;set;}
    public string Name {get;set;}
    public ICollection<Checkout> Checkouts {get;set;}
  }
}