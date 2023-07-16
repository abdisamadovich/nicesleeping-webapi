using NicesleepingShop.DataAccess.Utils;

namespace NicesleepingShop.DataAccess.Common.Interfaces;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);
}
