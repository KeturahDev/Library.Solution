namespace Library.Models
{
  public class Checkout
  {
    public int CheckoutId {get;set;}
    public string DueDate {get;set;}
    public string PatronId {get;set;}
    public int CopyId {get;set;}
    public bool Returned {get;set;}
    public virtual ApplicationUser User { get; set; }
    public virtual Copy Copy {get; set;}
    public virtual Patron Patron {get; set;}
  }
}