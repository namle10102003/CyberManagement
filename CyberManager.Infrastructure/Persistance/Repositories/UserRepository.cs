using CyberManager.Application.Common.Interfaces.Persistences;
using CyberManager.Domain.Entities;
using CyberManager.Infrastructure.Persistance.DataAccess;
using Dapper;

namespace CyberManager.Infrastructure.Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDataAccess _dataAccess;

    public UserRepository(IDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task Create(User user)
    {
        string query = @"
            INSERT INTO users (userName, password, credit)
            VALUES (@UserName, @Password, @Credit)
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            await connect.ExecuteAsync(query, user);
        }
    }

    public async Task<User> Get(string userName)
    {
        string query = @"
            SELECT * 
            FROM users
            WHERE userName = @UserName
        ";
        var parameter = new { UserName = userName };

        using (var connect = _dataAccess.CreateConnection())
        {
            var result = await connect.QuerySingleAsync<User>(query, parameter);
            return result;
        }
    }

    public async Task Update(User user)
    {
        string query = @"
            UPDATE users
            SET password = @Password,
                credit = @Credit
            WHERE id = @Id
        ";

        using (var connect = _dataAccess.CreateConnection())
        {
            await connect.ExecuteAsync(query, user);
        }
    }
}