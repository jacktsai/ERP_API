using ErpApi.Entities;

namespace ErpApi.DAL
{
    /// <summary>
    /// Deny Privilege Data存取介面。
    /// </summary>
    public interface IDenyPrivDao
    {
        /// <summary>
        /// 取得Deny Privilege Data。
        /// </summary>
        /// <param name="userId">使用者序號。</param>
        /// <param name="url">URL。</param>
        /// <returns>Deny Privilege Data。</returns>
        DenyPriv GetOne(int userId, string url);
    }
}