using System.Data;

namespace Chapter08_Dapper.Repository;
using Chapter08_Dapper.Repository.Entities;
using Dapper;

internal class IcecreamsRepository : IIcecreamsRepository
{
    private readonly DapperContext _context;

    public IcecreamsRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Icecream>> GetIcecreams()
    {
        var query = "SELECT * FROM Icecreams";
        using var connection = _context.CreateConnection();
        var result = await connection.QueryAsync<Icecream>(query);
        return result.ToList();
    }

    public async Task CreateIcecream(Icecream icecream)
    {
        var query = "INSERT INTO Icecreams (Name, Description) VALUES(@Name, @Description)";
        var parameters = new DynamicParameters();
        parameters.Add("Name", icecream.Name, DbType.String);
        parameters.Add("Description", icecream.Description,
            DbType.String);

        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(query, parameters);
    }
}
