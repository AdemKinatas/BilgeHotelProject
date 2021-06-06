using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameworkCore.Context;
using Entities.Abctract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfEntityRepositoryBase<TEntity> : Abstract.IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {      
        public void Add(TEntity entity)
        {
            using var context = new HotelDbContext();
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();

        }

        public async Task AddAsyc(TEntity entity)
        {
            using var context = new HotelDbContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            using var context = new HotelDbContext();
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            using var context = new HotelDbContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new HotelDbContext();
            return context.Set<TEntity>().FirstOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new HotelDbContext();
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using var context = new HotelDbContext();
            return filter == null
                ? await context.Set<TEntity>().ToListAsync()
                : await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new HotelDbContext();
            return await context.Set<TEntity>().AsQueryable().FirstOrDefaultAsync(filter);
        }

        public void Update(TEntity entity)
        {
            using var context = new HotelDbContext();
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new HotelDbContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
