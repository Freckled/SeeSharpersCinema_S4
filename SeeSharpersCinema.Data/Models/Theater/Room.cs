namespace SeeSharpersCinema.Models.Theater
{
    /// <summary>
    /// Class Room with properties 
    /// Entity Framework creates a table with Id as primary key 
    /// </summary>
    public class Room
    {
        public long Id { get; set; }
        public int Capacity { get; set; }
        public long CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public int Rows { get; set; }
    }
}
