using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyclinicApplication.Data.Models;

namespace PolyclinicApp.WPF.Services.Users
{
    internal interface IDataService<T>
    {
        Task Create(T entity);

        Task Delete(T entity);

        Task Update(T oldEntity, T newEntity);

        User? GetByLogin(string login);
        Task<IEnumerable<T>> GetAll();
    }
}
