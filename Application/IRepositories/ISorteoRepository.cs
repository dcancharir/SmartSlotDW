using Domain;
namespace Application.IRepositories;
public interface ISorteoRepository {
    public Task<bool> CreateSorteo(Sorteo registro);
    public Task<IEnumerable<Sorteo>> GetAllSorteoByCodSala(int codsala);
}
