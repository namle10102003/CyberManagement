using CyberManager.Application.Common.Interfaces.Persistences;
using CyberManager.Domain.Entities;
using CyberManager.Infrastructure.Persistance.DataAccess;
using CyberManager.Infrastructure.Persistance.TypeHandlers;
using Dapper;

namespace CyberManager.Infrastructure.Persistance.Repositories;

public class ComputerErrorRepository : IComputerErrorRepository
{
    private readonly IDataAccess _dataAccess;

    public ComputerErrorRepository(IDataAccess dataAccess)
    {
        SqlMapper.AddTypeHandler(new EnumTypeHandler<Devices>());
        _dataAccess = dataAccess;
    }

    public async Task Create(ComputerError error)
    {
        string sql = $@"
            INSERT INTO ComputerErrors (ComputerId, Device, Description)
            VALUES (@ComputerId, '{error.Device}', @Description)
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            await connect.ExecuteAsync(sql, error);
        }
    }

    public async Task Delete(int id)
    {
        string sql = @"
            DELETE FROM ComputerErrors
            WHERE Id = @id
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            await connect.ExecuteAsync(sql, new { id });
        }
    }

    public async Task<IEnumerable<ComputerError>> Get(
        int? computerId = null,
        Devices? device = null,
        bool? isSolve = null)
    {
        SqlBuilder builder = new SqlBuilder();

        if (computerId is not null)
            builder.Where("ComputerId = @computerId", new { computerId });

        if (device is not null)
            builder.Where($"Device = '{device}'");

        if (isSolve is not null)
            builder.Where("IsSolve = @isSolve", new { isSolve });
        
        var template = builder.AddTemplate("SELECT * FROM ComputerErrors /**where**/");

        using (var connect = _dataAccess.CreateConnection())
        {
            var result = await connect.QueryAsync<ComputerError>(template.RawSql, template.Parameters);
            return result;
        }
    }

    public async Task<ComputerError> GetById(int id)
    {
        string query = @"
            SELECT * FROM ComputerErrors
            WHERE Id = @id
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            var result = await connect.QuerySingleAsync<ComputerError>(query, new { id });
            return result;
        }
    }

    public async Task Update(ComputerError error)
    {
        string sql = @"
            UPDATE ComputerErrors
            SET Description = @Description,
                IsSolve = @IsSolve
            WHERE Id = @Id
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            await connect.ExecuteAsync(sql, error);
        }
    }
}