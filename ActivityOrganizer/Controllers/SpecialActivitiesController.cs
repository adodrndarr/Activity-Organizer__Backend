using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActivityOrganizer.Data;
using ActivityOrganizer.Models;
using System;

namespace ActivityOrganizer.Controllers
{
    public class SpecialActivitiesController : Controller
    {
        private const string SPECIAL_ACTIVITY_PARAMETERS = "Id, ActivityName, DateAdded, DateFinish, TypeOfActivity, ActivityPriority";
        private readonly ActivityContext _context;
        public SpecialActivitiesController(ActivityContext context)
        {
            _context = context;
        }


        // GET: SpecialActivities
        public async Task<IActionResult> Index(string priority, string searchActivityName)
        {
            var activityPriorities = await (from sa in _context.SpecialActivity
                                            orderby sa.ActivityPriority
                                            select sa.ActivityPriority)
                                     .Distinct()
                                     .ToListAsync();

            var activitiesQuery = from activity in _context.SpecialActivity
                                  select activity;

            if (!string.IsNullOrEmpty(priority))
                activitiesQuery = activitiesQuery.Where(sa => sa.ActivityPriority.Contains(priority));
            
            if (!string.IsNullOrEmpty(searchActivityName)) 
                activitiesQuery = activitiesQuery.Where(sa => sa.ActivityName.Contains(searchActivityName) || 
                                                              sa.TypeOfActivity.Contains(searchActivityName));

            var activityWithPriority = new ActivityWithPriority
            {
                 Priorities = new SelectList (activityPriorities),
                 Activities = await activitiesQuery.ToListAsync() 
            };

            return View(activityWithPriority);
        }       

        // GET: SpecialActivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) 
                return NotFound();

            var specialActivity = await _context.SpecialActivity.FirstOrDefaultAsync(sa => sa.Id == id);
            if (specialActivity == null)
                return NotFound();
            
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
        public async Task<IActionResult> Create([Bind(SPECIAL_ACTIVITY_PARAMETERS)] SpecialActivity specialActivity)
        {
            if (!ModelState.IsValid)
                return View(specialActivity);

            _context.Add(specialActivity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: SpecialActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) 
                return NotFound();            

            var specialActivity = await _context.SpecialActivity.FindAsync(id);
            if (specialActivity == null) 
                return NotFound();
            
            return View(specialActivity);
        }

        // POST: SpecialActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(SPECIAL_ACTIVITY_PARAMETERS)] SpecialActivity specialActivity)
        {
            if (id != specialActivity.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(specialActivity);

            try
            {
                _context.Update(specialActivity);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                var activityExists = _context.SpecialActivity.Any(sa => sa.Id == id);
                if (!activityExists)
                    return BadRequest();

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: SpecialActivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) 
                return NotFound();            

            var specialActivity = await _context.SpecialActivity.FirstOrDefaultAsync(sa => sa.Id == id);
            if (specialActivity == null)
                return NotFound();

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

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
