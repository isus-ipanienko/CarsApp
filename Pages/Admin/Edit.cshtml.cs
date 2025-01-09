using CarsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarsApp.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly CarsApp.Data.CarDbContext _context;

        public EditModel(CarsApp.Data.CarDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car? EditCar { get; set; }

        public IActionResult OnGet(int id)
        {
            EditCar = _context.Cars.Find(id);
            if (EditCar != null) {
                Console.WriteLine(EditCar.Id);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (EditCar != null) {
                Console.WriteLine(EditCar.Id);
            }
            if (EditCar != null)
            {
                Console.WriteLine("UPDATE");
                _context.Cars.Update(EditCar);
            }
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }

}
