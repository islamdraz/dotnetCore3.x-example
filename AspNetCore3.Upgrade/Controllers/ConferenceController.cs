using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore3.Upgrade.Services;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace AspNetCore3.Upgrade.Controllers
{

    public class ConferenceController : Controller
    {
        private readonly IConferenceService _conferenceService;

        public ConferenceController(IConferenceService conferenceService)
        {
            _conferenceService = conferenceService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Conferences";
            return View(await _conferenceService.GetAll());
        }

        public   IActionResult Add()
        {
            ViewBag.Title = "Add Conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel model)
        {
            if (ModelState.IsValid)
            {
               await _conferenceService.Add(model);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}