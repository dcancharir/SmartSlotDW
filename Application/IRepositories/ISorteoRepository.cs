using Domain;
namespace Application.IRepositories;
public interface ISorteoRepository {
    public Task<bool> CreateSorteo(Sorteo registro);
}
