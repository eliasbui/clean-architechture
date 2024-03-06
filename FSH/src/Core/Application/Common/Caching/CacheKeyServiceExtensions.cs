namespace FSH.Application.Common.Caching;

public static class CacheKeyServiceExtensions
{
    public static string GetCacheKey<TEntity>(this ICacheKeyService cacheKeyService, object id,
        bool includeTenantId = true)
        where TEntity : IEntity
    {
        return cacheKeyService.GetCacheKey(typeof(TEntity).Name, id, includeTenantId);
    }
}