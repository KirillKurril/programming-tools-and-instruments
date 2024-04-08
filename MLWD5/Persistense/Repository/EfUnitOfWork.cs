using Domain.Abstractions;
using MLWD5.Domain.Abstractions;
using MLWD5.Domain.Entities;
using MLWD5.Persistense.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistense.Repository
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<Employee>> _employeeRepository;
        private readonly Lazy<IRepository<Duty>> _dutyRepository;
        public EfUnitOfWork(AppDbContext context)
        {
            _context = context;
            _employeeRepository = new Lazy<IRepository<Employee>>(() =>
            new EfRepository<Employee>(context));
            _dutyRepository = new Lazy<IRepository<Duty>>(() =>
            new EfRepository<Duty>(context));
        }
        public IRepository<Employee> CourseRepository
        => _employeeRepository.Value;
        public IRepository<Duty> TraineeRepository
        => _dutyRepository.Value;
        public async Task CreateDataBaseAsync() =>
        await _context.Database.EnsureCreatedAsync();
        public async Task DeleteDataBaseAsync() =>
        await _context.Database.EnsureDeletedAsync();
        public async Task SaveAllAsync() =>
        await _context.SaveChangesAsync();
    }
}
