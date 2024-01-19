using Eventmi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventmi.Core.Contracts
{
    /// <summary>
    /// Event Service
    /// </summary>
    public interface IEventService
    {
        /// <summary>
        /// Create Event
        /// </summary>
        /// <param name="model">Event model</param>
        /// <returns></returns>
        Task CreateAsync(EventDto model);

        /// <summary>
        /// Delete event
        /// </summary>
        /// <param name="id">Event idendifier</param>
        /// <returns></returns>
        Task DeleteAsync(int id);

        /// <summary>
        /// Event editor
        /// </summary>
        /// <param name="model">Event model</param>
        /// <returns></returns>
        Task EditAsync(EventDto model);

        /// <summary>
        /// Returns event by provided id
        /// </summary>
        /// <param name="id">Event identifier</param>
        /// <returns></returns>
        Task<EventDto> GetByIdAsync(int id);

        /// <summary>
        /// Returns all events
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EventDto>> GetAllAsync();

        Task<IEnumerable<TownDto>> GetAllTownsAsync();
    }
}
