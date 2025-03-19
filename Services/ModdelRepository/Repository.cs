using EntityManagement.DataAcces.DbContext_Entity;
using ServicesManagement.ModdelRepository.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ModdelRepozitory
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly HospitalContext _context;

        protected Repository(HospitalContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
            => _context.Set<TEntity>().Add(entity);

        public async Task AddAsync(TEntity entity)
            => await _context.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity)
            => _context.Set<TEntity>().Update(entity);

        public IQueryable<TEntity> GetAll()
            => _context.Set<TEntity>().AsQueryable();

        public TEntity GetById(int id)
            => _context.Set<TEntity>().Find(id);

        public async Task<TEntity> GetByIdAsync(int id)
            => await _context.Set<TEntity>().FindAsync(id);

        public void Delete(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);

        public int SaveChanges()
            => _context.SaveChanges();

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }

}
