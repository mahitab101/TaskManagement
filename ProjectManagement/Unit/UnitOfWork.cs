using ProjectManagement.Contracts;
using ProjectManagement.Models;
using ProjectManagement.Repositories;


namespace ProjectManagement.Unit
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IBaseRepository<Project> Projects {  get; private set; }
        public IBaseRepository<TaskGroup> TaskGroups { get;private set; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
            Projects = new BaseRepository<Project>(_context);
            TaskGroups = new BaseRepository<TaskGroup>(_context);
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
