using NicesleepingShop.DataAccess.Utils;

namespace NicesleepingShop.DataAccess.Common.Interfaces;

public interface ISearchable<TModel>
{
    public Task<(int ItemsCount, IList<TModel>)> Searchable(string search,
        PaginationParams @params);
}
