using Dapper;
using NicesleepingShop.DataAccess.Interfaces.Categories.Discounts;
using NicesleepingShop.DataAccess.Utils;
using NicesleepingShop.Domain.Entities.Discounts;

namespace NicesleepingShop.DataAccess.Repositories.Discounts
{
    public class DiscountRepository : BaseRepository,IDiscountRepository
    {
        public async Task<long> CountAsync()
        {
            try
            {
                await _connection.OpenAsync();
                string query = "select count(*) from discounts";
                var res = await _connection.QuerySingleAsync<long>(query);
                return res;
                
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

        public async Task<int> CreateAsync(Discount entity)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "INSERT INTO public.discounts(name, description, created_at, updated_at)" +
                    "VALUES (@Name, @Description, @CreatedAt, @UpdatedAt);";
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
                string query = "DELETE FROM discounts WHERE id = @Id";
                var result = await _connection.ExecuteAsync(query, new { Id = id });
                return result;
            }
            catch { return 0; }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<IList<Discount>> GetAllAsync(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM discounts order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
                var result = (await _connection.QueryAsync<Discount>(query)).ToList();
                return result;
            }
            catch
            {
                return new List<Discount>();
            }
            finally { await _connection.CloseAsync(); }
        }

        public async Task<Discount?> GetByIdAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string query = $"SELECT * FROM discounts where id = @Id";
                var result = await _connection.QuerySingleAsync<Discount>(query, new { Id = id });
                return result;
            }
            catch { return null; }
            finally { await _connection.CloseAsync(); } 
        }
        public Task<int> UpdateAsync(long id, Discount entity)
        {
            throw new NotImplementedException();
        }
    }
}
