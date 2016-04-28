﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HausbauBuch.Classes;
using HausbauBuch.Views;
using SQLite;

namespace HausbauBuch.Business
{
    public interface IController<T> where T : Entity, new()
    {
        Task<List<T>> Get();
        Task<T> Get(int id);

        Task<ObservableCollection<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);

        Task<T> Get(Expression<Func<T, bool>> predicate);

        AsyncTableQuery<T> AsQueryable();

        Task<int> Insert(T entity);

        Task<int> Update(T entity);

        Task<int> Delete(T entity);

        Task<int> Count(Expression<Func<T, bool>> predicate = null);
    }

    public class EntityController<T> : IController<T> where T : Entity, new()
    {
        private SQLiteAsyncConnection _db;

        public EntityController(SQLiteAsyncConnection db)
        {
            this._db = db;
        }

        public AsyncTableQuery<T> AsQueryable()
        {
            return _db.Table<T>();
        }

        public async Task<int> Delete(T entity)
        {
            return await _db.DeleteAsync(entity);
        }

        public async Task<int> Count(Expression<Func<T, bool>> predicate = null)
        {
            var query = _db.Table<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.CountAsync();
        }

        public async Task<List<T>> Get()
        {
            return await _db.Table<T>().ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _db.FindAsync<T>(predicate);
        }

        public async Task<T> Get(int id)
        {
            return await _db.FindAsync<T>(id);
        }

        public async Task<ObservableCollection<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = _db.Table<T>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (orderBy != null)
            {
                query = query.OrderBy<TValue>(orderBy);
            }

            var collection = new ObservableCollection<T>();
            var items = await query.ToListAsync();
            foreach (var item in items)
            {
                collection.Add(item);
            }

            return collection;
        }

        public async Task<int> Insert(T entity)
        {
            return await _db.InsertAsync(entity);
        }

        public async Task<int> Update(T entity)
        {
            return await _db.UpdateAsync(entity);
        }
    }
}