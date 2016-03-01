using System;

namespace RedisClient
{
    /// <summary>
    /// Cache manager contract
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// Adds an item to the cache with the specified key.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="key">The key.</param>
        /// <param name="item">The item.</param>
        /// <param name="expirationPeriod">The expiration period.</param>
        /// <returns>
        /// True if the adding has succeeded. False otherwise
        /// </returns>
        bool Add<TItem>(string key, TItem item, TimeSpan expirationPeriod);

        /// <summary>
        /// Gets an item from the cache with the specified key.
        /// </summary>
        /// <typeparam name="TItem">The type of the item.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>The item from the cache</returns>
        TItem Get<TItem>(string key);

       
    }
}
