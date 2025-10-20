using AutoMapper;
using Lab08_LINQ.Core.DTOs;
using Lab08_LINQ.Core.Entities;

namespace Lab08_LINQ.Core.Mapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        // 📝 Mapeo de ESCRITURA (DTOs a Entidades - Input para POST/PUT)

        // Categoria
        CreateMap<CategoriaDto, Categoria>(); // DTO -> Entidad
        // Cliente
        CreateMap<ClienteDto, Cliente>();     // DTO -> Entidad
        // Orden
        CreateMap<OrdeneDto, Ordene>();       // DTO -> Entidad
        // Producto
        CreateMap<ProductoDto, Producto>();   // DTO -> Entidad
        // Pago
        CreateMap<PagoDto, Pago>();           // DTO -> Entidad
        
        //Detalles Orden
        CreateMap<DetallesOrdenDto, Detallesorden>(); // DTO -> Entidad

        // 📚 Mapeo de LECTURA (Entidades a DTOs - Output para GET)
        
        // Categoria
        CreateMap<Categoria, CategoriaDto>(); // Entidad -> DTO
        // Cliente
        CreateMap<Cliente, ClienteDto>();     // Entidad -> DTO
        // Orden
        CreateMap<Ordene, OrdeneDto>();       // Entidad -> DTO
        // Producto
        CreateMap<Producto, ProductoDto>();   // Entidad -> DTO
        // Pago
        CreateMap<Pago, PagoDto>();           // Entidad -> DTO
        //Detalles Orden
        CreateMap<Detallesorden, DetallesOrdenDto>(); // Entidad -> DTO
        
        // Mapeo personalizado para OrdenDetalleDto
        CreateMap<Detallesorden, OrdenDetalleDto>()
            .ForMember(dest => dest.NombreProducto, opt => opt.MapFrom(src => src.Producto.Nombre)); // Entidad -> DTO
    }
}