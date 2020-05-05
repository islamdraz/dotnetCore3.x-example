using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore3.Upgrade.Services;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace AspNetCore3.Upgrade.Controllers
{
    public class ProposalController : Controller
    {
        private readonly IProposalService _proposalService;
        private readonly IConferenceService _conferenceService;

        public ProposalController(IProposalService proposalService,IConferenceService conferenceService)
        {
            _proposalService = proposalService;
            _conferenceService = conferenceService;
        }
        public async Task< IActionResult> Index(int conferenceId)
        {
            var conference = await _conferenceService.GetById(conferenceId);
            ViewBag.ConferenceId = conferenceId;
            ViewBag.Title = $"proposals for conference name:{conference.Name}";
            return View(await _proposalService.GetAll(conferenceId));
        }

        public IActionResult Add(int conferenceId)
        {
            ViewBag.Title = "Add Proposal";

            return View(new ProposalModel{ConferenceId=conferenceId});
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProposalModel proposalModel)
        {
            if (ModelState.IsValid)
                await _proposalService.Add(proposalModel);

            return RedirectToAction(nameof(Index),new {conferenceId=proposalModel.ConferenceId});
        }


        public async Task<IActionResult> Approve(int proposalId)
        {
           
           var proposal= await _proposalService.Approve(proposalId);

            return RedirectToAction(nameof(Index), new { conferenceId = proposal.ConferenceId });

        }
    }
}