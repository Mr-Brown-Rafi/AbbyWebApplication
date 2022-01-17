using Abby_Web.Data;
using Abby_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby_Web.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]  // we can also add this annotation at class level if we have multiple properties
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _db.categories.Find(id);
            //Category = _db.categories.FirstOrDefault(u => u.Id == id);
            //Category = _db.categories.SingleOrDefault(u => u.Id == id);
            //Category = _db.categories.Where(u => u.Id == id).FirstOrDefault();

        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Name and Display order sholud not be the same.");
            }
            if(ModelState.IsValid)
            {
                _db.categories.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category is updated sccessfully..!";
                return RedirectToPage("Index");
            }
            return Page();

;        }
    }
}
