using Eventmi.Core.Constants;
using Eventmi.Core.Contracts;
using Eventmi.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eventmi.Controllers
{
    public class EventController : Controller
    { 
        private readonly IEventService eventService;
        private readonly ILogger logger;
        public EventController(IEventService eventService, ILogger<EventController> logger)
        {
            this.eventService = eventService;
            this.logger = logger;

        }
        public async Task<IActionResult> Index()
        {
            var model = await eventService.GetAllAsync(); 
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventDto();
            ViewBag.Towns = await GetTownsAsync();
            return View(model);
            
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventDto model) 
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    await eventService.CreateAsync(model);
                    return RedirectToAction("Index");
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error creating event");
                    ModelState.AddModelError(string.Empty, UserMessageConstants.UnknownError);
                }   
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await eventService.GetByIdAsync(id);
            ViewBag.Towns = await GetTownsAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventDto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await eventService.EditAsync(model);
                    return RedirectToAction(nameof(Index));
                }
                catch (ArgumentException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error editing event");
                    ModelState.AddModelError(string.Empty, UserMessageConstants.UnknownError);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await eventService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Delete failed");
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await eventService.GetByIdAsync(id));
        }

        private async Task<IEnumerable<SelectListItem>> GetTownsAsync()
        {
            var towns = await eventService.GetAllTownsAsync();

            return towns.Select(x => new SelectListItem (x.Name, x.Id.ToString()));
        }
    }
}
