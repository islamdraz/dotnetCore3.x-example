using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Shared;

namespace AspNetCore3.Upgrade.Services
{
    public class ConferenceMemoryService:IConferenceService
    {
        private readonly List<ConferenceModel> conferences = new List<ConferenceModel>();

        public ConferenceMemoryService()
        {
            conferences.Add(new ConferenceModel{Id = 1,Location = "Cairo",Name = ".net core",AttendeeTotal = 100});
            conferences.Add(new ConferenceModel{Id = 2,Location = "Cairo",Name = "c#",AttendeeTotal = 1000});

        }
        public  Task<IEnumerable<ConferenceModel>> GetAll()
        {
            return Task.Run(()=> conferences.AsEnumerable());
        }

        public  Task<ConferenceModel> GetById(int id)
        {
            return Task.Run(() => conferences.FirstOrDefault(x => x.Id == id));
        }

        public Task<StatisticsModel> GetStatistics()
        {
            return Task.Run(() =>
            {
                return new StatisticsModel
                {
                    AverageConferenceAttendees = (int) conferences.Sum(x => x.AttendeeTotal) / conferences.Count(),
                    NumberOfAttendees = conferences.Sum(x => x.AttendeeTotal)
                };
            });
        }

        public Task Add(ConferenceModel model)
        {
           return Task.Run(() =>  conferences.Add(model) );
        }
    }
}
