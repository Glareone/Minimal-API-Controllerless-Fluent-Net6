namespace Chapter08_Dapper.Repository;
using Chapter08_Dapper.Repository.Entities;

public interface IIcecreamsRepository
{
    Task<IEnumerable<Icecream>> GetIcecreams();

    Task CreateIcecream(Icecream icecream);
}
