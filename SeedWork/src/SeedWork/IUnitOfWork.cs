using System.Threading;
using System.Threading.Tasks;

namespace JBCode.SeedWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}