﻿using Microsoft.EntityFrameworkCore;
using PersonRegistry.Core.Models;
using PersonRegistry.Core.Services;
using PersonRegistry.Data;

namespace PersonRegistry.Services;

public class DbService : IDbService
{
    protected IPersonRegistryDbContext _context;

    public DbService(IPersonRegistryDbContext context)
    {
        _context = context;
    }
    public void Create<T>(T entity) where T : Entity
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete<T>(T entity) where T : Entity
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public void Update<T>(T entity) where T : Entity
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public List<T> GetAll<T>() where T : Entity
    {
        return _context.Set<T>().ToList();
    }

    public T GetById<T>(int id) where T : Entity
    {
        return _context.Set<T>().SingleOrDefault(e => e.Id == id);
    }

    public IQueryable<T> Query<T>() where T : Entity
    {
        return _context.Set<T>().AsQueryable();
    }
}