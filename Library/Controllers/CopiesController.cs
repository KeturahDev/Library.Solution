using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Library.Controllers
{
  public class CopiesController : Controller
  {
    private readonly LibraryContext _db;

    public CopiesController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Copies.ToList());
    }

    [HttpPost]
    public ActionResult Create (Copy copy)
    {
      _db.Copies.Add(copy);
      _db.SaveChanges();
      return RedirectToAction("Details", "Books", new { id = copy.BookId });
    }

    [HttpPost]
    public ActionResult Checkout(int BookId)
    {
      Copy availableCopy = _db.Copies.FirstOrDefault(copy => copy.BookId == BookId && copy.Available == true);
      availableCopy.Available = false;
      _db.Entry(availableCopy).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", "Books", new { id = BookId});
    }

    public ActionResult Details(int id)
    {
      Copy thisCopy = _db.Copies.FirstOrDefault(copy => copy.CopyId == id);
      return View(thisCopy);
    }

    public ActionResult Edit(int id)
    {
      Copy thisCopy = _db.Copies.FirstOrDefault(copy => copy.CopyId == id);
      ViewBag.BookId = new SelectList(_db.Books, "BookId", "Title");
      return View(thisCopy);
    }

    [HttpPost]
    public ActionResult Edit(Copy copy)
    {
      _db.Entry(copy).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", "Books", new { id = copy.BookId });
    }

    // public ActionResult Delete(int id)
    // {
    //   Copy thisCopy = _db.Copies.FirstOrDefault(copy => copy.CopyId == id);
    //   return View(thisCopy);
    // }

    // maybe have button on Copy Details that posts to Delete instead of having a view.

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Copy thisCopy = _db.Copies.FirstOrDefault(copy => copy.CopyId == id);
      _db.Copies.Remove(thisCopy);
      _db.SaveChanges();
      return RedirectToAction("Details", "Books", new { id= thisCopy.BookId });
    }
  }
}