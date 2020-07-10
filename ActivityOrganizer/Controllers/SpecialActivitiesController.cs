using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActivityOrganizer.Data;
using ActivityOrganizer.Models;


namespace ActivityOrganizer.Controllers
{
    public class SpecialActivitiesController : Controller
    {
        private readonly ActivityContext _context;

        public SpecialActivitiesController(ActivityContext context)
        {
            _context = context;
        }

        // GET: SpecialActivities
        public async Task<IActionResult> Index(string priority, string searchActivityName)
        {
            var prioritiesQuery = from prior in _context.SpecialActivity
                                  orderby prior.ActivityPriority
                             select prior.ActivityPriority;

            var activitiesQuery = from activity in _context.SpecialActivity
                                  select activity;

            if (!string.IsNullOrEmpty(priority))
            activitiesQuery = activitiesQuery.Where(item => item.ActivityPriority.Contains(priority));
            
            if (!string.IsNullOrEmpty(searchActivityName)) 
            activitiesQuery = activitiesQuery.Where(item => item.ActivityName.Contains(searchActivityName) || 
                                                            item.TypeOfActivity.Contains(searchActivityName));

            var activityWithPriority = new ActivityWithPriority
            {
                 Priorities = new SelectList (await prioritiesQuery.Distinct().ToListAsync()),
                 Activities = await activitiesQuery.ToListAsync() 
            };

            return View(activityWithPriority);
        }       

        // GET: SpecialActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialActivity = await _context.SpecialActivity.FirstOrDefaultAsync(model => model.Id == id);
            if (specialActivity == null)
            {
                return NotFound();
            }

            return View(specialActivity);
        }

        // GET: SpecialActivities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpecialActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ActivityName,DateAdded,DateFinish,TypeOfActivity,ActivityPriority")] SpecialActivity specialActivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialActivity);
                await _context.SaveChangesAsync();
            
                return RedirectToAction(nameof(Index));
            }

            return View(specialActivity);
        }

        // GET: SpecialActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialActivity = await _context.SpecialActivity.FindAsync(id);
            if (specialActivity == null)
            {
                return NotFound();
            }

            return View(specialActivity);
        }

        // POST: SpecialActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ActivityName,DateAdded,DateFinish,TypeOfActivity,ActivityPriority")] SpecialActivity specialActivity)
        {
            if (id != specialActivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialActivityExists(specialActivity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(specialActivity);
        }

        // GET: SpecialActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialActivity = await _context.SpecialActivity
                .FirstOrDefaultAsync(model => model.Id == id);
            if (specialActivity == null)
            {
                return NotFound();
            }

            return View(specialActivity);
        }

        // POST: SpecialActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialActivity = await _context.SpecialActivity.FindAsync(id);
            _context.SpecialActivity.Remove(specialActivity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool SpecialActivityExists(int id)
        {
            return _context.SpecialActivity.Any(model => model.Id == id);
        }


        public IActionResult Privacy()
        {
            return View();
        }
    }
}