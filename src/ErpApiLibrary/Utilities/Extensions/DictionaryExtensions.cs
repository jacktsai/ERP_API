namespace System.Collections.Generic
{
    /// <summary>
    /// Dictionary 的擴充方法。
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// 取得 key 的值。
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="key">The key.</param>
        /// <returns>如果 key 存在則回傳值；否則回傳 default。</returns>
        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("source");
            }

            if (key != null)
            {
                TValue value;
                if (dictionary.TryGetValue(key, out value))
                {
                    return value;
                }
            }

            return default(TValue);
        }
    }
}