using System.Data;
using CyberManager.Domain.Entities;
using Dapper;

namespace CyberManager.Infrastructure.Persistance.TypeHandlers;

public abstract class SqliteTypeHandler<T> : SqlMapper.TypeHandler<T>
{
    // Parameters are converted by Microsoft.Data.Sqlite
    public override void SetValue(IDbDataParameter parameter, T? value)
        => parameter.Value = value;
}

public class DateTimeHandler : SqliteTypeHandler<DateTime>
{
    public override DateTime Parse(object value)
        => DateTime.Parse((string)value);
}

public class BillTypeHandler : SqlMapper.TypeHandler<BillType>
{
    public override void SetValue(IDbDataParameter parameter, BillType value)
    {
        parameter.DbType = DbType.String;
        parameter.Value = value.ToString();
    } 

    public override BillType Parse(object value)
        => Enum.Parse<BillType>((string)value);
}