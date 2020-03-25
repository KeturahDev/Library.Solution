using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Library.Controllers
{
  public class PatronsController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public PatronsController(LibraryContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;
    }

    [Authorize]
    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userCheckouts = _db.Checkouts.Include(checkout => checkout.Copy).Where(checkout => checkout.User.Id == currentUser.Id);
      return View(userCheckouts);
    }
    
    [HttpPost]
    public async Task<ActionResult> Checkout(int BookId)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      
      DateTime checkoutDate = DateTime.Now.Date;
      string dueDate = checkoutDate.AddDays(14).Date.ToString();

      Copy availableCopy = _db.Copies.FirstOrDefault(copy => copy.BookId == BookId && copy.Available == true);
      availableCopy.Available = false;
      _db.Entry(availableCopy).State = EntityState.Modified;

      Checkout newCheckout = new Checkout() { DueDate = dueDate, PatronId = userId, CopyId = availableCopy.CopyId, Returned = false };
      newCheckout.User = currentUser;
      newCheckout.Copy = availableCopy;
      newCheckout.Patron = _db.Patrons.FirstOrDefault(patron => patron.AccountUserId == currentUser.Id);
      _db.Checkouts.Add(newCheckout);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult ReturnBook(int CheckoutId)
    {
      Checkout thisCheckout = _db.Checkouts.FirstOrDefault(checkout => checkout.CheckoutId == CheckoutId);
      thisCheckout.Returned = true;
      Copy returnedCopy = _db.Copies.FirstOrDefault(copy => copy.CopyId == thisCheckout.CopyId);
      returnedCopy.Available = true;
      _db.Entry(thisCheckout).State = EntityState.Modified;
      _db.Entry(returnedCopy).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}