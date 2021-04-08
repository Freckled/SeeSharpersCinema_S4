using SeeSharpersCinema.Models;
using SeeSharpersCinema.Models.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.ViewModel
{
    public class EditPlayListViewModel
    {
        public List<PlayList> PlayLists { get; set; }
        public List<TimeSlot> TimeSlots { get; set; }
        public EditPlayListViewModel()
        {
            this.PlayLists = new List<PlayList>();
        }
        


    }
}
