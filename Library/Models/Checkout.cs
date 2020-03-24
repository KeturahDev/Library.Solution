namespace Library.Models
{
  public class Checkout
  {
    public int CheckoutId {get;set;}
    public string DueDate {get;set;}
    public int PatronId {get;set;}
    public int CopyId {get;set;}
    public bool Returned {get;set;}
  }
}