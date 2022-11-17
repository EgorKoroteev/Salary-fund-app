using SalaryFond.Models.Interfaces;
using System;
using System.Collections.Generic;
using SalaryFond.Services.Interfaces;
using System.Collections.ObjectModel;
using SalaryFond.Models;

namespace SalaryFond.Services.Base
{
    abstract class RepositoryInMemory<T> : IRepository<T> where T : IEntity
    {
        private readonly ObservableCollection<T> _Entities = new ObservableCollection<T>();
        private int _LastId;

        protected RepositoryInMemory() { }

        protected RepositoryInMemory(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public void Add(T entity)
        {
            if (entity is null) throw new ArgumentException(nameof(entity));

            if (_Entities.Contains(entity)) return;

            entity.Id = ++_LastId;
            _Entities.Add(entity);
        }

        public T GetOne(int i) => _Entities[i];

        public ObservableCollection<T> GetAll() => _Entities;

        public bool Remove(T entity) => _Entities.Remove(entity);

        public void RemoveAll()
        {
            _Entities.Clear();
        }

        public void Update(int id, T entity)
        {
            if (entity is null) throw new ArgumentException(nameof(entity));
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), id, "Индекс не может быть меньше 1");

            if (_Entities.Contains(entity)) return;

            var db_entity = ((IRepository<T>)this).Get(id);
            if (db_entity is null)
            {
                throw new InvalidOperationException("Редактируемый элемент не найден в репозитории");
            }

            Update(entity, db_entity);
        }

        protected abstract void Update(T Source, T End);

        public int GetCount() => _Entities.Count;
    }
}
