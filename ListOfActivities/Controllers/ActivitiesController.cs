#nullable disable
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListOfActivities.Models;

namespace ListOfActivities.Controllers
{
    [Route("api/Activities")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly ActivitiesContext _context;

        public ActivitiesController(ActivitiesContext context)
        {
            _context = context;
        }

        // GET: api/Activities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activities>>> GetActivities()
        {
            var headersListProp = CheckHeaders();
            if (headersListProp != null)
                return headersListProp;

            return await _context.Activities.ToListAsync();
        }

        // GET: api/Activities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Activities>> GetActivities(int id)
        {
            var activities = await _context.Activities.FindAsync(id);

            if (activities == null)
            {
                return NotFound();
            }

            return activities;
        }

        // PUT: api/Activities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActivities(int id, Activities activities)
        {
            if (id != activities.Id)
            {
                return BadRequest();
            }

            TimeChecker(ref activities);

            _context.Entry(activities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivitiesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Activities
        [HttpPost]
        public async Task<ActionResult<Activities>> PostActivities(Activities activities)
        {
            TimeChecker(ref activities);

            if (!ModelState.IsValid)
            {
                BadRequest(activities);
            }

            _context.Activities.Add(activities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActivities", new { id = activities.Id }, activities);
        }

        // DELETE: api/Activities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivities(int id)
        {
            var activities = await _context.Activities.FindAsync(id);
            if (activities == null)
            {
                return NotFound();
            }

            _context.Activities.Remove(activities);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActivitiesExists(int id)
        {
            return _context.Activities.Any(e => e.Id == id);
        }

        private void TimeChecker(ref Activities activities)
        {
            if (activities.EventTime.Kind.HasFlag(DateTimeKind.Unspecified) || activities.EventTime.Kind.HasFlag(DateTimeKind.Local))
            {
                activities.EventTime = activities.EventTime.ToUniversalTime();
            }
        }

        private List<Activities> CheckHeaders()
        {
            List<Activities> result = new List<Activities>();
            DateTime dateTimeFrom;

            var organizer = Request.Headers["organizer"].ToString();
            var datetimeParse = DateTime.TryParse(Request.Headers["datetime"].ToString(), out dateTimeFrom);
            dateTimeFrom = dateTimeFrom.ToUniversalTime();

            if (datetimeParse)
            {
                DateTime dateTimeTo = dateTimeFrom.AddDays(7);
                var events = _context.Activities.Where(a => a.EventTime >= dateTimeFrom && a.EventTime < dateTimeTo).ToList();
                if (events.Count > 0)
                {
                    result.AddRange(events);
                    return result;
                }
            }
            else if (!String.IsNullOrEmpty(organizer))
            {
                var events = _context.Activities.Where(a => a.Organizer == organizer).ToList();
                if (events.Count > 0)
                {
                    result.AddRange(events);
                    return result;
                }
            }

            return null;
        }
    }
}
