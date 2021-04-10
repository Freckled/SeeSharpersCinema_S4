namespace SeeSharpersCinema.Models.Website
{
    /// <summary>
    /// Class Cinema with properties 
    /// Entity Framework creates a table with Id as primary key 
    /// </summary>
    public class Notice
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public bool isActive { get; set; }
    }
}