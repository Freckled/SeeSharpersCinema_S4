namespace SeeSharpersCinema.Models
{
    /// <summary>
    /// Class which provides information about occurring errors
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
