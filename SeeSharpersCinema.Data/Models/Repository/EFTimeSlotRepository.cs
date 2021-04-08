using Microsoft.EntityFrameworkCore;
using SeeSharpersCinema.Data.Models.Repository;
using SeeSharpersCinema.Models.Database;
using SeeSharpersCinema.Models.Film;
using SeeSharpersCinema.Models.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Models.Repository
{
    /// <summary>
    /// EFPlayListRepository queries and stores database data
    /// </summary>
    public class EFTimeSlotRepository : ITimeSlotRepository
    {
        private CinemaDbContext context;

        /// <summary>
        /// Constructor EFTimeSlotRepository
        /// </summary>
        /// <param name="ctx">EFTimeSlotRepository needs a CinemaDbContext object</param>
        public EFTimeSlotRepository(CinemaDbContext ctx)
        {
            context = ctx;
        }

        /// <summary>
        /// Queries the database to find all TimeSlots in a task for correct threading
        /// </summary>
        /// <returns>IEnumerable list of TimeSlot objects</returns>
        public async Task<IEnumerable<TimeSlot>> FindAllAsync()
            => await context.TimeSlots
            .OrderBy(p => p.SlotStart)
            .ToListAsync();

        /// <summary>
        /// Queries the database to find a movie by movieId in a task for correct threading
        /// </summary>
        /// <param name="movieId">Long movie Id</param>
        /// <returns>Playlists of Movie with this id</returns>
        public async Task UpdateTimeSlot(TimeSlot changedTimeSlot)
        {
            var timeSlot = context.TimeSlots.Where(z => z.Id == changedTimeSlot.Id).FirstOrDefault();
            
            if (timeSlot != null)
            {
                timeSlot.SlotStart = changedTimeSlot.SlotStart;
                timeSlot.SlotEnd = changedTimeSlot.SlotEnd;
                timeSlot.RoomId = changedTimeSlot.RoomId;
                
                context.Update(timeSlot);
                await context.SaveChangesAsync();
            }        
            
        }

        public async Task UpdateTimeSlots(List<TimeSlot> timeSlots)
        {

            List<TimeSlot> changeSlots = new List<TimeSlot>();
            timeSlots.ForEach(s => {
                var timeSlot = context.TimeSlots.Where(z => z.Id == s.Id).FirstOrDefault();
                               
                
                timeSlot.SlotStart = s.SlotStart;
                timeSlot.SlotEnd = s.SlotEnd;
                
                
                
                timeSlot.RoomId = s.RoomId;
                changeSlots.Add(timeSlot);
            });

            context.UpdateRange(changeSlots);
            await context.SaveChangesAsync();
        }

    }
}
