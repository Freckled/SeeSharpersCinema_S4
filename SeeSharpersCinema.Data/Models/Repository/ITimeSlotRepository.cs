using SeeSharpersCinema.Models;
using SeeSharpersCinema.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.Repository
{
    public interface ITimeSlotRepository : IRepository<TimeSlot>
    {
        /// <summary>
        /// ITimeSlotRepository interface makes sure these methods are implemented
        /// in a taks for correct threading
        /// </summary>
        public Task UpdateTimeSlot(TimeSlot changedTimeSlot);
        public Task UpdateTimeSlots(List<TimeSlot> changedTimeSlots);
    }
}
