using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Shared;

namespace AspNetCore3.Upgrade.Services
{
    public class MemoryProposalService:IProposalService
    {
        public List<ProposalModel> Proposals=new List<ProposalModel>();

        public MemoryProposalService()
        {
            Proposals.Add(new ProposalModel{Id = 1,ConferenceId = 1,Speaker = "Islam draz",Title = "Net core"});
            Proposals.Add(new ProposalModel{Id = 2,ConferenceId = 2,Speaker = "Islam draz",Title = "C#"});
        }
        public Task Add(ProposalModel model)
        {
            model.Id = Proposals.Max(x => x.Id) + 1;
            return Task.Run(() => Proposals.Add(model));
        }

        public Task<ProposalModel> Approve(int proposalId)
        {
            return Task.Run(() => { 
                
               var propsal= Proposals.First(x => x.Id == proposalId);
               propsal.Approved = true;
               return propsal;
            });
        }

        public Task<IEnumerable<ProposalModel>> GetAll(int conferenceId)
        {
            return Task.Run(()=>Proposals.Where(x=>x.ConferenceId==conferenceId).AsEnumerable());
        }
    }
}
