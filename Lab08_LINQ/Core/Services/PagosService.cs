using AutoMapper;
using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Entities;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Core.Services.Interfaces;

namespace Lab08_LINQ.Core.Services;

public class PagosService: GenericService<Pago, PagoDto>, IPagosService
{
    protected readonly IPagosRepository _pagosRepository;
    public PagosService(IPagosRepository repository, IMapper mapper) : base(repository , mapper)
    {
        _pagosRepository = repository;
    }
    
    
}