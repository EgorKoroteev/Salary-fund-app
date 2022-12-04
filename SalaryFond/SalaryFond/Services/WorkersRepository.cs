using SalaryFond.Models;
using SalaryFond.Services.Base;
using System.Linq;

namespace SalaryFond.Services
{
    internal class WorkersRepository : RepositoryInMemory<Worker>
    {
        public WorkersRepository() { }

        public Worker Get(string WorkerFIO) => GetAll().FirstOrDefault(g => g.FIO == WorkerFIO);

        protected override void Update(Worker Source, Worker Destination)
        {
            Destination.FIO = Source.FIO;
            Destination.MainProfession = Source.MainProfession;
            Destination.MainSalary = Source.MainSalary;
            Destination.NormalHours = Source.NormalHours;
            Destination.WorkedHours = Source.WorkedHours;
            Destination.RateRUB = Source.RateRUB;
            Destination.Prize = Source.Prize;
            Destination.PrizeBoss = Source.PrizeBoss;
            Destination.ResultSalary = Source.ResultSalary;
            Destination.AdditionalProfessions = Source.AdditionalProfessions;
        }
    }
}