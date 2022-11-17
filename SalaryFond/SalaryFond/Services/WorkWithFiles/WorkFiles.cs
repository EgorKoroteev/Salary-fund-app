using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using SalaryFond.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;


namespace SalaryFond.Services.WorkWithFiles
{
    class WorkFiles
    {
        public ObservableCollection<YearSalary> ReadJsonBD()
        {
            ObservableCollection<YearSalary> years = File.Exists("DataBase.json") ? JsonConvert.DeserializeObject<ObservableCollection<YearSalary>>(File.ReadAllText("DataBase.json")) : null;
            return years;
        }

        public void WriteJsonBD(IEnumerable<YearSalary> years)
        {
            File.WriteAllText("DataBase.json", JsonConvert.SerializeObject(years));
        }

        public void WriteJsonDictionary(IEnumerable<Company> companies)
        {
            foreach (Company company in companies)
            {
                company.FactSalaryFund = 0;
                company.NormalHours = 0;
                company.WorkedHours = 0;
            }

            foreach (Company company in companies)
            {
                foreach (Worker worker in company.Workers)
                {
                    worker.HolidayPay = 0;
                    worker.SickPay = 0;
                    worker.RKO = 0;
                    worker.ExecutiveList = 0;
                    worker.Prize = 0;
                    worker.PrizeBoss = 0;
                    worker.MainSalary = 0;
                    worker.RateRUB = 0;
                    worker.NormalHours = 0;
                    worker.WorkedHours = 0;
                    worker.MainResultSalary = 0;
                    worker.SummPay = 0;
                    worker.SummPenalties = 0;
                    worker.SummAdditionalProfessions = 0;
                    worker.FinalResultSalary = 0;
                    worker.TransferByCard = 0;
                    worker.AdditionalProfessions.Clear();
                    worker.Penalties.Clear();
                    worker.WorkedDays.Clear();

                }
            }
            File.WriteAllText("Dictionary.json", JsonConvert.SerializeObject(companies));
        }

        public ObservableCollection<Company> ReadJsonDictionary()
        {
            ObservableCollection<Company> companies = File.Exists("Dictionary.json") ? JsonConvert.DeserializeObject<ObservableCollection<Company>>(File.ReadAllText("Dictionary.json")) : null;
            return companies;
        }

        public void WriteExcel(ObservableCollection<Company> Companies)
        {
            var report = new ExcelPackage();

            int countStep = 2;
            int countWorkers = 0;

            for (int i = 1; i < Companies.Count + 1; i++)
            {
                var sheet = report.Workbook.Worksheets.Add(Companies[i - 1].Name);
                sheet.Cells[1, 1, 1, 19].LoadFromArrays(new object[][] { new[] {"№", "ФИО", "Должность", "Оклад",
                "Часы(отработанные)", "Часы(норма)", "руб/час", "Начислено по окладу", "Отпускные", "Больничные", "Премия 10%", 
                    "Премия руководителя", "Штраф", "Итого начислено", "Аванс", "РКО", "Исп.лист", "Перечислено р/с", "Остаток к выдаче"}});
            }

            for (int i = 0; i < report.Workbook.Worksheets.Count; i++)
            {
                countStep = 2;
                // Нужно выгружать из репозитория Месяцы, а не Компании
                for (int j = 0; j < Companies[i].Workers.Count; j++)
                {
                    countWorkers++;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 1].Value = j + 1;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 2].Value = Companies[i].Workers[j].FIO;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 3].Value = Companies[i].Workers[j].MainProfession;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 4].Value = Companies[i].Workers[j].MainSalary;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 5].Value = Companies[i].Workers[j].WorkedHours;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 6].Value = Companies[i].Workers[j].NormalHours;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 7].Value = Companies[i].Workers[j].RateRUB;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 8].Value = Companies[i].Workers[j].MainResultSalary - Companies[i].Workers[j].Prize;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 9].Value = Companies[i].Workers[j].HolidayPay;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 10].Value = Companies[i].Workers[j].SickPay;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 11].Value = Companies[i].Workers[j].Prize;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 12].Value = Companies[i].Workers[j].PrizeBoss;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 13].Value = Companies[i].Workers[j].SummPenalties;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 14].Value = Companies[i].Workers[j].FinalResultSalary - Companies[i].Workers[j].SummAdditionalProfessions;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 15].Value = Companies[i].Workers[j].Prepayment;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 16].Value = Companies[i].Workers[j].RKO;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 17].Value = Companies[i].Workers[j].ExecutiveList;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 18].Value = Companies[i].Workers[j].TransferByCard;
                    report.Workbook.Worksheets[i].Cells[j + countStep, 19].Value = Companies[i].Workers[j].ResultSalary - Companies[i].Workers[j].SummAdditionalProfessions;

                    if (Companies[i].Workers[j].AdditionalProfessions.Count > 0)
                    {
                        for (int k = 0; k < Companies[i].Workers[j].AdditionalProfessions.Count; k++)
                        {
                            countWorkers++;
                            countStep++;
                            report.Workbook.Worksheets[i].Cells[j + countStep, 2].Value = Companies[i].Workers[j].FIO;
                            report.Workbook.Worksheets[i].Cells[j + countStep, 3].Value = Companies[i].Workers[j].AdditionalProfessions[k].Name;
                            report.Workbook.Worksheets[i].Cells[j + countStep, 4].Value = Companies[i].Workers[j].AdditionalProfessions[k].MainSalary;
                            report.Workbook.Worksheets[i].Cells[j + countStep, 5].Value = Companies[i].Workers[j].AdditionalProfessions[k].WorkedHours;
                            report.Workbook.Worksheets[i].Cells[j + countStep, 6].Value = Companies[i].Workers[j].AdditionalProfessions[k].NormalHours;
                            report.Workbook.Worksheets[i].Cells[j + countStep, 7].Value = Companies[i].Workers[j].AdditionalProfessions[k].RateRUB;
                            report.Workbook.Worksheets[i].Cells[j + countStep, 8].Value = Companies[i].Workers[j].AdditionalProfessions[k].ResultSalary;
                            report.Workbook.Worksheets[i].Cells[j + countStep, 19].Value = Companies[i].Workers[j].AdditionalProfessions[k].ResultSalary;
                        }
                    }
                }

                report.Workbook.Worksheets[i].Cells[countWorkers + 2, 4].Value = "Сумма";
                report.Workbook.Worksheets[i].Cells[countWorkers + 2, 5].Value = Companies[i].WorkedHours;
                report.Workbook.Worksheets[i].Cells[countWorkers + 2, 6].Value = Companies[i].NormalHours;
                report.Workbook.Worksheets[i].Cells[countWorkers + 2, 8].Formula = $"SUM(H2:H{countWorkers + 1})";
                report.Workbook.Worksheets[i].Cells[countWorkers + 2, 14].Formula = $"SUM(N2:N{countWorkers + 1})";
                report.Workbook.Worksheets[i].Cells[countWorkers + 2, 19].Formula = $"SUM(S2:S{countWorkers + 1})";

                report.Workbook.Worksheets[i].Cells[countWorkers + 3, 1].Value = "Плановый фонд";
                report.Workbook.Worksheets[i].Cells[countWorkers + 3, 2].Value = Companies[i].PlanningSalaryFund;

                report.Workbook.Worksheets[i].Cells[countWorkers + 4, 1].Value = "Фактический фонд";
                report.Workbook.Worksheets[i].Cells[countWorkers + 4, 2].Value = Companies[i].FactSalaryFund;

                report.Workbook.Worksheets[i].Cells[countWorkers + 5, 1].Value = "Расхождения";
                report.Workbook.Worksheets[i].Cells[countWorkers + 5, 2].Value = Companies[i].PlanningSalaryFund - Companies[i].FactSalaryFund;
                countWorkers = 0;
            }


            for (int i = 0; i < report.Workbook.Worksheets.Count; i++)
            {
                report.Workbook.Worksheets[i].Cells[1, 1, 1, 19].AutoFitColumns();
                report.Workbook.Worksheets[i].Column(1).Width = 20;
                report.Workbook.Worksheets[i].Column(2).Width = 25;
                report.Workbook.Worksheets[i].Cells[1, 1, 1, 19].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                report.Workbook.Worksheets[i].Cells[1, 1, 1, 19].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
            }

            File.WriteAllBytes("Output.xlsx", report.GetAsByteArray());

        }
    }
}
