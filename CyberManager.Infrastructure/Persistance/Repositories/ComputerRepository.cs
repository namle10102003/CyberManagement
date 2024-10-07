using CyberManager.Application.Common.Interfaces.Persistences;
using CyberManager.Domain.Entities;
using CyberManager.Infrastructure.Persistance.DataAccess;
using CyberManager.Infrastructure.Persistance.TypeHandlers;
using Dapper;

namespace CyberManager.Infrastructure.Persistance.Repositories;

public class ComputerRepository : IComputerRepository
{
    private readonly IDataAccess _dataAccess;

    public ComputerRepository(IDataAccess dataAccess)
    {
        SqlMapper.AddTypeHandler(new EnumTypeHandler<ComputerStatus>());
        _dataAccess = dataAccess;
    }

    public async Task Create(Computer computer)
    {
        string sql = $@"
            INSERT INTO Computers (Name, CostPerHour, Status)
            VALUES (@Name, @CostPerHour, '{computer.Status}')
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            await connect.ExecuteAsync(sql, computer);
        }
    }

    public async Task Delete(int id)
    {
        string sql = @"
            DELETE FROM Computers
            WHERE Id = @id
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            await connect.ExecuteAsync(sql, new { id });
        }    
    }

    public async Task<IEnumerable<Computer>> Get(
        string? name = null,
        int? costPerHour = null,
        ComputerStatus? status = null)
    {
        SqlBuilder builder = new SqlBuilder();

        if (name is not null)
            builder.Where(@"Name = @name", new { name });

        if (costPerHour is not null)
            builder.Where(@"CostPerHour = @costPerHour", new { costPerHour });

        if (status is not null)
            builder.Where($"Status = '{status}'");

        var template = builder.AddTemplate("SELECT * FROM Computers /**where**/");

        using (var connect = _dataAccess.CreateConnection())
        {
            var result = await connect.QueryAsync<Computer>(template.RawSql, template.Parameters);
            return result;
        }
    }

    public async Task<Computer> GetById(int id)
    {
        string query = @"
            SELECT * FROM Computers
            WHERE Id = @id
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            var result = await connect.QuerySingleAsync<Computer>(query, new { id });
            return result;
        }
    }

    public async Task Update(Computer computer)
    {
        string sql = $@"
            UPDATE Computers
            SET Name = @Name,
                CostPerHour = @CostPerHour,
                Status = '{computer.Status}'
            WHERE Id = @Id
        ";

        using (var connection = _dataAccess.CreateConnection())
        {
            await connection.ExecuteAsync(sql, computer);
        }
    }
}