using Lab08_LINQ.Core.Entities;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Infrastructure;

namespace Lab08_LINQ.Core.Repositories;

public class PagosRepository: GenericRepository<Pago>, IPagosRepository
{
    public PagosRepository(TiendadbDbContext context) : base(context)
    {
    }
}