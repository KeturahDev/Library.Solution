using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;

namespace Library.Controllers
{
  public class CheckoutsController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public CheckoutsController(LibraryContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;
    }

    public ActionResult Index()
    {
      string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      List<Checkout> checkouts = _db.Checkouts.Where(checkout => checkout.PatronId == userId && checkout.Returned == false).ToList();
      List<Book> checkedOutBooks = new List<Book> {};
      foreach(Checkout checkout in checkouts)
      {
        Book thisBook = checkout.Book;
        checkedOutBooks.Add(thisBook);
      }
      return View(checkedOutBooks);
    }

    [HttpPost]
    public ActionResult Create(int BookId)
    {
      string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      DateTime checkoutDate = DateTime.Now.Date;
      string dueDate = checkoutDate.AddDays(14).Date.ToString();
      Copy availableCopy = _db.Copies.FirstOrDefault(copy => copy.BookId == BookId && copy.Available == true);
      availableCopy.Available = false;
      _db.Entry(availableCopy).State = EntityState.Modified;
      _db.Checkouts.Add(new Checkout() { DueDate = dueDate, PatronId = userId, CopyId = availableCopy.CopyId, Returned = false});
      _db.SaveChanges();
      return RedirectToAction("Details", "Books", new { id = BookId});
    }
  }
} 