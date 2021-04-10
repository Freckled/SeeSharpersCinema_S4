using System.Collections.Generic;
using System.Threading.Tasks;

namespace SeeSharpersCinema.Models.Repository
{
    /// <summary>
    /// Interface makes sure type is a class
    /// and is used throughout the implementing class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindAllAsync();
    }
}
