﻿using PolyclinicApplication.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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