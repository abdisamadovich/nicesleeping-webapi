using Dapper;
using NicesleepingShop.DataAccess.Common.Interfaces;
using NicesleepingShop.DataAccess.Interfaces.Products;
using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.DataAccess.ViewModels.Products;
using NicesleepingShop.Domain.Entities.Products;

namespace NicesleepingShop.DataAccess.Repositories.Products;

public class ProductRepository : BaseRepository, IProductRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from products";
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

    public async Task<int> CreateAsync(Product entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.products(category_id, name, status, image_path, unit_price, description, created_at, updated_at) " +
                "VALUES (@CategoryId, @Name, @Status, @ImagePath, @UnitPrice, @Description, @CreatedAt, @UpdatedAt);";
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
            string query = $"delete from products where id = @Id";
            var result = await _connection.ExecuteAsync(query,new {Id = id});
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

    public async Task<IList<Product>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from products " +
                $"order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Product>(query)).ToList();
            return result;
        }
        catch
        {

            return new List<Product>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<ProductViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from products where id = {id}";
            var result = await _connection.QuerySingleAsync<ProductViewModel>(query);
            return result; 
        }
        catch 
        {

            return null;
        }
        finally
        {
            await _connection.CloseAsync() ;
        }
    }

    public Task<(int ItemsCount, IList<ProductViewModel>)> Searchable(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Product entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE public.products " +
                $"SET category_id = @CategoryId, name = @Name, status = @Status, " +
                $"image_path = @ImagePath, unit_price = @UnitPrice, description = @Description, " +
                $"created_at = @CreatedAt, updated_at = @UpdatedAt WHERE id = {id};";
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

   
}
