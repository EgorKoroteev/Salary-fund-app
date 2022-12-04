using SalaryFond.Models.Interfaces;
using System.Collections.ObjectModel;
using System.Linq;

namespace SalaryFond.Services.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T entity);

        ObservableCollection<T> GetAll();

        T Get(int id) => GetAll().FirstOrDefault(entity => entity.Id == id);

        bool Remove(T entity);

        void Update(int id, T entity);
    }
}