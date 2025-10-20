namespace Lab08_LINQ.Core.Services.Interfaces;

public interface IGenericService<Tdto> where Tdto : class
{
    Task<IEnumerable<Tdto>> GetAllAsync();
    Task<Tdto?> GetByIdAsync(int id);
    Task AddAsync(Tdto entity);
    Task UpdateAsync(Tdto entity);
    Task DeleteAsync(int id);
}