﻿using Domain.Commons;

namespace Data.IRepository;

public interface IRepository<T> where T : Auditable
{
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> SelectByIdAsync(long id);
    IQueryable<T> SelectAll();
}
