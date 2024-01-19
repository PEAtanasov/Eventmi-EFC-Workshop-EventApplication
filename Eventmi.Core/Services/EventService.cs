using Eventmi.Core.Contracts;
using Eventmi.Core.Models;
using Eventmi.Infrastructure.Data.Common;
using Eventmi.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventmi.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository eventRepository;

        public EventService(IRepository repository)
        {
            this.eventRepository = repository;
        }
        /// <summary>
        /// Create Event
        /// </summary>
        /// <param name="model">Event model</param>
        /// <returns></returns>
        public async Task CreateAsync(EventDto model)
        {
            if (model.Id>0)
            {
                bool exsists = eventRepository.GetByIdAsync<Event>(model.Id)!=null;

                throw new ArgumentException("The event already exist");
            }

            Event newEvent = new Event()
            {
                Name = model.Name,
                Start = model.Start,
                End = model.End,
                IsActive = true,
                Place = new Address()
                {
                    StreetName=model.StreetAddress,
                    TownId=model.TownId,
                }
            };

            await eventRepository.AddAsync(newEvent);
            await eventRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Delete event
        /// </summary>
        /// <param name="id">Event idendifier</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            Event? eventToDelete = await eventRepository.GetByIdAsync<Event>(id);

            if (eventToDelete!=null)
            {
                eventRepository.Delete(eventToDelete);
                await eventRepository.SaveChangesAsync();
            }        
        }

        /// <summary>
        /// Event editor
        /// </summary>
        /// <param name="model">Event model</param>
        /// <returns></returns>
        public async Task EditAsync(EventDto model)
        {
            Event? eventToEdit = await eventRepository
                .GetAll<Event>()
                .Include(e=>e.Place)
                .ThenInclude(p=>p.Town)
                .FirstOrDefaultAsync(e=>e.Id==model.Id);

            if (eventToEdit == null)
            {
                throw new ArgumentException("The event doesn't exist");
            }
            eventToEdit.Name = model.Name;
            eventToEdit.Start = model.Start;
            eventToEdit.End = model.End;
            eventToEdit.Place.StreetName = model.StreetAddress;
            eventToEdit.Place.TownId = model.TownId;

            await eventRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Returns event by provided id
        /// </summary>
        /// <param name="id">Event identifier</param>
        /// <returns></returns>
        public async Task<EventDto> GetByIdAsync(int id)
        {
            Event? @event = await eventRepository
                .GetAllReadOnly<Event>()
                .Include(e=>e.Place)
                .ThenInclude(p=>p.Town)
                .FirstOrDefaultAsync(e=>e.Id==id);
                
            if (@event==null)
            {
                throw new ArgumentException("Event doesn't exxist");
                
            }

            EventDto eventDto = new EventDto()
            {
                Id = @event.Id,
                Name=@event.Name,
                Start=@event.Start,
                End=@event.End,
                StreetAddress=@event.Place.StreetName,
                TownId = @event.Place.TownId,
            };

            return eventDto;
        }

        /// <summary>
        /// Returns all events
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EventDto>> GetAllAsync()
        {
            var test = await eventRepository.GetAllReadOnly<Event>()
                .Select(e=> new EventDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    End = e.End,
                    StreetAddress = e.Place.StreetName,
                    TownId = e.Place.TownId,
                }).ToListAsync();

            return test;
        }



        /// <summary>
        /// Returns all towns
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TownDto>> GetAllTownsAsync()
        {
           return await eventRepository
                .GetAllReadOnly<Town>()
                .Select(t=> new TownDto()
                {
                    Id=t.Id,
                    Name=t.Name
                })
                .ToListAsync();
        }
    }
}
