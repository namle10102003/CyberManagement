using CyberManager.Application.Common.Interfaces.Persistences;
using CyberManager.Domain.Entities;
using CyberManager.Infrastructure.Persistance.DataAccess;
using CyberManager.Infrastructure.Persistance.TypeHandlers;
using Dapper;

namespace CyberManager.Infrastructure.Persistance.Repositories;

public class BillRepository : IBillRepository
{
    private readonly IDataAccess _dataAccess;

    public BillRepository(IDataAccess dataAccess)
    {
        SqlMapper.AddTypeHandler(new DateTimeHandler());
        SqlMapper.AddTypeHandler(new EnumTypeHandler<BillType>());
        _dataAccess = dataAccess;
    }

    public async Task Create(Bill bill)
    {
        string sql = $@"
            INSERT INTO Bills (Title, Type, Description, Cash, DateTime)
            VALUES (@Title, '{bill.Type}', @Description, @Cash, @DateTime)
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            await connect.ExecuteAsync(sql, bill);
        }
    }

    public async Task Delete(int id)
    {
        string sql = $@"
            DELETE FROM Bills WHERE Id = @id
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            await connect.ExecuteAsync(sql, new { id });
        }
    }

    public async Task<IEnumerable<Bill>> Get(
        BillType? type = null,
        DateTime? dateStart = null,
        DateTime? dateEnd = null
    )
    {
        SqlBuilder builder = new SqlBuilder();

        if (type is not null)
            builder.Where($"Type = @Type", new { Type = type.ToString() });

        if (dateStart is not null)
            builder.Where($"DateTime >= @dateStart", new { dateStart });

        if (dateEnd is not null)
            builder.Where($"DateTime <= @dateEnd", new { dateEnd });

        var template = builder.AddTemplate("SELECT * FROM Bills /**where**/");

        using (var connection = _dataAccess.CreateConnection())
        {
            var result = await connection.QueryAsync<Bill>(template.RawSql, template.Parameters);
            return result;
        }
    }

    public async Task<Bill> GetById(int id)
    {
        string query = @"
            SELECT * FROM Bill WHERE Id = @id
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            var result = await connect.QuerySingleAsync<Bill>(query, id);
            return result;
        }
    }

    public async Task Update(Bill bill)
    {
        string sql = $@"
            UPDATE Bills
            SET Title = @Title
                Type = '{bill.Type}'
                Description = @Description
                Cash = @Cash
                DateTime = @DateTime
            WHERE Id = @Id
        ";

        using (var connection = _dataAccess.CreateConnection())
        {
            await connection.ExecuteAsync(sql, bill);
        }
    }
}