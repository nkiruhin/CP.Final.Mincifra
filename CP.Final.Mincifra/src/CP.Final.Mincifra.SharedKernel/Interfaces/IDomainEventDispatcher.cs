using CP.Final.Mincifra.SharedKernel;
using System.Threading.Tasks;

namespace CP.Final.Mincifra.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}