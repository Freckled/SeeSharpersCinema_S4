using Microsoft.AspNetCore.Identity;
using SeeSharpersCinema.Models.Film;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Data.Models.Film
{
    public class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int Rating { get; set; }

        public long MovieId { get; set; }
        public Movie Movie { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public string Title { get; set; }

        [ForeignKey("UserId")]
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
