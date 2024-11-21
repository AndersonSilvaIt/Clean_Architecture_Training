using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;

namespace CleanArchitecture.Persistence.Repositories
{
    public class UnifOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnifOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
