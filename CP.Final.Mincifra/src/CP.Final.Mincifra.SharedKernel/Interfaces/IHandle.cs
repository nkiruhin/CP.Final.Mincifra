using System.Threading.Tasks;

namespace CP.Final.Mincifra.SharedKernel.Interfaces
{
    public interface IHandle<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}