using SalaryFond.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryFond.Services.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T entity);

        IEnumerable<T> GetAll();

        T Get(int id) => GetAll().FirstOrDefault(entity => entity.Id == id);

        bool Remove(T entity);

        void Update(int id, T entity);
    }
}
