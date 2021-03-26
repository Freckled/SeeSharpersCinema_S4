using SeeSharpersCinema.Models.Program;
using SeeSharpersCinema.Models.Website;
using System.Collections.Generic;

namespace SeeSharpersCinema.Data.Models.ViewModel
{    
    /// <summary>
     /// HomeViewModel used by the Home view (index)
     /// this combines the playlist and notifications.
     /// </summary>
    public class HomeViewModel
    {
        public IEnumerable<PlayList> Playlists { get; set; }
        public Notice Notices { get; set; }
    }
}
