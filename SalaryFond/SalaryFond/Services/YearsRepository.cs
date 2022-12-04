using SalaryFond.Models;
using SalaryFond.Services.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace SalaryFond.Services
{
    internal class YearsRepository
    {
        private readonly ObservableCollection<YearSalary> _Entities = new ObservableCollection<YearSalary>();
        private int _LastId;

        public YearsRepository() { }

        protected YearsRepository(IEnumerable<YearSalary> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public void Add(YearSalary entity)
        {
            if (entity is null) throw new ArgumentException(nameof(entity));

            if (_Entities.Contains(entity)) return;

            entity.Id = ++_LastId;
            _Entities.Add(entity);
        }

        public YearSalary GetOne(int i) => _Entities[i];

        public ObservableCollection<YearSalary> GetAll() => _Entities;

        public bool Remove(YearSalary entity) => _Entities.Remove(entity);

        public void RemoveAll()
        {
            _Entities.Clear();
        }

        public void Update(int id, YearSalary entity)
        {
            if (entity is null) throw new ArgumentException(nameof(entity));
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), id, "Индекс не может быть меньше 1");

            if (_Entities.Contains(entity)) return;

            var db_entity = ((IRepository<YearSalary>)this).Get(id);
            if (db_entity is null)
            {
                throw new InvalidOperationException("Редактируемый элемент не найден в репозитории");
            }

            Update(entity, db_entity);
        }

        protected void Update(YearSalary Source, YearSalary End)
        {
            End.Name = Source.Name;
            End.Months.Clear();
            for (int i = 0; i < Source.Months.Count; i++)
            {
                End.Months.Add(Source.Months[i]);
            }
        }

        public int GetCount() => _Entities.Count;

        public YearSalary Get(string NumberYear) => GetAll().FirstOrDefault(g => g.Name == NumberYear);

        public void UpdateBD(YearSalary Source, YearSalary End)
        {
            End.Name = Source.Name;
            for (int i = 0; i < Source.Months.Count; i++)
            {
                End.Months.Add(Source.Months[i]);
            }
        }
    }
}