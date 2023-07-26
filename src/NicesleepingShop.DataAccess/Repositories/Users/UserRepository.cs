using Dapper;
using NicesleepingShop.DataAccess.Interfaces.Users;
using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Users;

namespace NicesleepingShop.DataAccess.Repositories.Users;

public class UserRepository : BaseRepository,IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select count(*) from users;";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;

        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.\"users\"(first_name, last_name, phone_number, phone_number_confirmed,  address, password_hash, salt, created_at, updated_at, role_type)" +
                "VALUES (@FirstName, @LastName, @PhoneNumber, @PhoneNumberConfirmed,  @Address, @PasswordHash, @Salt, @CreatedAt, @UpdatedAt, @RoleType);";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync(); 
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM users WHERE id=@Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch { return 0; }
        finally { await _connection.CloseAsync(); }
    }

    public async Task<IList<User>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM public.users ORDER BY id desc offset {@params.SkipCount} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<User>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<User>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public async Task<User?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM users where id=@Id";
            var result = await _connection.QuerySingleAsync<User>(query, new { Id = id });
            return result;
        }
        catch
        {
            return null;
        }
        finally { await _connection.CloseAsync(); }
    }

    public Task<(int ItemsCount, IList<User>)> Searchable(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.\"users\" " +
                    "SET first_name=@FirstName, last_name=@LastName, phone_number=@PhoneNumber, phone_number_confirmed=@PhoneNumberConfirmed, address=@Address, password_hash=@PasswordHash, salt=@Salt, created_at=@CreatedAt, updated_at=@UpdatedAt, role_type=@RoleType " +
                    "WHERE id = @Id;";
            entity.Id = id;

            var result = await _connection.ExecuteAsync(query, entity);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
