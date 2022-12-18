namespace Cache.Core.Interfaces
{
    public interface ICacheProvider
    {
        #region sync methods

        #region Setter methods

        /// <summary>
        /// Milisaniye cinsinde TTL (cache timeout) alır ve tekil kayıt oluşturur/günceller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout">Millisecond</param>
        void Set<T>(string key, T value, TimeSpan? TTL) where T : class;

        /// <summary>
        /// Milisaniye cinsinde TTL (cache timeout) alır ve tekil kayıt oluşturur/günceller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout">Millisecond</param>
        void Set<T>(string key, IList<T> value, TimeSpan? TTL) where T : class;

        #endregion Setter methods

        #region Getter methods
        /// <summary>
        /// Verilen key ile cache kaydı döndürür. Eğer cache yoksa null döner.
        /// Spesifik sorgulama yapar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        string Get(string key);

        #endregion Getter methods

        /// <summary>
        /// Modele dair herhangi bir cache olup olmadığını denetler.
        /// Bir patterne göre sorgulama yapar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        bool IsAnyIndexExist(string keyPattern);

        /// <summary>
        /// Verilen key ile cache kaydı siler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Remove(string key);

        /// <summary>
        /// Verilen key'e ait bir cache kaydı olup olmadığını döndürür.
        /// Spesifik sorgulama yapar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        bool IsCacheExist(string key);

        #endregion sync methods

        #region asynchronous methods

        #region Setter methods

        /// <summary>
        /// Milisaniye cinsinde TTL (cache timeout) alır ve tekil kayıt oluşturur/günceller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout">Millisecond</param>
        Task SetAsync<T>(string key, T value, TimeSpan? TTL) where T : class;

        /// <summary>
        /// Milisaniye cinsinde TTL (cache timeout) alır ve tekil kayıt oluşturur/günceller
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeout">Millisecond</param>
        Task SetAsync<T>(string key, List<T> value, TimeSpan? TTL) where T : class;

        #endregion Setter methods
        #region Getter methods
        Task<string> GetAsync(string key);
        #endregion Getter methods

        /// <summary>
        /// Verilen key ile cache kaydı siler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        Task RemoveAsync(string key);
        #endregion asynchronous methods
    }
}
