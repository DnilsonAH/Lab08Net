using AutoMapper;
using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Entities;
using Lab08_LINQ.Core.Repositories.Interfaces;
using Lab08_LINQ.Core.Services.Interfaces;

namespace Lab08_LINQ.Core.Services;

public class CategoriaService: GenericService<Categoria, CategoriaDto>, ICategoriaService
{
    protected readonly ICategoriaRepository _categoriaRepository;
    public CategoriaService(ICategoriaRepository repository, IMapper mapper): base(repository, mapper)
    {
        _categoriaRepository = repository;
    }
}