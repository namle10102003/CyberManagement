using CyberManager.Application.Common.Interfaces.Persistences;
using CyberManager.Domain.Entities;
using CyberManager.Infrastructure.Persistance.DataAccess;
using Dapper;

namespace CyberManager.Infrastructure.Persistance.Repositories;

public class SoftwareRepository : ISoftwareRepository
{
    private readonly IDataAccess _dataAccess;

    public SoftwareRepository(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task Create(Software software)
    {
        string sql = @"
            INSERT INTO Softwares (Name, Path)
            VALUES (@Name, @Path)
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            await connect.ExecuteAsync(sql, software);
        }
    }

    public async Task Delete(int id)
    {
        string sql = @"
            DELETE FROM Softwares WHERE id = @id
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            await connect.ExecuteAsync(sql, new { id });
        }
    }

    public async Task<IEnumerable<Software>> Get(string? name = null)
    {
        SqlBuilder builder = new SqlBuilder();

        if (name is not null)
            builder.Where(@"Name = @name", new { name });

        var template = builder.AddTemplate("SELECT * FROM Softwares /**where**/");

        using (var connect = _dataAccess.CreateConnection())
        {
            var result = await connect.QueryAsync<Software>(template.RawSql, template.Parameters);
            return result;
        }
    }

    public async Task<Software> GetById(int id)
    {
        string query = @"
            SELECT * FROM Softwares
            WHERE Id = @id
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            var result = await connect.QuerySingleAsync<Software>(query, new { id });
            return result;
        }       
    }

    public async Task Update(Software software)
    {
        string sql = @"
            UPDATE Softwares
            SET Name = @Name,
                Path = @Path
            WHERE Id = @Id
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            await connect.ExecuteAsync(sql, software);
        }
    }
}