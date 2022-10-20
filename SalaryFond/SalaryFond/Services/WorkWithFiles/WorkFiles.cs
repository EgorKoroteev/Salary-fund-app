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
        public ObservableCollection<Month> ReadJsonBD()
        {
            ObservableCollection<Month> months = File.Exists("DataBase.json") ? JsonConvert.DeserializeObject<ObservableCollection<Month>>(File.ReadAllText("DataBase.json")) : null;
            return months;
        }

        public void WriteJsonBD(IEnumerable<Month> months)
        {
            File.WriteAllText("DataBase.json", JsonConvert.SerializeObject(months));
        }
    }
}
