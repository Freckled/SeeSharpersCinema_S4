using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeeSharpersCinema.Models.Database;
using SeeSharpersCinema.Models.Website;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Website.Controllers
{
    [Authorize(Roles = "Manager")]
    public class NoticesController : Controller
    {
        private readonly CinemaDbContext _context;

        public NoticesController(CinemaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This finds the notice with the message so that you are able to edit it.
        /// </summary>
        /// <param name="id">id of the notice</param>
        /// <returns>Message of the notice</returns>
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notice = await _context.Notices.FindAsync(id);
            if (notice == null)
            {
                return NotFound();
            }
            return View(notice);
        }

        /// <summary>
        /// Adding the ability to save the new notice to the server.
        /// </summary>
        /// <param name="id">Primary key of notice, to find it</param>
        /// <param name="notice">The notice model, which consists of an id, message and isActive bool</param>
        /// <returns>Editable notice, which saves to the database when you submit</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Message,isActive")] Notice notice)
        {
            if (id != notice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticeExists(notice.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Edit));
            }
            return View(notice);
        }
        /// <summary>
        /// A helper for the method above, to make sure the notice exists.
        /// </summary>
        /// <param name="id">primary key of the notice</param>
        /// <returns>true or false depending on if a notice exists</returns>
        private bool NoticeExists(long id)
        {
            return _context.Notices.Any(e => e.Id == id);
        }
    }
}
