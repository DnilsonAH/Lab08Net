using Lab08_LINQ.Core.Entities;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Lab08_LINQ.Core.Repositories;
    
public class CategoriaRepository: GenericRepository<Categoria> , ICategoriaRepository
{
    public CategoriaRepository(TiendadbDbContext dbContext) : base(dbContext)
    {
        
    }
}