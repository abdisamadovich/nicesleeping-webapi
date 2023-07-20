using Dapper;
using NicesleepingShop.DataAccess.Interfaces.Categories;
using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Categories;
using static Dapper.SqlMapper;

namespace NicesleepingShop.DataAccess.Repositories.Categories;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync(Category entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.categories(name, description, created_at, updated_at) " +
                "VALUES (@Name, @Description, @CreatedAt, @UpdatedAt);";
            var result = await _connection.ExecuteAsync(query,entity);
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
            string query = "DELETE FROM categories WHERE id = @Id";
            var result = await _connection.ExecuteAsync(query, new {Id = id});
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

    public async Task<IList<Category>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM categories order by id desc " +
                $"offset {@params.SkipCount} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Category>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Category>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<Category> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Category entity)
    {
        throw new NotImplementedException();
    }
}
