using Newtonsoft.Json;
using SalaryFond.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryFond.Services.WorkWithFiles
{
    class WorkFiles
    {
        public ObservableCollection<Company> ReadJsonBD()
        {
            ObservableCollection<Company> company = File.Exists("DataBase.json") ? JsonConvert.DeserializeObject<ObservableCollection<Company>>(File.ReadAllText("DataBase.json")) : null;
            return company;
        }

        public void WriteJsonBD(IEnumerable<Company> companies)
        {
            File.WriteAllText("DataBase.json", JsonConvert.SerializeObject(companies));
        }
    }
}
