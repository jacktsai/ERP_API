using ErpApi.Entities;

namespace ErpApi.DAL
{
    /// <summary>
    /// Privilege Data存取介面。
    /// </summary>
    public interface IPrivilegeDao
    {
        /// <summary>
        /// 取得 Privilege Data。
        /// </summary>
        /// <param name="backyardId">Backyard ID。</param>
        /// <param name="url">URL。</param>
        /// <returns>Privilege Data。</returns>
        Privilege GetOne(string backyardId, string url);
    }
}